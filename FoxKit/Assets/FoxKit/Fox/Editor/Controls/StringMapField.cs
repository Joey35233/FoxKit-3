using Fox.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class StringMapField<T> : BaseField<Fox.Core.StringMap<T>>, IFoxField, ICustomBindable
    {
        private ListView ListViewInput;

        private static Func<IFoxField> FieldConstructor = FoxFieldUtils.GetTypeFieldConstructor(typeof(T));

        private SerializedProperty StringMapProperty;

        public new static readonly string ussClassName = "fox-stringmap-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string addButtonUssClassName = ussClassName + "__add-button";
        public static readonly string removeButtonUssClassName = ussClassName + "__remove-button";

        public VisualElement visualInput { get; }

        public StringMapField() : this(default)
        {
        }

        public StringMapField(string label)
            : this(label, new ListView())
        {
        }

        private StringMapField(string label, ListView visInput)
            : base(label, visInput)
        {
            ListViewInput = visInput;
            visualInput = ListViewInput;

            ListViewInput.makeItem = MakeItem;
            ListViewInput.bindItem = BindItem;
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            ListViewInput.showAddRemoveFooter = false;

            // Technically, the header is the footer, just at the top.
            var header = new VisualElement();
            header.name = ListView.footerUssClassName;
            header.AddToClassList(ListView.footerUssClassName);

            var addButton = new Button(AddButton_clicked);
            addButton.name = ListView.ussClassName + "__add-button";
            addButton.text = "＋";
            addButton.AddToClassList(addButtonUssClassName);

            var removeButton = new Button(RemoveButton_clicked);
            removeButton.name = ListView.ussClassName + "__remove-button";
            removeButton.text = "－";
            removeButton.AddToClassList(removeButtonUssClassName);

            header.Add(removeButton);
            header.Add(addButton);

            ListViewInput.hierarchy.Insert(0, header);
            ListViewInput.AddToClassList(ListView.listViewWithFooterUssClassName);
            ListViewInput.Q<ScrollView>(className: ListView.listScrollViewUssClassName).AddToClassList(ListView.scrollViewWithFooterUssClassName);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.type.StartsWith("Fox.Core.StringMap"))
                {
                    StringMapProperty = property;

                    BindingExtensions.TrackPropertyValue(this, StringMapProperty, OnPropertyChanged);

                    OnPropertyChanged(null);

                    // Stop the StringMapField itself's binding event; it's just a container for the actual BindableElements.
                    evt.StopPropagation();
                }
            }
        }
        private void OnPropertyChanged(SerializedProperty property)
        {
            ListViewInput.itemsSource = StringMapProperty.GetValue() as IList;
            ListViewInput.RefreshItems();
        }

        private void AddButton_clicked()
        {
            string key = StringMapKeyPicker.ShowPopup();
            if (key != null)
            {
                // StringMapProperty.serializedObject.Update();

                Undo.RecordObject(StringMapProperty.serializedObject.targetObject, $"Insert cell");

                var stringMap = ListViewInput.itemsSource as StringMap<T>;
                stringMap.Insert(key, default);

                // Apply without Undo so that the registered Undo event above works correctly.
                StringMapProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        private void RemoveButton_clicked()
        {
            if (ListViewInput.selectedIndex != -1)
            {
                // StringMapProperty.serializedObject.Update();

                Undo.RecordObject(StringMapProperty.serializedObject.targetObject, $"Remove cell");

                foreach (var selectedIndex in ListViewInput.selectedIndices)
                {
                    int absoluteIndex = (ListViewInput.itemsSource as IStringMap).OccupiedIndexToAbsoluteIndex(selectedIndex);
                    ListViewInput.itemsSource.RemoveAt(absoluteIndex);
                }

                // Apply without Undo so that the registered Undo event above works correctly.
                StringMapProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        private VisualElement MakeItem()
        {
            return new CellField(FieldConstructor() as BindableElement);
        }

        private void BindItem(VisualElement element, int index)
        {
            StringMap<T> stringMap = ListViewInput.itemsSource as StringMap<T>;
            var i = (stringMap as IStringMap).OccupiedIndexToAbsoluteIndex(index);

            var cellProperty = StringMapProperty.FindPropertyRelative("Cells").GetArrayElementAtIndex(i);

            CellField field = element as CellField;
            field.KeyField.BindProperty(cellProperty.FindPropertyRelative("Key"));
            field.DataField.BindProperty(cellProperty.FindPropertyRelative("Value"));

            field.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            field.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);

            Label label = field.labelElement;
            label.text = $"[{index}]";
            label.style.minWidth = 40;
            label.style.flexBasis = 40;

            return;
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            StringMapProperty = property.Copy();

            BindingExtensions.TrackPropertyValue(this, StringMapProperty, OnPropertyChanged);

            OnPropertyChanged(null);
        }

        private class CellField : VisualElement
        {
            public StringField KeyField;
            public BindableElement DataField;

            public static readonly string ussClassName = "fox-stringmap-cell-field";
            public static readonly string labelUssClassName = ussClassName + "__label";
            public static readonly string inputUssClassName = ussClassName + "__input";

            public Label labelElement;
            public VisualElement visualInput { get; }

            public CellField(BindableElement dataField)
            {
                labelElement = new Label();
                this.Add(labelElement);

                visualInput = new VisualElement();
                this.Add(visualInput);

                KeyField = new StringField();
                KeyField.SetEnabled(false);
                KeyField.style.flexBasis = new StyleLength(StyleKeyword.Auto);
                KeyField.style.flexGrow = 0;
                KeyField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
                KeyField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
                visualInput.Add(KeyField);

                DataField = dataField;
                DataField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
                visualInput.Add(DataField);

                AddToClassList(ussClassName);
                labelElement.AddToClassList(BaseField<float>.ussClassName);
                AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.ussClassName);
                labelElement.AddToClassList(labelUssClassName);
                labelElement.AddToClassList(BaseField<float>.labelUssClassName);
                labelElement.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.labelUssClassName);
                visualInput.AddToClassList(inputUssClassName);
                visualInput.AddToClassList(BaseField<float>.inputUssClassName);
                visualInput.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.inputUssClassName);
            }
        }
    }

    [CustomPropertyDrawer(typeof(Core.StringMap<>))]
    public class StringMapDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement genericField = (VisualElement)Activator.CreateInstance(typeof(StringMapField<>).MakeGenericType(new Type[] { fieldInfo.FieldType.GenericTypeArguments[0] }), new object[] { property.name });
            (genericField as IFoxField).BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}
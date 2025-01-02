using Fox.Core;
using Fox;
using System;
using System.Collections;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class StringMapField<T> : BaseField<StringMap<T>>, IFoxField
    {
        private readonly ListView ListViewInput;

        private static readonly Func<IFoxField> DefaultFieldConstructor = FoxFieldUtils.GetBindableElementConstructorForType(typeof(T));
        private Func<IFoxField> FieldConstructor = DefaultFieldConstructor;

        private SerializedProperty StringMapProperty;
        private PropertyInfo PropertyInfo; // Unfortunate hack around the fact that SerializedProperty.boxedValue doesn't work on things that own List<T>s and []s.

        public static new readonly string ussClassName = "fox-stringmap-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string addButtonUssClassName = ussClassName + "__add-button";
        public static readonly string removeButtonUssClassName = ussClassName + "__remove-button";

        public VisualElement visualInput
        {
            get;
        }

        public StringMapField() 
            : this(label: null)
        {
        }
        
        public StringMapField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name, new ListView(), propertyInfo)
        {
        }

        public StringMapField(string label)
            : this(label, new ListView())
        {
        }

        private StringMapField(string label, ListView visInput, PropertyInfo propertyInfo = null)
            : base(label, visInput)
        {
            if (propertyInfo is not null)
            {
                FieldConstructor = FoxFieldUtils.GetBindableElementConstructorForPropertyInfo(propertyInfo);
                PropertyInfo = propertyInfo;
            }
            else
            {
                Debug.LogWarning("EdCore: StringMap can currently only be bound to Entity properties.");
                return;
            }
            
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
            var header = new VisualElement
            {
                name = ListView.footerUssClassName
            };
            header.AddToClassList(ListView.footerUssClassName);

            var addButton = new Button(AddButton_clicked)
            {
                name = ListView.ussClassName + "__add-button",
                text = "＋"
            };
            addButton.AddToClassList(addButtonUssClassName);

            var removeButton = new Button(RemoveButton_clicked)
            {
                name = ListView.ussClassName + "__remove-button",
                text = "－"
            };
            removeButton.AddToClassList(removeButtonUssClassName);

            header.Add(removeButton);
            header.Add(addButton);

            ListViewInput.hierarchy.Insert(0, header);
            ListViewInput.AddToClassList(ListView.listViewWithFooterUssClassName);
            ListViewInput.Q<ScrollView>(className: ListView.listScrollViewUssClassName).AddToClassList(ListView.scrollViewWithFooterUssClassName);

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        protected override void ExecuteDefaultActionAtTarget(EventBase evt)
        {
            base.ExecuteDefaultActionAtTarget(evt);

            // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
            if (evt.eventTypeId == FoxFieldUtils.SerializedPropertyBindEventTypeId && !System.String.IsNullOrWhiteSpace(bindingPath))
            {
                var property = FoxFieldUtils.SerializedPropertyBindEventBindProperty.GetValue(evt) as SerializedProperty;

                if (property.type.StartsWith("StringMap"))
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
            if (property != null)
                StringMapProperty = property.Copy();

            // TODO: Replace with custom virtualization controller here: https://docs.unity3d.com/ScriptReference/UIElements.CollectionViewController.html
            var target = StringMapProperty.serializedObject.targetObject;
            var targetEntity = target as Entity;
            var propertyTest = targetEntity.GetProperty(PropertyInfo.Name);
            var propertyList = propertyTest.GetValueAsStringMap<T>();
            ListViewInput.itemsSource = propertyList as IList;
            ListViewInput.Rebuild();
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
                _ = StringMapProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        private void RemoveButton_clicked()
        {
            if (ListViewInput.selectedIndex != -1)
            {
                // StringMapProperty.serializedObject.Update();

                Undo.RecordObject(StringMapProperty.serializedObject.targetObject, $"Remove cell");

                foreach (int selectedIndex in ListViewInput.selectedIndices)
                {
                    int absoluteIndex = (ListViewInput.itemsSource as IStringMap).OccupiedIndexToBackingIndex(selectedIndex);
                    ListViewInput.itemsSource.RemoveAt(absoluteIndex);
                }

                // Apply without Undo so that the registered Undo event above works correctly.
                _ = StringMapProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        private VisualElement MakeItem() => new CellField(FieldConstructor() as BindableElement);

        private void BindItem(VisualElement element, int index)
        {
            var stringMap = ListViewInput.itemsSource as StringMap<T>;
            int i = (stringMap as IStringMap).OccupiedIndexToBackingIndex(index);

            SerializedProperty cellProperty = StringMapProperty.FindPropertyRelative("CellsBacking").GetArrayElementAtIndex(i);

            var field = element as CellField;
            field.KeyField.BindProperty(cellProperty.FindPropertyRelative("Key"));
            field.DataField.BindProperty(cellProperty.FindPropertyRelative("Value"));
            
            Label label = field.labelElement;
            label.text = $"[{index}]";

            field.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            field.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);
        }

        private class CellField : VisualElement
        {
            public StringField KeyField;
            public BindableElement DataField;

            public static readonly string ussClassName = "fox-stringmap-cell-field";
            public static readonly string labelUssClassName = ussClassName + "__label";
            public static readonly string inputUssClassName = ussClassName + "__input";

            public Label labelElement;
            public VisualElement visualInput
            {
                get;
            }

            public CellField(BindableElement dataField)
            {
                labelElement = new Label();
                Add(labelElement);

                visualInput = new VisualElement();
                Add(visualInput);

                KeyField = new StringField();
                KeyField.SetEnabled(false);
                KeyField.style.flexBasis = new StyleLength(StyleKeyword.Auto);
                KeyField.style.flexGrow = 0;
                KeyField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.firstFieldVariantUssClassName);
                KeyField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
                visualInput.Add(KeyField);

                DataField = dataField;
                DataField.AddToClassList(BaseCompositeField<UnityEngine.Vector3, FloatField, float>.fieldUssClassName);
                DataField.AddToClassList("unity-composite-field__field--last");
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

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    // [CustomPropertyDrawer(typeof(StringMap<>))]
    // public class StringMapDrawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var genericField = (VisualElement)Activator.CreateInstance(typeof(StringMapField<>).MakeGenericType(fieldInfo.FieldType.GenericTypeArguments), new object[] { property.name });
    //         (genericField as IFoxField).BindProperty(property);
    //
    //         genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
    //         genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
    //         genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);
    //
    //         return genericField;
    //     }
    // }
}
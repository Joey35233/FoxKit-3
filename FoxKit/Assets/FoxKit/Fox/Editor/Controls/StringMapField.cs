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
    public class CellField : VisualElement
    {
        public StringField KeyField;
        public BindableElement DataField;

        public CellField(BindableElement dataField)
        {
            KeyField = new StringField();
            KeyField.SetEnabled(false);

            DataField = dataField;

            this.Add(KeyField);
            this.Add(DataField);

            this.style.flexDirection = FlexDirection.Row;
        }
    }

    public class StringMapField<T> : BaseField<Fox.Core.StringMap<T>>, IFoxField
    {
        private ListView ListViewInput;

        private static Func<IFoxField> FieldConstructor = CollectionDrawer.GetTypeFieldConstructor2(typeof(T));

        private static Type SerializedObjectListType = Type.GetType("UnityEditor.UIElements.Bindings.SerializedObjectList, UnityEditor.UIElementsModule");
        private static TypeInfo SerializedObjectListTypeInfo = SerializedObjectListType.GetTypeInfo();
        private static MethodInfo GetSerializedObjectListArraySizeMethodInfo = SerializedObjectListTypeInfo.GetMethod("get_ArraySize");

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

            var footer = new VisualElement();
            footer.name = ListView.footerUssClassName;
            footer.AddToClassList(ListView.footerUssClassName);

            var addButton = new Button(AddButton_clicked);
            addButton.name = ListView.ussClassName + "__add-button";
            addButton.text = "＋";
            addButton.AddToClassList(addButtonUssClassName);

            var removeButton = new Button(RemoveButton_clicked);
            removeButton.name = ListView.ussClassName + "__remove-button";
            removeButton.text = "－";
            removeButton.AddToClassList(removeButtonUssClassName);

            footer.Add(removeButton);
            footer.Add(addButton);

            ListViewInput.hierarchy.Add(footer);
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

            Type evtType = evt.GetType();
            if ((evtType.Name == "SerializedPropertyBindEvent") && !string.IsNullOrWhiteSpace(bindingPath))
            {
                SerializedProperty property = evtType.GetProperty("bindProperty").GetValue(evt) as SerializedProperty;
                StringMapProperty = property;

                if (StringMapProperty != null)
                {
                    BindingExtensions.TrackPropertyValue(this, StringMapProperty, null);

                    OnPropertyChanged();
                }

                // Stop the StringMapField itself's binding event; it's just a container for the actual BindableElements.
                evt.StopPropagation();
            }
            else if (evt is SerializedPropertyChangeEvent)
            {
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged()
        {
            UnityEngine.Debug.Log("StringMap<T> property changed!");
            if (ListViewInput.itemsSource == null)
            {
                ListViewInput.itemsSource = StringMapProperty.GetValue() as IList;
            }
            ListViewInput.Rebuild();
        }

        private void AddButton_clicked()
        {
            StringMapProperty.serializedObject.Update();
            Undo.RecordObject(StringMapProperty.serializedObject.targetObject, "Insert Cell");

            var stringMap = ListViewInput.itemsSource as StringMap<T>;
            String key = StringMapDrawerPopup.ShowPopup();
            if (key != null)
            {
                stringMap.Insert(key, default);

                StringMapProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        private void RemoveButton_clicked()
        {
            StringMapProperty.serializedObject.Update();
            Undo.RecordObject(StringMapProperty.serializedObject.targetObject, "Remove Cell");

            if (ListViewInput.selectedIndex != -1)
                foreach (var selectedIndex in ListViewInput.selectedIndices)
                    ListViewInput.itemsSource.RemoveAt((ListViewInput.itemsSource as IStringMap).OccupiedIndexToAbsoluteIndex()
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

            Label label = field.KeyField.labelElement;
            label.text = $"[{index}]";
            label.style.minWidth = 25;
            label.style.flexBasis = 25;

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
            BindingExtensions.BindProperty(this, property);
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
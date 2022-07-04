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
    public class DynamicArrayField<T> : BaseField<Fox.Core.DynamicArray<T>>, IFoxField
    {
        private ListView ListViewInput;

        private static Func<IFoxField> FieldConstructor = CollectionDrawer.GetTypeFieldConstructor2(typeof(T));
        
        private static Type SerializedObjectListType = Type.GetType("UnityEditor.UIElements.Bindings.SerializedObjectList, UnityEditor.UIElementsModule");
        private static TypeInfo SerializedObjectListTypeInfo = SerializedObjectListType.GetTypeInfo();
        private static MethodInfo GetSerializedObjectListArraySizeMethodInfo = SerializedObjectListTypeInfo.GetMethod("get_ArraySize");

        public new static readonly string ussClassName = "fox-dynamicarray-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string addButtonUssClassName = ussClassName + "__add-button";
        public static readonly string removeButtonUssClassName = ussClassName + "__remove-button";

        public VisualElement visualInput { get; }

        public DynamicArrayField() : this(default)
        {
        }

        public DynamicArrayField(string label)
            : this(label, new ListView())
        {
        }

        private DynamicArrayField(string label, ListView visInput)
            : base(label, visInput)
        {
            ListViewInput = visInput;
            visualInput = ListViewInput;

            ListViewInput.itemsSource = value;
            ListViewInput.makeItem = MakeItem;
            ListViewInput.bindItem = BindItem;
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            ListViewInput.showAddRemoveFooter = true;

            var addButton = ListViewInput.Q<Button>(name: "unity-list-view__add-button");
            addButton.text = "＋";
            addButton.AddToClassList(addButtonUssClassName);

            var removeButton = ListViewInput.Q<Button>(name: "unity-list-view__remove-button");
            removeButton.AddToClassList(removeButtonUssClassName);
            removeButton.text = "－";

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        private VisualElement MakeItem()
        {
            return FieldConstructor() as VisualElement;
        }

        private void BindItem(VisualElement element, int index)
        {
            SerializedProperty arraySize = GetSerializedObjectListArraySizeMethodInfo.Invoke(ListViewInput.itemsSource, null) as SerializedProperty;

            if (index >= arraySize.intValue)
                return;

            SerializedProperty itemProperty = ListViewInput.itemsSource[index] as SerializedProperty;
            (element as IFoxField).BindProperty(itemProperty, itemProperty.name);

            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);

            Label label = element.Q<Label>();
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
            BindingExtensions.BindProperty(ListViewInput, property.FindPropertyRelative("_list"));
        }
    }

    [CustomPropertyDrawer(typeof(Core.DynamicArray<>))]
    public class DynamicArrayDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement genericField = (VisualElement)Activator.CreateInstance(typeof(DynamicArrayField<>).MakeGenericType(new Type[] { fieldInfo.FieldType.GenericTypeArguments[0] }), new object[] { property.name });
            (genericField as IFoxField).BindProperty(property);

            genericField.Q(className: BaseField<float>.labelUssClassName).AddToClassList(PropertyField.labelUssClassName);
            genericField.Q(className: BaseField<float>.inputUssClassName).AddToClassList(PropertyField.inputUssClassName);
            genericField.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return genericField;
        }
    }
}
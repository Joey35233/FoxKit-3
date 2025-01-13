using Fox;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using PropertyInfo = Fox.Core.PropertyInfo;

namespace Fox.EdCore
{
    public class DynamicArrayField<T> : BaseField<DynamicArray<T>>, IFoxField
    {
        private readonly ListView ListViewInput;

        private static readonly Func<IFoxField> DefaultFieldConstructor = FoxFieldUtils.GetBindableElementConstructorForType(typeof(T));
        private Func<IFoxField> FieldConstructor = DefaultFieldConstructor;

        public static new readonly string ussClassName = "fox-dynamicarray-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string addButtonUssClassName = ussClassName + "__add-button";
        public static readonly string removeButtonUssClassName = ussClassName + "__remove-button";

        public VisualElement visualInput
        {
            get;
        }

        public DynamicArrayField() 
            : this(label: null)
        {
        }
        
        public DynamicArrayField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name, new ListView(), propertyInfo)
        {
        }

        public DynamicArrayField(string label)
            : this(label, new ListView())
        {
        }

        private DynamicArrayField(string label, ListView visInput, PropertyInfo propertyInfo = null)
            : base(label, visInput)
        {
            if (propertyInfo is not null)
                FieldConstructor = FoxFieldUtils.GetBindableElementConstructorForPropertyInfo(propertyInfo);
            
            ListViewInput = visInput;
            visualInput = ListViewInput;

            ListViewInput.bindingPath = "_list";
            ListViewInput.itemsSource = value;
            ListViewInput.makeItem = MakeItem;
            ListViewInput.bindItem = BindItem;
            ListViewInput.unbindItem = (element, i) => {};
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            ListViewInput.showAddRemoveFooter = true;

            Button addButton = ListViewInput.Q<Button>(name: "unity-list-view__add-button");
            addButton.text = "＋";
            addButton.AddToClassList(addButtonUssClassName);

            Button removeButton = ListViewInput.Q<Button>(name: "unity-list-view__remove-button");
            removeButton.AddToClassList(removeButtonUssClassName);
            removeButton.text = "－";

            VisualElement footer = ListViewInput.Q(name: ListView.footerUssClassName);
            ListViewInput.Remove(footer);
            ListViewInput.hierarchy.Insert(0, footer); // Technically, this is now the header.

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        private VisualElement MakeItem() => FieldConstructor() as VisualElement;

        private void BindItem(VisualElement element, int index)
        {
            var itemProperty = ListViewInput.itemsSource[index] as SerializedProperty;
            BindableElement bindable = element as BindableElement;
            bindable.BindProperty(itemProperty);
            IFoxField foxField = element as IFoxField;
            foxField.SetLabel($"[{index}]");

            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.fieldUssClassName);
            element.AddToClassList(BaseCompositeField<UnityEngine.Vector4, FloatField, float>.firstFieldVariantUssClassName);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
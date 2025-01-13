using Fox.Core;
using Fox;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class StaticArrayField<T> : BaseField<StaticArray<T>>, IFoxField
    {
        private readonly ListView ListViewInput;

        private static readonly Func<IFoxField> DefaultFieldConstructor = FoxFieldUtils.GetBindableElementConstructorForType(typeof(T));
        private Func<IFoxField> FieldConstructor = DefaultFieldConstructor;

        public static new readonly string ussClassName = "fox-staticarray-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public StaticArrayField() 
            : this(label: null)
        {
        }
        
        public StaticArrayField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name, new ListView(), propertyInfo)
        {
        }
        
        public StaticArrayField(string label)
            : this(label, new ListView())
        {
        }

        private StaticArrayField(string label, ListView visInput, PropertyInfo propertyInfo = null)
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
            ListViewInput.style.flexGrow = 1.0f;
            ListViewInput.selectionType = SelectionType.Single;
            ListViewInput.showBorder = true;
            ListViewInput.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            ListViewInput.reorderable = false;
            ListViewInput.showBoundCollectionSize = false;
            ListViewInput.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

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
using Fox.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    [CustomEditor(typeof(DynamicProperty), true)]
    public class DynamicPropertyEditor : UnityEditor.Editor
    {
        private VisualElement BaseElement;

        private IFoxField ValueField = null;

        private UInt32Field ArraySizeField = null;

        private DynamicProperty DynamicProperty => (DynamicProperty)target;
        
        public override VisualElement CreateInspectorGUI()
        {
            BaseElement = new VisualElement();
    
            var stringField = new StringField("name");
            stringField.bindingPath = DynamicProperty.NAME_PROPERTY_NAME;
            BaseElement.Add(stringField);
            
            var headerLine = new VisualElement
            {
                style =
                {
                    flexGrow = 1,
                    height = 0,
                    borderTopColor = Color.gray,
                    borderTopWidth = 1,
                    marginBottom = 4
                }
            };
            BaseElement.Add(headerLine);

            PropertyInfo propertyInfo = DynamicProperty.GetPropertyInfo();
            if (propertyInfo.Container == PropertyInfo.ContainerType.StaticArray && DynamicProperty.IsStaticArrayOverride())
            {
                ArraySizeField = new UInt32Field("arraySize");
                ArraySizeField.value = propertyInfo.ArraySize;
                ArraySizeField.RegisterValueChangedCallback<uint>(OnArraySizeChanged);
                BaseElement.Add(ArraySizeField);
                
                ValueField = FoxFieldUtils.GetCustomBindableField(propertyInfo, staticArrayOverride: true);
                ValueField.SetLabel("value");
                ValueField.bindingPath = DynamicProperty.VALUE_PROPERTY_NAME;
                BaseElement.Add(ValueField as VisualElement);
            }
            else
            {
                ValueField = FoxFieldUtils.GetCustomBindableField(propertyInfo);
                ValueField.SetLabel("value");
                ValueField.bindingPath = DynamicProperty.VALUE_PROPERTY_NAME;
                BaseElement.Add(ValueField as VisualElement);
            }
            
            return BaseElement;
        }
        
        private void OnArraySizeChanged(ChangeEvent<uint> evt)
        {
            DynamicProperty.ChangeStaticArraySize(evt.newValue);
        }
    }
}
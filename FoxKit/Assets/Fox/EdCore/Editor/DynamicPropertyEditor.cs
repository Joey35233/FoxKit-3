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

        private PositiveInt32Field StaticArraySizeField = null;

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
                    marginTop = 4,
                    marginBottom = 4
                }
            };
            BaseElement.Add(headerLine);

            PropertyInfo propertyInfo = DynamicProperty.GetPropertyInfo();
            if (propertyInfo.Container == PropertyInfo.ContainerType.StaticArray)
            {
                StaticArraySizeField = new PositiveInt32Field("arraySize");
                StaticArraySizeField.bindingPath = DynamicProperty.VALUE_PROPERTY_NAME + ".Array.size";
                BaseElement.Add(StaticArraySizeField);
                
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
    }
}
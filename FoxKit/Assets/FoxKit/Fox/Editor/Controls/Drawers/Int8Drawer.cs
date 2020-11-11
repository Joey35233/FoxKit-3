using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.SByte))]
    public class Int8Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var field = new Int8Field();
            field.BindProperty(property);
            field.label = property.name;

            field.RegisterValueChangedCallback(OnValueChanged);

            container.Add(field);
            return container;
        }

        private void OnValueChanged(ChangeEvent<sbyte> changeEvent)
        {
            return;
        }
    }
}
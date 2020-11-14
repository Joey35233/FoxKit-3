using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(Fox.String))]
    public class StringDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.style.flexDirection = FlexDirection.Row;

            var label = new Label(property.name);

            var isHashToggle = new Button();
            isHashToggle.text = "0x";

            var field = new StringField();
            field.BindProperty(property);

            container.Add(label);
            container.Add(isHashToggle);
            container.Add(field);
            return container;
        }
    }
}
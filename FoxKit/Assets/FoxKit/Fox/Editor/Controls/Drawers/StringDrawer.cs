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

            var field = new StringField();
            field.BindProperty(property);
            field.label = property.name;

            container.Add(field);
            return container;
        }
    }
}
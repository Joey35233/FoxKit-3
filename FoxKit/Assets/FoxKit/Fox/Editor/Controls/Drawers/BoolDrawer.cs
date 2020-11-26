using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Boolean))]
    public class BoolDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Toggle();
            field.BindProperty(property);
            field.label = property.name;
            field.labelElement.AddToClassList("unity-property-field__label");

            return field;
        }
    }
}
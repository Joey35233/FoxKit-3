using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(UnityEngine.Color))]
    public class ColorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new ColorField();
            field.label = property.name;
            field.BindProperty(property);
            field.labelElement.AddToClassList("unity-property-field__label");

            return field;
        }
    }
}
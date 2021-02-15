using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Double))]
    public class DoubleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new DoubleField();
            field.BindProperty(property);
            field.label = property.name;
            field.labelElement.AddToClassList("unity-property-field__label");
            field.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

            return field;
        }
    }
}
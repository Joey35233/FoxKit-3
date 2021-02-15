using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Single))]
    public class FloatDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FloatField();
            field.BindProperty(property);
            field.label = property.name;
            field.labelElement.AddToClassList("unity-property-field__label");
            field.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

            return field;
        }
    }
}
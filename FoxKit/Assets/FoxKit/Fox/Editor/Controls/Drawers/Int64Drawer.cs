using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Int64))]
    public class Int64Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var field = new Int64Field();
            field.BindProperty(property);
            field.label = property.name;

            container.Add(field);
            return container;
        }
    }
}
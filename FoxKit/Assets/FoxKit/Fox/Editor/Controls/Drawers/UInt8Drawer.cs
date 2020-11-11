using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Byte))]
    public class UInt8Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var field = new UInt8Field();
            field.BindProperty(property);
            field.label = property.name;

            container.Add(field);
            return container;
        }
    }
}
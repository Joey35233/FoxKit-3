using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.UInt16))]
    public class UInt16Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var field = new UInt16Field();
            field.BindProperty(property);
            field.label = property.name;

            container.Add(field);
            return container;
        }
    }
}
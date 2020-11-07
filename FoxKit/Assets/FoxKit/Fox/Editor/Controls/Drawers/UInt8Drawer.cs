using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Byte))]
    public class UInt8Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var foldout = new UInt8Field();
            foldout.label = property.name;

            container.Add(foldout);
            return container;
        }
    }
}
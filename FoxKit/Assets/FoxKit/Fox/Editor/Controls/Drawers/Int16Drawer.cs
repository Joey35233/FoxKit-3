using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(System.Int16))]
    public class Int16Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();

            var foldout = new Int16Field();
            foldout.label = property.name;

            container.Add(foldout);
            return container;
        }
    }
}
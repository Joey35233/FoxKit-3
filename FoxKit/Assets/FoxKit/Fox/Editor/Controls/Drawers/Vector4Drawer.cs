using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
    public class Vector4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.AddToClassList("unity-base-field");
            container.AddToClassList("unity-composite-field");

            var label = new Label(property.name);
            label.AddToClassList("unity-base-field__label");
            label.AddToClassList("unity-property-field__label");
            container.Add(label);

            var innerContainer = new VisualElement();
            innerContainer.AddToClassList("unity-base-field__input");
            innerContainer.AddToClassList("unity-composite-field__input");

            var xField = new FloatField("X");
            xField.BindProperty(property.FindPropertyRelative("x"));
            xField.AddToClassList("unity-composite-field__field");
            xField.AddToClassList("unity-composite-field__field--first");
            innerContainer.Add(xField);

            var yField = new FloatField("Y");
            yField.BindProperty(property.FindPropertyRelative("y"));
            yField.AddToClassList("unity-composite-field__field");
            innerContainer.Add(yField);

            var zField = new FloatField("Z");
            zField.BindProperty(property.FindPropertyRelative("z"));
            zField.AddToClassList("unity-composite-field__field");
            innerContainer.Add(zField);

            var wField = new FloatField("W");
            wField.BindProperty(property.FindPropertyRelative("w"));
            wField.AddToClassList("unity-composite-field__field");
            innerContainer.Add(wField);

            container.Add(innerContainer);

            return container;
        }
    }
}
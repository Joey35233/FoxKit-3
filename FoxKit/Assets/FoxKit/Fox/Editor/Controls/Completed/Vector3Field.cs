using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Vector3Field : IFoxField
    {
        private UnityEditor.UIElements.Vector3Field InternalField;

        public Vector3Field() : this(default)
        {
        }

        public Vector3Field(string label)
        {
            InternalField = new UnityEditor.UIElements.Vector3Field();
            InternalField.label = label;
            InternalField.labelElement.AddToClassList("unity-property-field__label");
            InternalField.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Vector3))]
    public class Vector3Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new Vector3Field(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}
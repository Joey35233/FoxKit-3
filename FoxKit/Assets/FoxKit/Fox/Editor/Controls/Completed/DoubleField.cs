using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class DoubleField : IFoxField
    {
        private UnityEditor.UIElements.DoubleField InternalField;
        private SerializedProperty Property;

        public DoubleField()
        {
            InternalField = new UnityEditor.UIElements.DoubleField();

            this.Add(InternalField);
        }

        public DoubleField(string label)
        {
            InternalField = new UnityEditor.UIElements.DoubleField(label);

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            this.Property = property;

            InternalField.label = label;
            InternalField.BindProperty(property);
            InternalField.labelElement.AddToClassList("unity-property-field__label");
            InternalField.styleSheets.Add(NumericPropertyDrawers.NumericPropertyDrawersStyleSheet);
            if (ussClassNames != null)
                foreach (var className in ussClassNames)
                    InternalField.labelElement.AddToClassList(className);
        }
    }

    [CustomPropertyDrawer(typeof(System.Double))]
    public class DoubleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new DoubleField();
            field.BindProperty(property);

            return field;
        }
    }
}
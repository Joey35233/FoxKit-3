using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class FloatField : IFoxField
    {
        private UnityEditor.UIElements.FloatField InternalField;
        private SerializedProperty Property;

        public FloatField()
        {
            InternalField = new UnityEditor.UIElements.FloatField();

            this.Add(InternalField);
        }

        public FloatField(string label)
        {
            InternalField = new UnityEditor.UIElements.FloatField(label);

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

    [CustomPropertyDrawer(typeof(System.Single))]
    public class FloatDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FloatField();
            field.BindProperty(property);

            return field;
        }
    }
}
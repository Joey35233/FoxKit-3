using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class BoolField : IFoxField
    {
        private Toggle InternalField;
        private SerializedProperty Property;

        public BoolField()
        {
            InternalField = new Toggle();

            this.Add(InternalField);
        }

        public BoolField(string label)
        {
            InternalField = new Toggle(label);

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
            if (ussClassNames != null)
                foreach (var className in ussClassNames)
                    InternalField.labelElement.AddToClassList(className);
        }

        private void OnValueChanged(ChangeEvent<string> changeEvent) => Property.SetValue(new Fox.Core.Path(changeEvent.newValue));
    }

    [CustomPropertyDrawer(typeof(System.Boolean))]
    public class BoolDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new BoolField();
            field.BindProperty(property);
            
            return field;
        }
    }
}
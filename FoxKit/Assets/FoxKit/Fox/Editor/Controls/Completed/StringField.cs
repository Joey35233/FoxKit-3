using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class StringField : FoxField
    {
        private TextField InternalField;
        private SerializedProperty Property;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public StringField() : this(default)
        {

        }

        public StringField(string label)
        {
            InternalField = new TextField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-string-field");
			this.AddToClassList("fox-base-field");
            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            this.Property = property;

            if (!IsUserAssignedLabel)
                InternalField.label = label;
            InternalField.BindProperty(property.FindPropertyRelative("_cString"));
            InternalField.RegisterValueChangedCallback(OnValueChanged);
        }

        private void OnValueChanged(ChangeEvent<string> changeEvent) => Property.SetValue(new String(changeEvent.newValue));
    }

    [CustomPropertyDrawer(typeof(Fox.String))]
    public class StringDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new StringField();
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}
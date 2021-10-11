using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class PathField : FoxField
    {
        private TextField InternalField;
        private SerializedProperty Property;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public PathField() : this(default)
        {

        }

        public PathField(string label)
        {
            InternalField = new TextField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            InternalField.style.marginTop = 0;
            InternalField.style.marginBottom = 0;

            this.AddToClassList("fox-path-field");
			this.AddToClassList("fox-base-field");
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);
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

        private void OnValueChanged(ChangeEvent<string> changeEvent) => Property.SetValue(new Fox.Core.Path(changeEvent.newValue));
    }

    [CustomPropertyDrawer(typeof(Fox.Core.Path))]
    public class PathDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new PathField();
            field.BindProperty(property);

            return field;
        }
    }
}
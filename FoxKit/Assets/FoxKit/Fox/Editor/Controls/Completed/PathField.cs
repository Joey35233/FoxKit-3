using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class PathField : IFoxField
    {
        private TextField InternalField;
        private SerializedProperty Property;

        public PathField()
        {
            InternalField = new TextField();

            this.Add(InternalField);
        }

        public PathField(string label)
        {
            InternalField = new TextField(label);

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
            InternalField.BindProperty(property.FindPropertyRelative("_cString"));
            InternalField.RegisterValueChangedCallback(OnValueChanged);
            InternalField.labelElement.AddToClassList("unity-property-field__label");
            if (ussClassNames != null)
                foreach (var className in ussClassNames)
                    InternalField.labelElement.AddToClassList(className);
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
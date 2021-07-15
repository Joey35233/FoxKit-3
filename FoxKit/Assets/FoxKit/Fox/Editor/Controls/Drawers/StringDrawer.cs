using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Reflection;
using System;
using System.Linq;

namespace Fox.Editor
{
    public class StringField : BindableElement
    {
        private TextField InternalField;
        private SerializedProperty Property;

        public StringField()
        {
            InternalField = new TextField();

            this.Add(InternalField);
        }

        public StringField(string label)
        {
            InternalField = new TextField(label);

            this.Add(InternalField);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public void BindProperty(SerializedProperty property, string label)
        {
            this.Property = property;

            InternalField.label = label;
            InternalField.BindProperty(property.FindPropertyRelative("_cString"));
            InternalField.RegisterValueChangedCallback(OnValueChanged);
            InternalField.labelElement.AddToClassList("unity-property-field__label");
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

            return field;
        }
    }
}
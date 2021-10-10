using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class FloatField : FoxField
    {
        private UnityEditor.UIElements.FloatField InternalField;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public FloatField() : this(default)
        {
        }

        public FloatField(string label)
        {
            InternalField = new UnityEditor.UIElements.FloatField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-float-field");
			this.AddToClassList("fox-base-field");
            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label)
        {
            if (!IsUserAssignedLabel)
                InternalField.label = label;
            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(System.Single))]
    public class FloatDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FloatField();
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}
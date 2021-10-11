using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class ColorField : FoxField
    {
        private UnityEditor.UIElements.ColorField InternalField;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public ColorField() : this(default)
        {
        }

        public ColorField(string label)
        {
            InternalField = new UnityEditor.UIElements.ColorField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-color-field");
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
            if (!IsUserAssignedLabel)
                InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(UnityEngine.Color))]
    public class ColorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new ColorField(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class DoubleField : FoxField
    {
        private UnityEditor.UIElements.DoubleField InternalField;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public DoubleField()
        {
            InternalField = new UnityEditor.UIElements.DoubleField();

            this.Add(InternalField);
        }

        public DoubleField(string label)
        {
            InternalField = new UnityEditor.UIElements.DoubleField(label);
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-double-field");
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
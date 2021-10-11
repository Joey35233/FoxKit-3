using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Vector4Field : FoxField
    {
        private UnityEditor.UIElements.Vector4Field InternalField;

        public override string label
        {
            get => InternalField.label;
            set => InternalField.label = value;
        }

        public Vector4Field() : this(default)
        {
        }

        public Vector4Field(string label)
        {
            InternalField = new UnityEditor.UIElements.Vector4Field();
            InternalField.label = label;
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-vector4-field");
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

    [CustomPropertyDrawer(typeof(UnityEngine.Vector4))]
    public class Vector4Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Vector4Field(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}
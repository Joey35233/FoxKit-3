using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class Vector3Field : FoxField
    {
        private UnityEditor.UIElements.Vector3Field InternalField;

        public override string label
        {
            get => InternalField.label;
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public Vector3Field() : this(default)
        {
        }

        public Vector3Field(string label)
        {
            InternalField = new UnityEditor.UIElements.Vector3Field();
            InternalField.label = label;
            if (label != null)
                IsUserAssignedLabel = true;

            this.AddToClassList("fox-vector3-field");
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

    [CustomPropertyDrawer(typeof(UnityEngine.Vector3))]
    public class Vector3Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Vector3Field(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}
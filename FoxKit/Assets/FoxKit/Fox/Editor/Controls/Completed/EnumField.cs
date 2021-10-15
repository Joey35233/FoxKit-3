using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EnumField : FoxField
    {
        private UnityEditor.UIElements.EnumField InternalField;

        public override string label
        {
            get => InternalField.label;
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public EnumField() : this(default)
        {
        }

        public EnumField(string label)
        {
            InternalField = new UnityEditor.UIElements.EnumField();
            InternalField.label = label;

            this.AddToClassList("fox-enum-field");
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
            InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    public class EnumFlagsField : FoxField
    {
        private UnityEditor.UIElements.EnumFlagsField InternalField;

        public override string label
        {
            get => InternalField.label;
            set
            {
                IsUserAssignedLabel = true;
                InternalField.label = value;
            }
        }

        public EnumFlagsField() : this(default)
        {
        }

        public EnumFlagsField(string label)
        {
            InternalField = new UnityEditor.UIElements.EnumFlagsField();
            InternalField.label = label;

            this.AddToClassList("fox-enum-flags-field");
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
            InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(System.Enum), true)]
    public class EnumDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var valueType = property.GetValue().GetType();
            bool valueTypeHasFlagsAttribute = valueType.IsDefined(typeof(System.FlagsAttribute), false);

            FoxField field = null;
            if (valueTypeHasFlagsAttribute)
                field = new EnumFlagsField();
            else
                field = new EnumField();

            field.BindProperty(property);

            return field;
        }
    }
}
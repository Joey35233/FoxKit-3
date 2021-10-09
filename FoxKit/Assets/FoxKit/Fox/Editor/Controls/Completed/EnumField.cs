using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EnumField : IFoxField
    {
        private UnityEditor.UIElements.EnumField InternalField;

        public EnumField() : this(default)
        {
        }

        public EnumField(string label)
        {
            InternalField = new UnityEditor.UIElements.EnumField();
            InternalField.label = label;
            InternalField.labelElement.AddToClassList("unity-property-field__label");

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
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
            IFoxField container;
            if (property.GetValue() is System.FlagsAttribute)
                container = new EnumFlagsField(property.name);
                container = new EnumField(property.name);
            container.BindProperty(property);

            //IFoxField container = new EnumFlagsField();

            return container;
        }
    }

    public class EnumFlagsField : IFoxField
    {
        private UnityEditor.UIElements.EnumFlagsField InternalField;

        public EnumFlagsField() : this(default)
        {
        }

        public EnumFlagsField(string label)
        {
            InternalField = new UnityEditor.UIElements.EnumFlagsField();
            InternalField.label = label;
            InternalField.labelElement.AddToClassList("unity-property-field__label");

            this.Add(InternalField);
        }

        public override void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public override void BindProperty(SerializedProperty property, string label, string[] ussClassNames = null)
        {
            InternalField.label = label;

            InternalField.BindProperty(property);
        }
    }

    [CustomPropertyDrawer(typeof(System.FlagsAttribute), true)]
    public class EnumFlagsDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new EnumFlagsField(property.name);
            container.BindProperty(property);

            return container;
        }
    }
}
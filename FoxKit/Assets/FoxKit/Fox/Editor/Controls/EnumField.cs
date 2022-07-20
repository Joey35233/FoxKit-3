using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EnumField : UnityEngine.UIElements.EnumField, IFoxField, ICustomBindable
    {
        public new static readonly string ussClassName = "fox-enum-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EnumField()
            : this(null) { }

        public EnumField(string label)
            : base(label)
        {
            RemoveFromClassList(UnityEngine.UIElements.EnumField.ussClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<System.Enum>.inputUssClassName);
            //visualInput.RemoveFromClassList(UnityEngine.UIElements.EnumField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(UnityEngine.UIElements.EnumField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }
    }

    public class EnumFlagsField : UnityEditor.UIElements.EnumFlagsField, IFoxField, ICustomBindable
    {
        public new static readonly string ussClassName = "fox-enumflags-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public EnumFlagsField()
            : this(null) { }

        public EnumFlagsField(string label)
            : base(label)
        {
            RemoveFromClassList(UnityEditor.UIElements.EnumFlagsField.ussClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<System.Enum>.inputUssClassName);
            visualInput.RemoveFromClassList(UnityEditor.UIElements.EnumFlagsField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(UnityEditor.UIElements.EnumFlagsField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }
    }

    [CustomPropertyDrawer(typeof(System.Enum), true)]
    public class EnumDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var valueType = fieldInfo.FieldType;
            bool valueTypeHasFlagsAttribute = valueType.IsDefined(typeof(System.FlagsAttribute), false);

            IFoxField foxField = null;
            if (valueTypeHasFlagsAttribute)
            {
                EnumFlagsField field = new EnumFlagsField(property.name);
                field.labelElement.AddToClassList(PropertyField.labelUssClassName);
                field.visualInput.AddToClassList(PropertyField.inputUssClassName);
                field.AddToClassList(BaseField<Fox.Core.Path>.alignedFieldUssClassName);

                foxField = field;
            }
            else
            {
                EnumField field = new EnumField(property.name);
                field.labelElement.AddToClassList(PropertyField.labelUssClassName);
                field.visualInput.AddToClassList(PropertyField.inputUssClassName);
                field.AddToClassList(BaseField<Fox.Core.Path>.alignedFieldUssClassName);

                foxField = field;
            }

            foxField.BindProperty(property);

            return foxField as VisualElement;
        }
    }
}
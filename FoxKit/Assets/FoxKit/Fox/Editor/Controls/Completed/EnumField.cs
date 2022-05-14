using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Fox.Editor
{
    public class EnumField : UnityEditor.UIElements.EnumField
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
            RemoveFromClassList(UnityEditor.UIElements.EnumField.ussClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<System.Enum>.inputUssClassName);
            visualInput.RemoveFromClassList(UnityEditor.UIElements.EnumField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(UnityEditor.UIElements.EnumField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
    }

    public class EnumFlagsField : UnityEditor.UIElements.EnumFlagsField
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
    }

    [CustomPropertyDrawer(typeof(System.Enum), true)]
    public class EnumDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var valueType = property.GetValue().GetType();
            bool valueTypeHasFlagsAttribute = valueType.IsDefined(typeof(System.FlagsAttribute), false);

            BaseField<System.Enum> field = null;
            if (valueTypeHasFlagsAttribute)
                field = new EnumFlagsField();
            else
                field = new EnumField();

            field.BindProperty(property);

            return field;
        }
    }
}
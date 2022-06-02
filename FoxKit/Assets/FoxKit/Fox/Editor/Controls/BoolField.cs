using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Reflection;

namespace Fox.Editor
{
    public class BoolField : BaseBoolField, IFoxField
    {
        public new class UxmlFactory : UxmlFactory<Toggle, UxmlTraits> { }

        public new class UxmlTraits : BaseFieldTraits<bool, UxmlBoolAttributeDescription>
        {
            UxmlStringAttributeDescription Text = new UxmlStringAttributeDescription { name = "text" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                ((Toggle)ve).text = Text.GetValueFromBag(bag, cc);
            }
        }

        public static readonly string toggleUssClassName = "unity-toggle";
        public static readonly string toggleLabelUssClassName = toggleUssClassName + "__label";
        public static readonly string toggleInputUssClassName = toggleUssClassName + "__input";
        public static readonly string toggleCheckmarkUssClassName = toggleUssClassName + "__checkmark";
        public new static readonly string ussClassName = "fox-bool-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string checkmarkUssClassName = ussClassName + "__checkmark";

        public VisualElement visualInput { get; }

        public BoolField()
            : this(null)
        {
        }

        public BoolField(string label)
            : base(label)
        {
            AddToClassList(toggleUssClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<System.Boolean>.inputUssClassName);
            visualInput.AddToClassList(toggleInputUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            labelElement.AddToClassList(toggleLabelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            m_CheckMark.AddToClassList(toggleCheckmarkUssClassName);
            m_CheckMark.AddToClassList(checkmarkUssClassName);
        }

        // Lots of internal PseudoState-managing code
        //protected override void UpdateMixedValueContent() {}

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

    [CustomPropertyDrawer(typeof(System.Boolean))]
    public class BoolDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new BoolField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.Boolean>.alignedFieldUssClassName);

            return field;
        }
    }
}
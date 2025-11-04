using Fox.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class BoolField : BaseBoolField, IFoxField
    {
        public static readonly string toggleUssClassName = "unity-toggle";
        public static readonly string toggleLabelUssClassName = toggleUssClassName + "__label";
        public static readonly string toggleInputUssClassName = toggleUssClassName + "__input";
        public static readonly string toggleCheckmarkUssClassName = toggleUssClassName + "__checkmark";
        public static new readonly string ussClassName = "fox-bool-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";
        public static readonly string checkmarkUssClassName = ussClassName + "__checkmark";

        public VisualElement visualInput
        {
            get;
        }

        public BoolField()
            : this(label: null)
        {
        }
        
        public BoolField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public BoolField(string label)
            : base(label)
        {
            AddToClassList(toggleUssClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<bool>.inputUssClassName);
            visualInput.AddToClassList(toggleInputUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            labelElement.AddToClassList(toggleLabelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            m_CheckMark.AddToClassList(toggleCheckmarkUssClassName);
            m_CheckMark.AddToClassList(checkmarkUssClassName);
        }

        // Lots of internal PseudoState-managing code
        //protected override void UpdateMixedValueContent() {}

        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
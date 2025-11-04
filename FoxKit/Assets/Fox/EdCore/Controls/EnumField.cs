using Fox.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class EnumField : UnityEngine.UIElements.EnumField, IFoxField
    {
        public static new readonly string ussClassName = "fox-enum-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public EnumField()
            : this(label: null)
        {
        }
        
        public EnumField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

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

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }

    public class EnumFlagsField : UnityEditor.UIElements.EnumFlagsField, IFoxField
    {
        public static new readonly string ussClassName = "fox-enumflags-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public EnumFlagsField()
            : this(label: null)
        {
        }
        
        public EnumFlagsField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

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

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
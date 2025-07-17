using Fox.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class StringField : TextField, IFoxField
    {
        public static new readonly string ussClassName = "fox-string-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public StringField()
            : this(label: null)
        {
        }
        
        public StringField(PropertyInfo propertyInfo)
            : this(propertyInfo.Name)
        {
        }

        public StringField(string label, bool multiline = false, int maxLength = -1)
            : base(label, maxLength, multiline, false, '*')
        {
            RemoveFromClassList(TextField.ussClassName);
            AddToClassList(ussClassName);

            visualInput = this.Q(className: BaseField<string>.inputUssClassName);
            visualInput.RemoveFromClassList(TextField.inputUssClassName);
            visualInput.AddToClassList(inputUssClassName);

            labelElement.RemoveFromClassList(TextField.labelUssClassName);
            labelElement.AddToClassList(labelUssClassName);

            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
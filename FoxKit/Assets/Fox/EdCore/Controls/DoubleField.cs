using Fox.Core;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class DoubleField : TextValueField<double>, IFoxField
    {
        private DoubleInput doubleInput => (DoubleInput)textInputBase;

        protected override string ValueToString(double v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override double StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToDouble(str, out double v);
            return success ? v : rawValue;
        }

        public static new readonly string ussClassName = "fox-double-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public DoubleField() 
            : this(label: null)
        {
        }
        
        public DoubleField(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public DoubleField(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public DoubleField(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new DoubleInput())
        {
        }

        private DoubleField(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<double>();
        }

        //internal override bool CanTryParse(string textString) => double.TryParse(textString, out _);

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, double startValue) => doubleInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class DoubleInput : TextValueInput
        {
            private DoubleField parentDoubleField => (DoubleField)parent;

            internal DoubleInput()
            {
                formatString = NumericPropertyFields.DoubleFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.FloatExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(UnityEngine.Vector3 delta, DeltaSpeed speed, double startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                double v = StringToValue(text);
                v += NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity;
                v = NumericPropertyFields.RoundBasedOnMinimumDifference(v, sensitivity);
                if (parentDoubleField.isDelayed)
                {
                    text = ValueToString(v);
                }
                else
                {
                    parentDoubleField.value = v;
                }
            }

            protected override string ValueToString(double v) => v.ToString(formatString);

            protected override double StringToValue(string str) => parentDoubleField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
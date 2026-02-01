using Fox.Core;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class FloatField : TextValueField<float>, IFoxField
    {
        private FloatInput floatInput => (FloatInput)textInputBase;

        protected override string ValueToString(float v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override float StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToFloat(str, out float v);
            return success ? v : rawValue;
        }

        public static new readonly string ussClassName = "fox-float-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public FloatField() 
            : this(label: null)
        {
        }
        
        public FloatField(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public FloatField(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public FloatField(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new FloatInput())
        {
        }

        private FloatField(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<float>();
        }

        //internal override bool CanTryParse(string textString) => float.TryParse(textString, out _);

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue) => floatInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class FloatInput : TextValueInput
        {
            private FloatField parentFloatField => (FloatField)parent;

            internal FloatInput()
            {
                formatString = NumericPropertyFields.FloatFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.FloatExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                double v = StringToValue(text);
                v += NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity;
                v = NumericPropertyFields.RoundBasedOnMinimumDifference(v, sensitivity);
                if (parentFloatField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToFloat(v));
                }
                else
                {
                    parentFloatField.value = NumericPropertyFields.ClampToFloat(v);
                }
            }

            protected override string ValueToString(float v) => v.ToString(formatString);

            protected override float StringToValue(string str) => parentFloatField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
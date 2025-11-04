using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int64Field : TextValueField<long>, IFoxField
    {
        private Int64Input integerInput => (Int64Input)textInputBase;

        protected override string ValueToString(long v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override long StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToLong(str, out long v);
            return success ? v : rawValue;
        }

        public static new readonly string ussClassName = "fox-int64-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int64Field()
            : this(label: null)
        {
        }
        
        public Int64Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public Int64Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public Int64Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int64Input())
        {
        }

        private Int64Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<long>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class Int64Input : TextValueInput
        {
            private Int64Field parentIntegerField => (Int64Field)parent;

            internal Int64Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                
                long v = StringToValue(text);
                
                long niceDelta = (long)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                
                v = ClampMinMaxLongValue(niceDelta, v);
                
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(v);
                }
                else
                {
                    parentIntegerField.value = v;
                }
            }
            
            private long ClampMinMaxLongValue(long niceDelta, long value)
            {
                var niceDeltaAbs = System.Math.Abs(niceDelta);
                if (niceDelta > 0)
                {
                    if (value > 0 && niceDeltaAbs > long.MaxValue - value)
                    {
                        return long.MaxValue;
                    }

                    return value + niceDelta;
                }

                if (value < 0 && value < long.MinValue + niceDeltaAbs)
                {
                    return long.MinValue;
                }

                return value - niceDeltaAbs;
            }

            protected override string ValueToString(long v) => v.ToString(formatString);

            protected override long StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
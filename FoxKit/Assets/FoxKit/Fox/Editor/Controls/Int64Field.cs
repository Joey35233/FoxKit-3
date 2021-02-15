using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int64Field : TextValueField<System.Int64>
    {
        Int64Input integerInput => (Int64Input)textInputBase;

        protected override string ValueToString(System.Int64 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int64 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt64(v);
        }

        public Int64Field()
            : this((string)null) { }

        public Int64Field(int maxLength)
            : this(null, maxLength) { }

        public Int64Field(string label, int maxLength = -1)
            : base(label, maxLength, new Int64Input())
        {
            AddLabelDragger<System.Int64>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int64 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class Int64Input : TextValueInput
        {
            Int64Field parentIntegerField => (Int64Field)parent;

            internal Int64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int64 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt64(v);
                }
            }

            protected override string ValueToString(System.Int64 v)
            {
                return v.ToString(formatString);
            }

            protected override System.Int64 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt64(v);
            }
        }
    }
}
// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int32Field : TextValueField<System.Int32>
    {
        Int32Input integerInput => (Int32Input)textInputBase;

        protected override string ValueToString(System.Int32 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int32 StringToValue(string str)
        {
            long v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt32(v);
        }

        public Int32Field()
            : this((string)null) { }

        public Int32Field(int maxLength)
            : this(null, maxLength) { }

        public Int32Field(string label, int maxLength = -1)
            : base(label, maxLength, new Int32Input())
        {
            AddLabelDragger<System.Int32>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int32 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class Int32Input : TextValueInput
        {
            Int32Field parentIntegerField => (Int32Field)parent;

            internal Int32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int32 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                long v = StringToValue(text);
                v += (long)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt32(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt32(v);
                }
            }

            protected override string ValueToString(System.Int32 v)
            {
                return v.ToString(formatString);
            }

            protected override System.Int32 StringToValue(string str)
            {
                long v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt32(v);
            }
        }
    }
}
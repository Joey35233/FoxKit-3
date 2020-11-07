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
    public class Int8Field : TextValueField<System.SByte>
    {
        Int8Input integerInput => (Int8Input)textInputBase;

        protected override string ValueToString(System.SByte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.SByte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt8(v);
        }

        public Int8Field()
            : this((string)null) { }

        public Int8Field(int maxLength)
            : this(null, maxLength) { }

        public Int8Field(string label, int maxLength = -1)
            : base(label, maxLength, new Int8Input())
        {
            AddLabelDragger<System.SByte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class Int8Input : TextValueInput
        {
            Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt8(v);
                }
            }

            protected override string ValueToString(System.SByte v)
            {
                return v.ToString(formatString);
            }

            protected override System.SByte StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt8(v);
            }
        }
    }
}
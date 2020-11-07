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
    public class UInt64Field : TextValueField<System.UInt64>
    {
        UInt64Input integerInput => (UInt64Input)textInputBase;

        protected override string ValueToString(System.UInt64 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt64 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt64(v);
        }

        public UInt64Field()
            : this((string)null) { }

        public UInt64Field(int maxLength)
            : this(null, maxLength) { }

        public UInt64Field(string label, int maxLength = -1)
            : base(label, maxLength, new UInt64Input())
        {
            AddLabelDragger<System.UInt64>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class UInt64Input : TextValueInput
        {
            UInt64Field parentIntegerField => (UInt64Field)parent;

            internal UInt64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt64(v);
                }
            }

            protected override string ValueToString(System.UInt64 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt64 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt64(v);
            }
        }
    }
}
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
    public class UInt32Field : TextValueField<System.UInt32>
    {
        UInt32Input integerInput => (UInt32Input)textInputBase;

        protected override string ValueToString(System.UInt32 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt32 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt32(v);
        }

        public UInt32Field()
            : this((string)null) { }

        public UInt32Field(int maxLength)
            : this(null, maxLength) { }

        public UInt32Field(string label, int maxLength = -1)
            : base(label, maxLength, new UInt32Input())
        {
            AddLabelDragger<System.UInt32>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt32 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class UInt32Input : TextValueInput
        {
            UInt32Field parentIntegerField => (UInt32Field)parent;

            internal UInt32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt32 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt32(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt32(v);
                }
            }

            protected override string ValueToString(System.UInt32 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt32 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt32(v);
            }
        }
    }
}
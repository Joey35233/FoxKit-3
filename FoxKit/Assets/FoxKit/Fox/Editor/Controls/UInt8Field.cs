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
    public class UInt8Field : TextValueField<System.Byte>
    {
        UInt8Input integerInput => (UInt8Input)textInputBase;

        protected override string ValueToString(System.Byte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Byte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt8(v);
        }

        public UInt8Field()
            : this((string)null) { }

        public UInt8Field(int maxLength)
            : this(null, maxLength) { }

        public UInt8Field(string label, int maxLength = -1)
            : base(label, maxLength, new UInt8Input())
        {
            AddLabelDragger<System.Byte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Byte startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class UInt8Input : TextValueInput
        {
            UInt8Field parentIntegerField => (UInt8Field)parent;

            internal UInt8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Byte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt8(v);
                }
            }

            protected override string ValueToString(System.Byte v)
            {
                return v.ToString(formatString);
            }

            protected override System.Byte StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt8(v);
            }
        }
    }
}
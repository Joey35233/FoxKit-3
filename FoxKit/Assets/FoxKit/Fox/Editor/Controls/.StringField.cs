// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class StringField : TextValueField<String>
    {
        StringInput integerInput => (StringInput)textInputBase;

        protected override string ValueToString(String v)
        {
            //return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

            return (v.CString() == null) ? "" : v.CString();
        }

        protected override String StringToValue(string str)
        {
            //System.Numerics.BigInteger v;
            //ExpressionEvaluator.Evaluate(str, out v);
            //return NumericPropertyDrawers.ClampToUInt64(v);

            StrCode hash;
            if (str.ToLower().StartsWith("0x") && StrCode.TryParse(str, out hash))
                return new String(hash);
            else
                return new String(str);
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, String startValue) { }

        public StringField()
            : this((string)null) { }

        public StringField(int maxLength)
            : this(null, maxLength) { }

        public StringField(string label, int maxLength = -1)
            : base(label, maxLength, new StringInput())
        {
            //AddLabelDragger<System.UInt64>();
        }

        class StringInput : TextValueInput
        {
            StringField parentIntegerField => (StringField)parent;

            internal StringInput()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => "01234567890abcdefghijklmnopqrstuvwxyz/._";

            protected override string ValueToString(String v)
            {
                // return v.ToString(formatString);

                return (v.CString() == null) ? "" : v.CString();
            }

            protected override String StringToValue(string str)
            {
                //System.Numerics.BigInteger v;
                //ExpressionEvaluator.Evaluate(str, out v);
                //return NumericPropertyDrawers.ClampToUInt64(v);

                StrCode hash;
                if (str.ToLower().StartsWith("0x") && StrCode.TryParse(str, out hash))
                    return new String(hash);
                else
                    return new String(str);
            }

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, String startValue)
            {
            }
        }
    }
}
using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt64Field : TextValueField<ulong>, IFoxField
    {
        private UInt64Input integerInput => (UInt64Input)textInputBase;

        protected override string ValueToString(ulong v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override ulong StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToULong(str, out ulong v);
            return success ? v : rawValue;
        }

        public static new readonly string ussClassName = "fox-uint64-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt64Field()
            : this(label: null)
        {
        }
        
        public UInt64Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public UInt64Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public UInt64Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt64Input())
        {
        }

        private UInt64Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<ulong>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class UInt64Input : TextValueInput
        {
            private UInt64Field parentIntegerField => (UInt64Field)parent;

            internal UInt64Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                ulong v = StringToValue(text);
                
                long niceDelta = (long)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);

                v = ClampToMinMaxULongValue(niceDelta, v);
                
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(v);
                }
                else
                {
                    parentIntegerField.value = v;
                }
            }
            
            private ulong ClampToMinMaxULongValue(long niceDelta, ulong value)
            {
                var niceDeltaAbs = (ulong)System.Math.Abs(niceDelta);

                if (niceDelta > 0)
                {
                    if (niceDeltaAbs > ulong.MaxValue - value)
                    {
                        return ulong.MaxValue;
                    }

                    return value + niceDeltaAbs;
                }

                if (niceDeltaAbs > value)
                {
                    return ulong.MinValue;
                }

                return value - niceDeltaAbs;
            }

            protected override string ValueToString(ulong v) => v.ToString(formatString);

            protected override ulong StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
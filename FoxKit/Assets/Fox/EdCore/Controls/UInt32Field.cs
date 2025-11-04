using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt32Field : TextValueField<uint>, IFoxField
    {
        private UInt32Input integerInput => (UInt32Input)textInputBase;

        protected override string ValueToString(uint v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override uint StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToUInt(str, out uint v);
            return success ? v : rawValue;
        }

        public static new readonly string ussClassName = "fox-uint32-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt32Field()
            : this(label: null)
        {
        }
        
        public UInt32Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public UInt32Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public UInt32Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt32Input())
        {
        }

        private UInt32Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<uint>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, uint startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class UInt32Input : TextValueInput
        {
            private UInt32Field parentIntegerField => (UInt32Field)parent;

            internal UInt32Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, uint startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                long v = StringToValue(text);
                v += (long)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt32(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt32(v);
                }
            }

            protected override string ValueToString(uint v) => v.ToString(formatString);

            protected override uint StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class PositiveInt32Field : TextValueField<int>, IFoxField
    {
        private PositiveInt32Input integerInput => (PositiveInt32Input)textInputBase;

        protected override string ValueToString(int v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override int StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToInt(str, out int v);

            int result = success ? v : rawValue;

            result = result < 0 ? 0 : result;

            return result;
        }

        public static new readonly string ussClassName = "fox-int32-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public PositiveInt32Field()
            : this(label: null)
        {
        }
        
        public PositiveInt32Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public PositiveInt32Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public PositiveInt32Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new PositiveInt32Input())
        {
        }

        private PositiveInt32Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<int>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class PositiveInt32Input : TextValueInput
        {
            private PositiveInt32Field parentIntegerField => (PositiveInt32Field)parent;

            internal PositiveInt32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                long v = StringToValue(text);
                v += (long)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);

                int value = NumericPropertyFields.ClampToInt32(v);
                value = value < 0 ? 0 : value;
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(value);
                }
                else
                {
                    parentIntegerField.value = value;
                }
            }

            protected override string ValueToString(int v) => v.ToString(formatString);

            protected override int StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
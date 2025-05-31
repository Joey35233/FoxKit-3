using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int8Field : TextValueField<sbyte>, INotifyValueChanged<int>, IFoxField
    {
        public override sbyte value
        {
            get => base.value;
            set
            {
                sbyte oldValue = this.value;
                sbyte newValue = value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(oldValue, newValue))
                        {
                            evt.target = this;
                            SendEvent(evt);
                        }
                    }
                    else
                    {
                        SetValueWithoutNotify(newValue);
                    }
                }
            }
        }
        int INotifyValueChanged<int>.value
        {
            get => value;
            set
            {
                sbyte oldValue = this.value;
                sbyte newValue = (sbyte)value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(oldValue, newValue))
                        {
                            evt.target = this;
                            SendEvent(evt);
                        }
                    }
                    else
                    {
                        SetValueWithoutNotify(newValue);
                    }
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int newValue) => throw new NotImplementedException();

        private Int8Input integerInput => (Int8Input)textInputBase;

        protected override string ValueToString(sbyte v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override sbyte StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToInt(str, out int v);
            return NumericPropertyFields.ClampToInt8(success ? v : rawValue);
        }

        public static new readonly string ussClassName = "fox-int8-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int8Field()
            : this(label: null)
        {
        }
        
        public Int8Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public Int8Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public Int8Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int8Input())
        {
        }

        private Int8Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<sbyte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, sbyte startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class Int8Input : TextValueInput
        {
            private Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, sbyte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt8(v);
                }
            }

            protected override string ValueToString(sbyte v) => v.ToString(formatString);

            protected override sbyte StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
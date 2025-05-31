using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt8Field : TextValueField<byte>, INotifyValueChanged<uint>, IFoxField
    {
        public override byte value
        {
            get => base.value;
            set
            {
                byte oldValue = this.value;
                byte newValue = value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.Byte> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<uint>.GetPooled(oldValue, newValue))
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
        uint INotifyValueChanged<uint>.value
        {
            get => value;
            set
            {
                byte oldValue = this.value;
                byte newValue = (byte)value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.Byte> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<uint>.GetPooled(oldValue, newValue))
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
        void INotifyValueChanged<uint>.SetValueWithoutNotify(uint newValue) => throw new NotImplementedException();

        private UInt8Input integerInput => (UInt8Input)textInputBase;

        protected override string ValueToString(byte v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override byte StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToUInt(str, out uint v);
            return NumericPropertyFields.ClampToUInt8(success ? v : rawValue);
        }

        public static new readonly string ussClassName = "fox-uint8-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt8Field()
            : this(label: null)
        {
        }
        
        public UInt8Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public UInt8Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public UInt8Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt8Input())
        {
        }

        private UInt8Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<byte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, byte startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class UInt8Input : TextValueInput
        {
            private UInt8Field parentIntegerField => (UInt8Field)parent;

            internal UInt8Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, byte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt8(v);
                }
            }

            protected override string ValueToString(byte v) => v.ToString(formatString);

            protected override byte StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
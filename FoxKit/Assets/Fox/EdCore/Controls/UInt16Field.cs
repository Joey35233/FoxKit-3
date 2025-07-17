using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt16Field : TextValueField<ushort>, INotifyValueChanged<uint>, IFoxField
    {
        public override ushort value
        {
            get => base.value;
            set
            {
                ushort oldValue = this.value;
                ushort newValue = value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
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
                ushort oldValue = this.value;
                ushort newValue = (ushort)value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
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

        private UInt16Input integerInput => (UInt16Input)textInputBase;

        protected override string ValueToString(ushort v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override ushort StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToUInt(str, out uint v);
            return NumericPropertyFields.ClampToUInt16(success ? v : rawValue);
        }

        public static new readonly string ussClassName = "fox-uint16-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt16Field()
            : this(label: null)
        {
        }
        
        public UInt16Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public UInt16Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public UInt16Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt16Input())
        {
        }

        private UInt16Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<ushort>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ushort startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class UInt16Input : TextValueInput
        {
            private UInt16Field parentIntegerField => (UInt16Field)parent;

            internal UInt16Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ushort startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt16(v);
                }
            }

            protected override string ValueToString(ushort v) => v.ToString(formatString);

            protected override ushort StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
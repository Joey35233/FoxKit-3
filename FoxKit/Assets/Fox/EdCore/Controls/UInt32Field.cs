using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt32Field : TextValueField<uint>, INotifyValueChanged<int>, IFoxField
    {
        public override uint value
        {
            get => base.value;
            set
            {
                uint newValue = value;
                int packedNewValue = unchecked((int)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.UInt32> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(packedOldValue, packedNewValue))
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
            get => unchecked((int)value);
            set
            {
                uint newValue = unchecked((uint)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.UInt32> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(packedOldValue, value))
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

        private UInt32Input integerInput => (UInt32Input)textInputBase;

        protected override string ValueToString(uint v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override uint StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
            return NumericPropertyFields.ClampToUInt32(v);
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
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, uint startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
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

            protected override uint StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
                return NumericPropertyFields.ClampToUInt32(v);
            }
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
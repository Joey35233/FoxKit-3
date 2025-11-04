using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int16Field : TextValueField<short>, INotifyValueChanged<int>, IFoxField
    {
        public override short value
        {
            get => base.value;
            set
            {
                short oldValue = this.value;
                short newValue = value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
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
                short oldValue = this.value;
                short newValue = (short)value;
                if (newValue != oldValue)
                {
                    if (panel != null)
                    {
                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
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

        private Int16Input integerInput => (Int16Input)textInputBase;

        protected override string ValueToString(short v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override short StringToValue(string str)
        {
            bool success = NumericPropertyFields.TryConvertStringToInt(str, out int v);
            return NumericPropertyFields.ClampToInt16(success ? v : rawValue);
        }

        public static new readonly string ussClassName = "fox-int16-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int16Field()
            : this(label: null)
        {
        }
        
        public Int16Field(bool hasDragger)
            : this(label: null, hasDragger)
        {
        }
        
        public Int16Field(PropertyInfo propertyInfo, bool hasDragger = true, int maxLength = -1)
            : this(propertyInfo.Name, hasDragger, maxLength)
        {
        }

        public Int16Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int16Input())
        {
        }

        private Int16Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<short>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, short startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        private class Int16Input : TextValueInput
        {
            private Int16Field parentIntegerField => (Int16Field)parent;

            internal Int16Input()
            {
                formatString = NumericPropertyFields.IntegerFieldFormatString;
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, short startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt16(v);
                }
            }

            protected override string ValueToString(short v) => v.ToString(formatString);

            protected override short StringToValue(string str) => parentIntegerField.StringToValue(str);
        }
        
        public void SetLabel(string label) => this.label = label;
        public Label GetLabelElement() => this.labelElement;
    }
}
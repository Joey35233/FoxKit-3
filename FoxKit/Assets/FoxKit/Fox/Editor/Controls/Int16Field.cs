using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int16Field : TextValueField<System.Int16>, INotifyValueChanged<int>
    {
        System.Int16 _value;
        int INotifyValueChanged<int>.value
        {
            get
            {
                this.value = _value;
                return _value;
            }
            set
            {
                if (_value == value)
                {
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    return;
                }

                using (ChangeEvent<int> valueChangeEvent = ChangeEvent<int>.GetPooled((int)_value, value))
                {
                    valueChangeEvent.target = this;
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    SetValueWithoutNotify((System.Int16)value);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _value = (System.Int16)val;
        }

        public override void SetValueWithoutNotify(System.Int16 newValue)
        {
            ((INotifyValueChanged<int>)this).value = newValue;

            base.SetValueWithoutNotify(newValue);
        }

        Int16Input integerInput => (Int16Input)textInputBase;

        protected override string ValueToString(System.Int16 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int16 StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt16(v);
        }

        public Int16Field()
            : this((string)null) { }

        public Int16Field(int maxLength)
            : this(null, maxLength) { }

        public Int16Field(string label, int maxLength = -1)
            : base(label, maxLength, new Int16Input())
        {
            AddLabelDragger<System.Int16>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int16 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class Int16Input : TextValueInput
        {
            Int16Field parentIntegerField => (Int16Field)parent;

            internal Int16Input()
            {
                formatString = "##0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int16 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt16(v);
                }
            }

            protected override string ValueToString(System.Int16 v)
            {
                return v.ToString(formatString);
            }

            protected override System.Int16 StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt16(v);
            }
        }
    }
}
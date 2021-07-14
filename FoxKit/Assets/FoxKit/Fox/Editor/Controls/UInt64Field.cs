using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt64Field : TextValueField<System.UInt64>, INotifyValueChanged<int>
    {
        System.UInt64 _value;
        int INotifyValueChanged<int>.value
        {
            get
            {
                this.value = _value;
                return (int)_value;
            }
            set
            {
                if (serializedObject == null)
                    return;

                if (_value == (System.UInt64)serializedObject.FindProperty(bindingPath).longValue)
                {
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    return;
                }
                
                // This is complete nonsense. The point is to make sure that when both are cast to int, that they are not the same value.
                using (ChangeEvent<int> valueChangeEvent = ChangeEvent<int>.GetPooled((int)_value - 1, (int)_value))
                {
                    valueChangeEvent.target = this;
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    long longVal = serializedObject.FindProperty(bindingPath).longValue;
                    ulong ulongVal = (ulong)longVal;
                    SetValueWithoutNotify(ulongVal);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            if (serializedObject == null)
                return;

            long longVal = serializedObject.FindProperty(bindingPath).longValue;
            ulong ulongVal = (ulong)longVal;
            _value = ulongVal;
        }

        public override void SetValueWithoutNotify(System.UInt64 newValue)
        {
            if (serializedObject == null)
                return;

            //((INotifyValueChanged<int>)this).value = (int)newValue;
            serializedObject.FindProperty(bindingPath).SetValue(newValue);
            serializedObject.ApplyModifiedProperties();

            base.SetValueWithoutNotify(newValue);
        }

        UInt64Input integerInput => (UInt64Input)textInputBase;

        protected override string ValueToString(System.UInt64 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt64 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt64(v);
        }

        public UInt64Field()
            : this((string)null) { }

        public UInt64Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt64Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new UInt64Input())
        {
            if (hasDragger)
                AddLabelDragger<System.UInt64>();
        }

        SerializedObject serializedObject;
        public void PreBindProperty(SerializedProperty property)
        {
            serializedObject = property.serializedObject;
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class UInt64Input : TextValueInput
        {
            UInt64Field parentIntegerField => (UInt64Field)parent;

            internal UInt64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt64(v);
                }
            }

            protected override string ValueToString(System.UInt64 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt64 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt64(v);
            }
        }
    }
}
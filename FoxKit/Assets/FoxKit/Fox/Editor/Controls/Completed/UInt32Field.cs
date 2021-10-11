using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt32Field : TextValueField<System.UInt32>, INotifyValueChanged<int>, IFoxNumericField
    {
        System.UInt32 _value;
        int INotifyValueChanged<int>.value
        {
            get
            {
                this.value = _value;
                return (int)_value;
            }
            set
            {
                if (_value == (uint)value)
                {
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    return;
                }

                using (ChangeEvent<int> valueChangeEvent = ChangeEvent<int>.GetPooled((int)_value, value))
                {
                    valueChangeEvent.target = this;
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    SetValueWithoutNotify((System.UInt32)value);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _value = (System.UInt32)val;
        }

        public override void SetValueWithoutNotify(System.UInt32 newValue)
        {
            ((INotifyValueChanged<int>)this).value = (int)newValue;

            base.SetValueWithoutNotify(newValue);
        }

        UInt32Input integerInput => (UInt32Input)textInputBase;

        protected override string ValueToString(System.UInt32 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt32 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt32(v);
        }

        public static readonly string ussBaseClassName = "fox-base-field";
        public new static readonly string ussClassName = "fox-uint32-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public UInt32Field()
            : this((string)null) { }

        public UInt32Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt32Field(bool hasDragger)
            : this(null, hasDragger) { }

        public UInt32Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new UInt32Input())
        {
            AddToClassList(ussBaseClassName);
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.UInt32>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt32 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public void BindProperty(SerializedProperty property, string label)
        {
            this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        class UInt32Input : TextValueInput
        {
            UInt32Field parentIntegerField => (UInt32Field)parent;

            internal UInt32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt32 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt32(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt32(v);
                }
            }

            protected override string ValueToString(System.UInt32 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt32 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt32(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.UInt32))]
    public class UInt32Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new UInt32Field();
            field.BindProperty(property);

            return field;
        }
    }
}
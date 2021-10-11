using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt8Field : TextValueField<System.Byte>, INotifyValueChanged<int>, IFoxNumericField
    {
        System.Byte _value;
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
                    SetValueWithoutNotify((System.Byte)value);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _value = (System.Byte)val;
        }

        public override void SetValueWithoutNotify(System.Byte newValue)
        {
            ((INotifyValueChanged<int>)this).value = newValue;

            base.SetValueWithoutNotify(newValue);
        }

        UInt8Input integerInput => (UInt8Input)textInputBase;

        protected override string ValueToString(System.Byte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Byte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt8(v);
        }

        public static readonly string ussBaseClassName = "fox-base-field";
        public new static readonly string ussClassName = "fox-uint8-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public UInt8Field()
            : this((string)null) { }

        public UInt8Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt8Field(bool hasDragger)
            : this(null, hasDragger) { }

        public UInt8Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new UInt8Input())
        {
            AddToClassList(ussBaseClassName);
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            this.styleSheets.Add(FoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.Byte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Byte startValue)
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

        class UInt8Input : TextValueInput
        {
            UInt8Field parentIntegerField => (UInt8Field)parent;

            internal UInt8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Byte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt8(v);
                }
            }

            protected override string ValueToString(System.Byte v)
            {
                return v.ToString(formatString);
            }

            protected override System.Byte StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt8(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.Byte))]
    public class UInt8Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private UInt8Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new UInt8Field(property.name);
            field.BindProperty(property);

            return field;
        }
    }
}
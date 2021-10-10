using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt16Field : TextValueField<System.UInt16>, INotifyValueChanged<int>, IFoxNumericField
    {
        System.UInt16 _value;
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
                    SetValueWithoutNotify((System.UInt16)value);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _value = (System.UInt16)val;
        }

        public override void SetValueWithoutNotify(System.UInt16 newValue)
        {
            ((INotifyValueChanged<int>)this).value = newValue;

            base.SetValueWithoutNotify(newValue);
        }

        UInt16Input integerInput => (UInt16Input)textInputBase;

        protected override string ValueToString(System.UInt16 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt16 StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToUInt16(v);
        }

        public UInt16Field()
            : this((string)null) { }

        public UInt16Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt16Field(bool hasDragger)
            : this(null, hasDragger) { }

        public UInt16Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new UInt16Input())
        {
            labelElement.AddToClassList("unity-property-field__label");
            styleSheets.Add(FoxField.FoxFieldStyleSheet);

            if (hasDragger)
                AddLabelDragger<System.UInt16>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt16 startValue)
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
            labelElement.AddToClassList("unity-property-field__label");
        }

        class UInt16Input : TextValueInput
        {
            UInt16Field parentIntegerField => (UInt16Field)parent;

            internal UInt16Input()
            {
                formatString = "##0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt16 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToUInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToUInt16(v);
                }
            }

            protected override string ValueToString(System.UInt16 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt16 StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToUInt16(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.UInt16))]
    public class UInt16Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private UInt16Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new UInt16Field(property.name);
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}
﻿using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlUInt8AttributeDescription : TypedUxmlAttributeDescription<byte>
    {
        public UxmlUInt8AttributeDescription()
        {
            type = "uint8";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override byte GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt8(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref byte value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt8(s, i), defaultValue, ref value);
        }

        static byte ConvertValueToUInt8(string v, byte defaultValue)
        {
            byte l;
            if (v == null || !Byte.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class UInt8Field : TextValueField<System.Byte>, INotifyValueChanged<int>, IFoxField
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

        public new class UxmlFactory : UxmlFactory<UInt8Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.Byte, UxmlUInt8AttributeDescription> { }

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

        public new static readonly string ussClassName = "fox-uint8-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public UInt8Field()
            : this((string)null) { }

        public UInt8Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt8Field(bool hasDragger)
            : this(null, hasDragger) { }

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
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
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

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.Byte>.alignedFieldUssClassName);

            return field;
        }
    }
}
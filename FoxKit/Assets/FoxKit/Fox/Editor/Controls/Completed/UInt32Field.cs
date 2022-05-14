using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlUInt32AttributeDescription : TypedUxmlAttributeDescription<uint>
    {
        public UxmlUInt32AttributeDescription()
        {
            type = "uint32";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override uint GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt32(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref uint value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt32(s, i), defaultValue, ref value);
        }

        static uint ConvertValueToUInt32(string v, uint defaultValue)
        {
            uint l;
            if (v == null || !UInt32.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class UInt32Field : TextValueField<System.UInt32>, INotifyValueChanged<int>, IFoxField
    {
        System.UInt32 _unsignedValue;
        int INotifyValueChanged<int>.value
        {
            get
            {
                this.value = _unsignedValue;
                return unchecked((int)_unsignedValue);
            }
            set
            {
                if (_unsignedValue == unchecked((uint)value))
                {
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    return;
                }

                using (ChangeEvent<int> valueChangeEvent = ChangeEvent<int>.GetPooled(unchecked((int)_unsignedValue), value))
                {
                    valueChangeEvent.target = this;
                    ((INotifyValueChanged<int>)this).SetValueWithoutNotify(value);
                    SetValueWithoutNotify(unchecked((System.UInt32)value));
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _unsignedValue = unchecked((System.UInt32)val);
        }

        public override void SetValueWithoutNotify(System.UInt32 newValue)
        {
            ((INotifyValueChanged<int>)this).value = unchecked((int)newValue);

            base.SetValueWithoutNotify(newValue);
        }

        UInt32Input integerInput => (UInt32Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<UInt32Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.UInt32, UxmlUInt32AttributeDescription> { }

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

        public new static readonly string ussClassName = "fox-uint32-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public UInt32Field()
            : this((string)null) { }

        public UInt32Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt32Field(bool hasDragger)
            : this(null, hasDragger) { }

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
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
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

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
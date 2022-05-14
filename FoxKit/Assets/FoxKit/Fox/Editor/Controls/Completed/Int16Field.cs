using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlInt16AttributeDescription : TypedUxmlAttributeDescription<short>
    {
        public UxmlInt16AttributeDescription()
        {
            type = "int16";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override short GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToInt16(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref short value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToInt16(s, i), defaultValue, ref value);
        }

        static short ConvertValueToInt16(string v, short defaultValue)
        {
            short l;
            if (v == null || !Int16.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class Int16Field : TextValueField<System.Int16>, INotifyValueChanged<int>, IFoxField
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

        public new class UxmlFactory : UxmlFactory<Int16Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.Int16, UxmlInt16AttributeDescription> { }

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

        public new static readonly string ussClassName = "fox-int16-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public Int16Field()
            : this((string)null) { }

        public Int16Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int16Field(bool hasDragger)
            : this(null, hasDragger) { }

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
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.Int16>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int16 startValue)
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

    [CustomPropertyDrawer(typeof(System.Int16))]
    public class Int16Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private Int16Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new Int16Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
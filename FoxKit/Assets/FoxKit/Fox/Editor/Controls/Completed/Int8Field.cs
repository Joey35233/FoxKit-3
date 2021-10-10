using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlInt8AttributeDescription : TypedUxmlAttributeDescription<sbyte>
    {
        public UxmlInt8AttributeDescription()
        {
            type = "int8";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override sbyte GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToInt8(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref sbyte value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToInt8(s, i), defaultValue, ref value);
        }

        static sbyte ConvertValueToInt8(string v, sbyte defaultValue)
        {
            sbyte l;
            if (v == null || !SByte.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class Int8Field : TextValueField<System.SByte>, INotifyValueChanged<int>, IFoxNumericField
    {
        System.SByte _value;
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
                    SetValueWithoutNotify((System.SByte)value);
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            _value = (System.SByte)val;
        }

        public override void SetValueWithoutNotify(System.SByte newValue)
        {
            ((INotifyValueChanged<int>)this).value = newValue;

            base.SetValueWithoutNotify(newValue);
        }

        Int8Input integerInput => (Int8Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<Int8Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.SByte, UxmlInt8AttributeDescription> {}

        protected override string ValueToString(System.SByte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.SByte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt8(v);
        }

        public new static readonly string ussClassName = "fox-int8-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public Int8Field()
            : this((string)null) { }

        public Int8Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int8Field(bool hasDragger)
            : this(null, hasDragger) { }

        public Int8Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new Int8Input())
        {
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);

            if (hasDragger)
                AddLabelDragger<System.SByte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
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

        class Int8Input : TextValueInput
        {
            Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt8(v);
                }
            }

            protected override string ValueToString(System.SByte v)
            {
                return v.ToString(formatString);
            }

            protected override System.SByte StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt8(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.SByte))]
    public class Int8Drawer : PropertyDrawer
    {
        private SerializedProperty property;
        private Int8Field field;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            this.property = property;

            field = new Int8Field(property.name);
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}
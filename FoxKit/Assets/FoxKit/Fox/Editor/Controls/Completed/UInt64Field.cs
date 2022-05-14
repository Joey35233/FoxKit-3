using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlUInt64AttributeDescription : TypedUxmlAttributeDescription<ulong>
    {
        public UxmlUInt64AttributeDescription()
        {
            type = "uint64";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override ulong GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt64(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref ulong value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToUInt64(s, i), defaultValue, ref value);
        }

        static ulong ConvertValueToUInt64(string v, ulong defaultValue)
        {
            ulong l;
            if (v == null || !UInt64.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class UInt64Field : TextValueField<System.UInt64>, INotifyValueChanged<long>, IFoxField
    {
        System.UInt64 _unsignedValue;
        long INotifyValueChanged<long>.value
        {
            get
            {
                this.value = _unsignedValue;
                return unchecked((long)_unsignedValue);
            }
            set
            {
                if (_unsignedValue == unchecked((ulong)value))
                {
                    ((INotifyValueChanged<long>)this).SetValueWithoutNotify(value);
                    return;
                }

                using (ChangeEvent<long> valueChangeEvent = ChangeEvent<long>.GetPooled(unchecked((long)_unsignedValue), value))
                {
                    valueChangeEvent.target = this;
                    ((INotifyValueChanged<long>)this).SetValueWithoutNotify(value);
                    SetValueWithoutNotify(unchecked((System.UInt64)value));
                    SendEvent(valueChangeEvent);
                }
            }
        }
        void INotifyValueChanged<long>.SetValueWithoutNotify(long val)
        {
            _unsignedValue = unchecked((System.UInt64)val);
        }

        public override void SetValueWithoutNotify(System.UInt64 newValue)
        {
            ((INotifyValueChanged<long>)this).value = unchecked((long)newValue);

            base.SetValueWithoutNotify(newValue);
        }

        UInt64Input integerInput => (UInt64Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<UInt64Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.UInt64, UxmlUInt64AttributeDescription> { }

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

        public new static readonly string ussClassName = "fox-uint64-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public UInt64Field()
            : this((string)null) { }

        public UInt64Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt64Field(bool hasDragger)
            : this(null, hasDragger) { }

        public UInt64Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt64Input())
        {
        }

        private UInt64Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
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

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, property.name);
        }

        public void BindProperty(SerializedProperty property, string label)
        {
            this.label = label;
            BindingExtensions.BindProperty(this, property);
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

    [CustomPropertyDrawer(typeof(System.UInt64))]
    public class UInt64Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new UInt64Field();
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
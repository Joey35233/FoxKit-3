using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlInt64AttributeDescription : TypedUxmlAttributeDescription<long>
    {
        public UxmlInt64AttributeDescription()
        {
            type = "int64";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override long GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToInt64(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref long value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToInt64(s, i), defaultValue, ref value);
        }

        static long ConvertValueToInt64(string v, long defaultValue)
        {
            long l;
            if (v == null || !Int64.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class Int64Field : TextValueField<System.Int64>, IFoxField
    {
        Int64Input integerInput => (Int64Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<Int64Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.Int64, UxmlInt64AttributeDescription> { }

        protected override string ValueToString(System.Int64 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int64 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt64(v);
        }

        public new static readonly string ussClassName = "fox-int64-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public Int64Field()
            : this((string)null) { }

        public Int64Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int64Field(bool hasDragger)
            : this(null, hasDragger) { }

        public Int64Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int64Input())
        {
        }

        private Int64Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.Int64>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int64 startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        public void BindProperty(SerializedProperty property)
        {
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        class Int64Input : TextValueInput
        {
            Int64Field parentIntegerField => (Int64Field)parent;

            internal Int64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int64 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt64(v);
                }
            }

            protected override string ValueToString(System.Int64 v)
            {
                return v.ToString(formatString);
            }

            protected override System.Int64 StringToValue(string str)
            {
                System.Numerics.BigInteger v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyDrawers.ClampToInt64(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.Int64))]
    public class Int64Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Int64Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
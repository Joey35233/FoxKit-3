using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UxmlInt32AttributeDescription : TypedUxmlAttributeDescription<int>
    {
        public UxmlInt32AttributeDescription()
        {
            type = "int32";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        public override int GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToInt32(s, i), defaultValue);
        }

        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref int value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToInt32(s, i), defaultValue, ref value);
        }

        static int ConvertValueToInt32(string v, int defaultValue)
        {
            int l;
            if (v == null || !Int32.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class Int32Field : TextValueField<System.Int32>, IFoxField, ICustomBindable
    {
        Int32Input integerInput => (Int32Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<Int32Field, UxmlTraits> {}
        public new class UxmlTraits : TextValueFieldTraits<System.Int32, UxmlInt32AttributeDescription> {}

        protected override string ValueToString(System.Int32 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int32 StringToValue(string str)
        {
            long v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyFields.ClampToInt32(v);
        }

        public new static readonly string ussClassName = "fox-int32-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public Int32Field()
            : this((string)null) { }

        public Int32Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int32Field(bool hasDragger)
            : this(null, hasDragger) { }

        public Int32Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int32Input())
        {
        }

        private Int32Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.Int32>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int32 startValue)
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

        class Int32Input : TextValueInput
        {
            Int32Field parentIntegerField => (Int32Field)parent;

            internal Int32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int32 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                long v = StringToValue(text);
                v += (long)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt32(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt32(v);
                }
            }

            protected override string ValueToString(System.Int32 v)
            {
                return v.ToString(formatString);
            }

            protected override System.Int32 StringToValue(string str)
            {
                long v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyFields.ClampToInt32(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.Int32))]
    public class Int32Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Int32Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
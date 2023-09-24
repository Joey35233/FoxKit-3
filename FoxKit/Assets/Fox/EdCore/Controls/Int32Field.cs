using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int32Field : TextValueField<int>, IFoxField, ICustomBindable
    {
        private Int32Input integerInput => (Int32Input)textInputBase;

        protected override string ValueToString(int v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override int StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out long v);
            return NumericPropertyFields.ClampToInt32(v);
        }

        public static new readonly string ussClassName = "fox-int32-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int32Field()
            : this(null) { }

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
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<int>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class Int32Input : TextValueInput
        {
            private Int32Field parentIntegerField => (Int32Field)parent;

            internal Int32Input()
            {
                formatString = "#######0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue)
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

            protected override string ValueToString(int v) => v.ToString(formatString);

            protected override int StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out long v);
                return NumericPropertyFields.ClampToInt32(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(int))]
    public class Int32Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Int32Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<ulong>.alignedFieldUssClassName);

            return field;
        }
    }
}
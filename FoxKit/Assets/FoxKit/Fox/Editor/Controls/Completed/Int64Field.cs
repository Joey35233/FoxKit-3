using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int64Field : TextValueField<System.Int64>, IFoxNumericField
    {
        Int64Input integerInput => (Int64Input)textInputBase;

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

        public Int64Field()
            : this((string)null) { }

        public Int64Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int64Field(bool hasDragger)
            : this(null, hasDragger) { }

        public Int64Field(string label, bool hasDragger = true, int maxLength = -1)
            : base(label, maxLength, new Int64Input())
        {
            if (hasDragger)
                AddLabelDragger<System.Int64>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int64 startValue)
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
            var field = new Int64Field();
            field.BindProperty(property);
            field.styleSheets.Add(FoxField.FoxFieldStyleSheet);

            return field;
        }
    }
}
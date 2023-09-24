using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class FloatField : TextValueField<float>, IFoxField, ICustomBindable
    {
        private FloatInput floatInput => (FloatInput)textInputBase;

        protected override string ValueToString(float v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override float StringToValue(string str)
        {
            _ = NumericPropertyFields.StringToDouble(str, out double v);
            return NumericPropertyFields.ClampToFloat(v);
        }

        public static new readonly string ussClassName = "fox-float-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public FloatField() : this(null) { }

        public FloatField(int maxLength)
            : this(null, true, maxLength) { }

        public FloatField(bool hasDragger)
            : this(null, hasDragger) { }

        public FloatField(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new FloatInput())
        {
        }

        private FloatField(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<float>();
        }

        //internal override bool CanTryParse(string textString) => float.TryParse(textString, out _);

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue) => floatInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class FloatInput : TextValueInput
        {
            private FloatField parentFloatField => (FloatField)parent;

            internal FloatInput()
            {
                formatString = "g7";
            }

            protected override string allowedCharacters => NumericPropertyFields.FloatExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                double v = StringToValue(text);
                v += NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity;
                v = NumericPropertyFields.RoundBasedOnMinimumDifference(v, sensitivity);
                if (parentFloatField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToFloat(v));
                }
                else
                {
                    parentFloatField.value = NumericPropertyFields.ClampToFloat(v);
                }
            }

            protected override string ValueToString(float v) => v.ToString(formatString);

            protected override float StringToValue(string str)
            {
                _ = NumericPropertyFields.StringToDouble(str, out double v);
                return NumericPropertyFields.ClampToFloat(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(float))]
    public class FloatDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FloatField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<float>.alignedFieldUssClassName);

            return field;
        }
    }
}
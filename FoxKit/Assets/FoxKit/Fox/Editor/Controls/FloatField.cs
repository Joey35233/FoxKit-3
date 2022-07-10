using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Globalization;
using UnityEngine;

namespace Fox.Editor
{
    public class FloatField : TextValueField<float>, IFoxField
    {
        FloatInput floatInput => (FloatInput)textInputBase;

        public new class UxmlFactory : UxmlFactory<FloatField, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<float, UxmlFloatAttributeDescription> { }

        protected override string ValueToString(float v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override float StringToValue(string str)
        {
            double v;
            NumericPropertyDrawers.StringToDouble(str, out v);
            return NumericPropertyDrawers.ClampToFloat(v);
        }

        public new static readonly string ussClassName = "fox-float-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public FloatField() : this((string)null) { }

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
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<float>();
        }

        //internal override bool CanTryParse(string textString) => float.TryParse(textString, out _);

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
        {
            floatInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        //public void BindProperty(SerializedProperty property)
        //{
        //    BindProperty(property, null);
        //}
        //public void BindProperty(SerializedProperty property, string label)
        //{
        //    if (label is not null)
        //        this.label = label;
        //    BindingExtensions.BindProperty(this, property);
        //}

        class FloatInput : TextValueInput
        {
            FloatField parentFloatField => (FloatField)parent;

            internal FloatInput()
            {
                formatString = "g7";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.FloatExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                double v = StringToValue(text);
                v += NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity;
                v = NumericPropertyDrawers.RoundBasedOnMinimumDifference(v, sensitivity);
                if (parentFloatField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToFloat(v));
                }
                else
                {
                    parentFloatField.value = NumericPropertyDrawers.ClampToFloat(v);
                }
            }

            protected override string ValueToString(float v)
            {
                return v.ToString(formatString);
            }

            protected override float StringToValue(string str)
            {
                double v;
                NumericPropertyDrawers.StringToDouble(str, out v);
                return NumericPropertyDrawers.ClampToFloat(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.Single))]
    public class FloatDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new FloatField(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.Single>.alignedFieldUssClassName);

            return field;
        }
    }
}
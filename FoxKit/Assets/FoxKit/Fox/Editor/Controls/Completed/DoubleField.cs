using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Globalization;
using UnityEngine;

namespace Fox.Editor
{
    public class DoubleField : TextValueField<double>, IFoxField
    {
        DoubleInput doubleInput => (DoubleInput)textInputBase;

        public new class UxmlFactory : UxmlFactory<DoubleField, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<double, UxmlDoubleAttributeDescription> { }


        protected override string ValueToString(double v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }


        protected override double StringToValue(string str)
        {
            double v;
            NumericPropertyDrawers.StringToDouble(str, out v);
            return v;
        }

        public new static readonly string ussClassName = "fox-double-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public DoubleField() : this((string)null) 
        { 
        }

        public DoubleField(int maxLength)
            : this(null, true, maxLength) 
        { 
        }

        public DoubleField(bool hasDragger)
            : this(null, hasDragger) 
        { 
        }

        public DoubleField(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new DoubleInput())
        {
        }

        private DoubleField(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<double>();
        }

        //internal override bool CanTryParse(string textString) => double.TryParse(textString, out _);

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, double startValue)
        {
            doubleInput.ApplyInputDeviceDelta(delta, speed, startValue);
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

        class DoubleInput : TextValueInput
        {
            DoubleField parentDoubleField => (DoubleField)parent;

            internal DoubleInput()
            {
                formatString = "R";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.FloatExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(UnityEngine.Vector3 delta, DeltaSpeed speed, double startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                double v = StringToValue(text);
                v += NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity;
                v = NumericPropertyDrawers.RoundBasedOnMinimumDifference(v, sensitivity);
                if (parentDoubleField.isDelayed)
                {
                    text = ValueToString(v);
                }
                else
                {
                    parentDoubleField.value = v;
                }
            }

            protected override string ValueToString(double v)
            {
                return v.ToString(formatString);
            }

            protected override double StringToValue(string str)
            {
                double v;
                NumericPropertyDrawers.StringToDouble(str, out v);
                return v;
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.Double))]
    public class DoubleDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new DoubleField();
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.Double>.alignedFieldUssClassName);

            return field;
        }
    }
}
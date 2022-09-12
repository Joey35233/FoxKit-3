using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int16Field : TextValueField<System.Int16>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override System.Int16 value 
        { 
            get => base.value;
            set
            {
                System.Int16 newValue = value;
                int packedNewValue = unchecked((int)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (ChangeEvent<int> evt = ChangeEvent<int>.GetPooled(packedOldValue, packedNewValue))
                        {
                            evt.target = this;
                            SendEvent(evt);
                        }
                    }
                    else
                    {
                        SetValueWithoutNotify(newValue);
                    }
                }
            }
        }
        int INotifyValueChanged<int>.value
        {
            get => unchecked((int)this.value);
            set
            {
                System.Int16 newValue = unchecked((System.Int16)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (ChangeEvent<int> evt = ChangeEvent<int>.GetPooled(packedOldValue, value))
                        {
                            evt.target = this;
                            SendEvent(evt);
                        }
                    }
                    else
                    {
                        SetValueWithoutNotify(newValue);
                    }
                }
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int newValue) { throw new NotImplementedException(); }

        Int16Input integerInput => (Int16Input)textInputBase;

        protected override string ValueToString(System.Int16 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.Int16 StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyFields.ClampToInt16(v);
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
            BindProperty(property, null);
        }
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
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

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.Int16 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt16(v);
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
                return NumericPropertyFields.ClampToInt16(v);
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
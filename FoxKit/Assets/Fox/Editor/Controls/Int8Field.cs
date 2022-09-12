using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class Int8Field : TextValueField<System.SByte>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override System.SByte value
        {
            get => base.value;
            set
            {
                System.SByte newValue = value;
                int packedNewValue = unchecked((int)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
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
                System.SByte newValue = unchecked((System.SByte)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
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

        Int8Input integerInput => (Int8Input)textInputBase;

        protected override string ValueToString(System.SByte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.SByte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyFields.ClampToInt8(v);
        }

        public new static readonly string ussClassName = "fox-int8-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public Int8Field()
            : this((string)null) { }

        public Int8Field(int maxLength)
            : this(null, true, maxLength) { }

        public Int8Field(bool hasDragger)
            : this(null, hasDragger) { }

        public Int8Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new Int8Input())
        {
        }

        private Int8Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.SByte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
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

        class Int8Input : TextValueInput
        {
            Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt8(v);
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
                return NumericPropertyFields.ClampToInt8(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.SByte))]
    public class Int8Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new Int8Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt64Field : TextValueField<System.UInt64>, INotifyValueChanged<long>, IFoxField, ICustomBindable
    {
        public override System.UInt64 value
        {
            get => base.value;
            set
            {
                System.UInt64 newValue = value;
                long packedNewValue = unchecked((long)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        long packedOldValue = unchecked((long)this.value);

                        // Sends ChangeEvent<System.UInt64> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (ChangeEvent<long> evt = ChangeEvent<long>.GetPooled(packedOldValue, packedNewValue))
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
        long INotifyValueChanged<long>.value
        {
            get => unchecked((long)this.value);
            set
            {
                System.UInt64 newValue = unchecked((System.UInt64)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        long packedOldValue = unchecked((long)this.value);

                        // Sends ChangeEvent<System.UInt64> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (ChangeEvent<long> evt = ChangeEvent<long>.GetPooled(packedOldValue, value))
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
        void INotifyValueChanged<long>.SetValueWithoutNotify(long newValue) { throw new NotImplementedException(); }

        UInt64Input integerInput => (UInt64Input)textInputBase;

        protected override string ValueToString(System.UInt64 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt64 StringToValue(string str)
        {
            System.Numerics.BigInteger v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyFields.ClampToUInt64(v);
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

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
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

        class UInt64Input : TextValueInput
        {
            UInt64Field parentIntegerField => (UInt64Field)parent;

            internal UInt64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt64 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt64(v);
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
                return NumericPropertyFields.ClampToUInt64(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.UInt64))]
    public class UInt64Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new UInt64Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
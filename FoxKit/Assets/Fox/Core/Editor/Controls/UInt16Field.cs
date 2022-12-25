using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt16Field : TextValueField<System.UInt16>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override System.UInt16 value
        {
            get => base.value;
            set
            {
                System.UInt16 newValue = value;
                int packedNewValue = unchecked((int)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
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
                System.UInt16 newValue = unchecked((System.UInt16)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked((int)this.value);

                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
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

        UInt16Input integerInput => (UInt16Input)textInputBase;

        protected override string ValueToString(System.UInt16 v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.UInt16 StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyFields.ClampToUInt16(v);
        }

        public new static readonly string ussClassName = "fox-uint16-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput { get; }

        public UInt16Field()
            : this((string)null) { }

        public UInt16Field(int maxLength)
            : this(null, true, maxLength) { }

        public UInt16Field(bool hasDragger)
            : this(null, hasDragger) { }

        public UInt16Field(string label, bool hasDragger = true, int maxLength = -1)
            : this(label, hasDragger, maxLength, new UInt16Input())
        {
        }

        private UInt16Field(string label, bool hasDragger, int maxLength, TextValueInput visInput)
            : base(label, maxLength, visInput)
        {
            visualInput = visInput;

            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            visualInput.AddToClassList(inputUssClassName);
            this.styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<System.UInt16>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt16 startValue)
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

        class UInt16Input : TextValueInput
        {
            UInt16Field parentIntegerField => (UInt16Field)parent;

            internal UInt16Input()
            {
                formatString = "##0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.UInt16 startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt16(v);
                }
            }

            protected override string ValueToString(System.UInt16 v)
            {
                return v.ToString(formatString);
            }

            protected override System.UInt16 StringToValue(string str)
            {
                int v;
                ExpressionEvaluator.Evaluate(str, out v);
                return NumericPropertyFields.ClampToUInt16(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(System.UInt16))]
    public class UInt16Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new UInt16Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<System.UInt64>.alignedFieldUssClassName);

            return field;
        }
    }
}
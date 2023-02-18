using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class UInt16Field : TextValueField<ushort>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override ushort value
        {
            get => base.value;
            set
            {
                ushort newValue = value;
                int packedNewValue = unchecked(newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(packedOldValue, packedNewValue))
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
            get => unchecked(value);
            set
            {
                ushort newValue = unchecked((ushort)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.UInt16> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<int>.GetPooled(packedOldValue, value))
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
        void INotifyValueChanged<int>.SetValueWithoutNotify(int newValue) => throw new NotImplementedException();

        private UInt16Input integerInput => (UInt16Input)textInputBase;

        protected override string ValueToString(ushort v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override ushort StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out int v);
            return NumericPropertyFields.ClampToUInt16(v);
        }

        public static new readonly string ussClassName = "fox-uint16-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt16Field()
            : this(null) { }

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
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<ushort>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ushort startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class UInt16Input : TextValueInput
        {
            private UInt16Field parentIntegerField => (UInt16Field)parent;

            internal UInt16Input()
            {
                formatString = "##0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ushort startValue)
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

            protected override string ValueToString(ushort v) => v.ToString(formatString);

            protected override ushort StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out int v);
                return NumericPropertyFields.ClampToUInt16(v);
            }
        }
    }

    [CustomPropertyDrawer(typeof(ushort))]
    public class UInt16Drawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new UInt16Field(property.name);
            field.BindProperty(property);

            field.labelElement.AddToClassList(PropertyField.labelUssClassName);
            field.visualInput.AddToClassList(PropertyField.inputUssClassName);
            field.AddToClassList(BaseField<ulong>.alignedFieldUssClassName);

            return field;
        }
    }
}
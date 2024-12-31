using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int16Field : TextValueField<short>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override short value
        {
            get => base.value;
            set
            {
                short newValue = value;
                int packedNewValue = unchecked(newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
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
                short newValue = unchecked((short)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.Int16> and uses its SetValueWithoutNotify function
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

        private Int16Input integerInput => (Int16Input)textInputBase;

        protected override string ValueToString(short v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override short StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out int v);
            return NumericPropertyFields.ClampToInt16(v);
        }

        public static new readonly string ussClassName = "fox-int16-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int16Field()
            : this(null) { }

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
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<short>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, short startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class Int16Input : TextValueInput
        {
            private Int16Field parentIntegerField => (Int16Field)parent;

            internal Int16Input()
            {
                formatString = "##0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, short startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt16(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt16(v);
                }
            }

            protected override string ValueToString(short v) => v.ToString(formatString);

            protected override short StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out int v);
                return NumericPropertyFields.ClampToInt16(v);
            }
        }
    }

    // [CustomPropertyDrawer(typeof(short))]
    // public class Int16Drawer : PropertyDrawer
    // {
    //     private SerializedProperty property;
    //     private Int16Field field;
    //
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         this.property = property;
    //
    //         field = new Int16Field(property.name);
    //         field.BindProperty(property);
    //
    //         field.labelElement.AddToClassList(PropertyField.labelUssClassName);
    //         field.visualInput.AddToClassList(PropertyField.inputUssClassName);
    //         field.AddToClassList(BaseField<ulong>.alignedFieldUssClassName);
    //
    //         return field;
    //     }
    // }
}
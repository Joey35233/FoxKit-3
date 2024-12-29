using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class Int8Field : TextValueField<sbyte>, INotifyValueChanged<int>, IFoxField, ICustomBindable
    {
        public override sbyte value
        {
            get => base.value;
            set
            {
                sbyte newValue = value;
                int packedNewValue = unchecked(newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
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
                sbyte newValue = unchecked((sbyte)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        int packedOldValue = unchecked(this.value);

                        // Sends ChangeEvent<System.SByte> and uses its SetValueWithoutNotify function
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

        private Int8Input integerInput => (Int8Input)textInputBase;

        protected override string ValueToString(sbyte v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override sbyte StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out int v);
            return NumericPropertyFields.ClampToInt8(v);
        }

        public static new readonly string ussClassName = "fox-int8-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public Int8Field()
            : this(null) { }

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
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<sbyte>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, sbyte startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class Int8Input : TextValueInput
        {
            private Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, sbyte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToInt8(v);
                }
            }

            protected override string ValueToString(sbyte v) => v.ToString(formatString);

            protected override sbyte StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out int v);
                return NumericPropertyFields.ClampToInt8(v);
            }
        }
    }

    // [CustomPropertyDrawer(typeof(sbyte))]
    // public class Int8Drawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new Int8Field(property.name);
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
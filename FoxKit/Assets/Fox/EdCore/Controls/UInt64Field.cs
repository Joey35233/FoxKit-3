using Fox.Core;
using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public class UInt64Field : TextValueField<ulong>, INotifyValueChanged<long>, IFoxField, ICustomBindable
    {
        public override ulong value
        {
            get => base.value;
            set
            {
                ulong newValue = value;
                long packedNewValue = unchecked((long)newValue);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        long packedOldValue = unchecked((long)this.value);

                        // Sends ChangeEvent<System.UInt64> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<long>.GetPooled(packedOldValue, packedNewValue))
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
            get => unchecked((long)value);
            set
            {
                ulong newValue = unchecked((ulong)value);
                if (newValue != this.value)
                {
                    if (panel != null)
                    {
                        long packedOldValue = unchecked((long)this.value);

                        // Sends ChangeEvent<System.UInt64> and uses its SetValueWithoutNotify function
                        base.value = newValue;

                        using (var evt = ChangeEvent<long>.GetPooled(packedOldValue, value))
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
        void INotifyValueChanged<long>.SetValueWithoutNotify(long newValue) => throw new NotImplementedException();

        private UInt64Input integerInput => (UInt64Input)textInputBase;

        protected override string ValueToString(ulong v) => v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);

        protected override ulong StringToValue(string str)
        {
            _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
            return NumericPropertyFields.ClampToUInt64(v);
        }

        public static new readonly string ussClassName = "fox-uint64-field";
        public static new readonly string labelUssClassName = ussClassName + "__label";
        public static new readonly string inputUssClassName = ussClassName + "__input";

        public VisualElement visualInput
        {
            get;
        }

        public UInt64Field()
            : this(null) { }

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
            styleSheets.Add(IFoxField.FoxFieldStyleSheet);
            if (hasDragger)
                AddLabelDragger<ulong>();
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue) => integerInput.ApplyInputDeviceDelta(delta, speed, startValue);

        public void BindProperty(SerializedProperty property) => BindProperty(property, null);
        public void BindProperty(SerializedProperty property, string label, PropertyInfo propertyInfo = null)
        {
            if (label is not null)
                this.label = label;
            BindingExtensions.BindProperty(this, property);
        }

        private class UInt64Input : TextValueInput
        {
            private UInt64Field parentIntegerField => (UInt64Field)parent;

            internal UInt64Input()
            {
                formatString = "#################0";
            }

            protected override string allowedCharacters => NumericPropertyFields.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                System.Numerics.BigInteger v = StringToValue(text);
                v += (System.Numerics.BigInteger)System.Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyFields.ClampToUInt64(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyFields.ClampToUInt64(v);
                }
            }

            protected override string ValueToString(ulong v) => v.ToString(formatString);

            protected override ulong StringToValue(string str)
            {
                _ = ExpressionEvaluator.Evaluate(str, out System.Numerics.BigInteger v);
                return NumericPropertyFields.ClampToUInt64(v);
            }
        }
    }

    // [CustomPropertyDrawer(typeof(ulong))]
    // public class UInt64Drawer : PropertyDrawer
    // {
    //     public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //     {
    //         var field = new UInt64Field(property.name);
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
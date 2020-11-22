﻿// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{

    /// <summary>
    /// Describes a XML <c>int8</c> attribute.
    /// </summary>
    public class UxmlInt8AttributeDescription : TypedUxmlAttributeDescription<sbyte>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UxmlInt8AttributeDescription()
        {
            type = "int8";
            typeNamespace = xmlSchemaNamespace;
            defaultValue = 0;
        }

        /// <summary>
        /// The default value for the attribute, as a string.
        /// </summary>
        public override string defaultValueAsString { get { return defaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat); } }

        /// <summary>
        /// Retrieves the value of this attribute from the attribute bag. Returns it if it is found, otherwise return <see cref="defaultValue"/>.
        /// </summary>
        /// <param name="bag">The bag of attributes.</param>
        /// <param name="cc">The context in which the values are retrieved.</param>
        /// <returns>The value of the attribute.</returns>
        public override sbyte GetValueFromBag(IUxmlAttributes bag, CreationContext cc)
        {
            return GetValueFromBag(bag, cc, (s, i) => ConvertValueToInt8(s, i), defaultValue);
        }

        /// <summary>
        /// Tries to retrieve the value of this attribute from the attribute bag. Returns true if it is found, otherwise returns false.
        /// </summary>
        /// <param name="bag">The bag of attributes.</param>
        /// <param name="cc">The context in which the values are retrieved.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>True if the value could be retrieved, false otherwise.</returns>
        public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, ref sbyte value)
        {
            return TryGetValueFromBag(bag, cc, (s, i) => ConvertValueToInt8(s, i), defaultValue, ref value);
        }

        static sbyte ConvertValueToInt8(string v, sbyte defaultValue)
        {
            sbyte l;
            if (v == null || !SByte.TryParse(v, out l))
                return defaultValue;

            return l;
        }
    }

    public class Int8Field : TextValueField<System.SByte>, INotifyValueChanged<System.SByte>, INotifyValueChanged<int>, INotifyValueChanged<long>
    {
        int INotifyValueChanged<int>.value
        {
            get
            {
                return property.intValue;
            }
            set
            {
                property.SetValue(this.value);
            }
        }
        void INotifyValueChanged<int>.SetValueWithoutNotify(int val)
        {
            return;
        }

        long INotifyValueChanged<long>.value
        {
            get
            {
                return property.longValue;
            }
            set
            {
                property.SetValue(this.value);
            }
        }
        void INotifyValueChanged<long>.SetValueWithoutNotify(long val)
        {
            return;
        }

        System.SByte INotifyValueChanged<System.SByte>.value
        {
            get
            {
                return value;
            }
            set
            {
                property.SetValue(this.value);
            }
        }
        void INotifyValueChanged<System.SByte>.SetValueWithoutNotify(System.SByte val)
        {
            return;
        }


        Int8Input integerInput => (Int8Input)textInputBase;

        public new class UxmlFactory : UxmlFactory<Int8Field, UxmlTraits> { }
        public new class UxmlTraits : TextValueFieldTraits<System.SByte, UxmlInt8AttributeDescription> {}

        protected override string ValueToString(System.SByte v)
        {
            return v.ToString(formatString, CultureInfo.InvariantCulture.NumberFormat);
        }

        protected override System.SByte StringToValue(string str)
        {
            int v;
            ExpressionEvaluator.Evaluate(str, out v);
            return NumericPropertyDrawers.ClampToInt8(v);
        }

        public new static readonly string ussClassName = "fox-int8-field";
        public new static readonly string labelUssClassName = ussClassName + "__label";
        public new static readonly string inputUssClassName = ussClassName + "__input";

        public Int8Field()
            : this((string)null) { }

        public Int8Field(int maxLength)
            : this(null, maxLength) { }

        public Int8Field(string label, int maxLength = -1)
            : base(label, maxLength, new Int8Input())
        {
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            AddLabelDragger<System.SByte>();
        }

        SerializedProperty property;
        public Int8Field(SerializedProperty property)
            : this(property.displayName)
        {
            this.property = property;
            this.BindProperty(property);
        }

        public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
        {
            integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
        }

        class Int8Input : TextValueInput
        {
            Int8Field parentIntegerField => (Int8Field)parent;

            internal Int8Input()
            {
                formatString = "0";
            }

            protected override string allowedCharacters => NumericPropertyDrawers.IntegerExpressionCharacterWhitelist;

            public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, System.SByte startValue)
            {
                double sensitivity = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
                float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
                int v = StringToValue(text);
                v += (int)Math.Round(NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * sensitivity);
                if (parentIntegerField.isDelayed)
                {
                    text = ValueToString(NumericPropertyDrawers.ClampToInt8(v));
                }
                else
                {
                    parentIntegerField.value = NumericPropertyDrawers.ClampToInt8(v);
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
                return NumericPropertyDrawers.ClampToInt8(v);
            }
        }
    }
}
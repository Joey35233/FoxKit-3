using System;
using System.Globalization;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public abstract class FoxTextValueField<T> : TextValueField<T>
    {

        protected FoxTextValueField(string label, int maxLength, FoxFieldInput input)
            : base(label, maxLength, input)
        {
            AddToClassList(ussClassName);
            labelElement.AddToClassList(labelUssClassName);
            AddLabelDragger<T>();
        }

        public abstract override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, T startValue);

        protected abstract override T StringToValue(string str);

        protected abstract override string ValueToString(T value);

        protected abstract class FoxFieldInput : TextValueInput
        {
        }
    }
}
using System;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    internal class DynamicProperty
    {
        public PropertyInfo PropertyInfo;

        public Value Value;

        public DynamicProperty(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }

        public Value GetValue() => Value;

        internal Value GetElement(ushort index) => throw new NotImplementedException();
        internal Value GetElement(String key) => throw new NotImplementedException();

        public void SetValue(Value val) => Value = val;

        internal void SetElement(ushort index, Value value) => throw new NotImplementedException();
        internal void SetElement(String key, Value value) => throw new NotImplementedException();
    }
}
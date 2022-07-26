using System;

namespace Fox.Core
{
    class DynamicProperty
    {
        public PropertyInfo PropertyInfo;

        public Value Value;

        public DynamicProperty(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }

        public void SetValue(Value val)
        {
            Value = val;
        }

        internal void SetElement(ushort index, Value value)
        {
            throw new NotImplementedException();
        }
        internal void SetElement(string key, Value value)
        {
            throw new NotImplementedException();
        }
    }
}
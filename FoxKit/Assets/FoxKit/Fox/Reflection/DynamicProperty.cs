using System;

namespace Fox.Core
{
    class DynamicProperty
    {
        public DynamicProperty(PropertyInfo propertyInfo)
        {
        }


        public void SetValue(Value val)
        {
            throw new NotImplementedException();
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
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<bool>")]
    public class DynamicProperty_StaticArray_bool : DynamicProperty
    {
        public bool[] Value = new bool[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, (uint)Value.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            bool[] newList = new bool[newSize];
            
            for (uint i = 0; i < (newSize <= Value.LongLength ? newSize : Value.LongLength); i++)
                newList[i] = Value[i];
            
            Value = newList;
        }

        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.LongLength;

        public override void SetElement(ushort index, object value) => Value[index] = (bool)value;
    }
}
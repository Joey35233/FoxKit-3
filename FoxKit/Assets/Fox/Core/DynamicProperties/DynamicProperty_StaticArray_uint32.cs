using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<uint32>")]
    public class DynamicProperty_StaticArray_uint32 : DynamicProperty
    {
        [SerializeField]
        public uint[] Value = new uint[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt32, 0, (uint)Value.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            uint[] newList = new uint[newSize];
            
            for (uint i = 0; i < (newSize <= Value.LongLength ? newSize : Value.LongLength); i++)
                newList[i] = Value[i];
            
            Value = newList;
        }

        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.LongLength;

        public override void SetElement(ushort index, object value) => Value[index] = (uint)value;
    }
}
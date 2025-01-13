using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - StaticArray<uint8>")]
    public class DynamicProperty_StaticArray_uint8 : DynamicProperty
    {
        [SerializeField]
        private byte[] SerializedField = new byte[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt8, 0, (uint)SerializedField.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            byte[] newList = new byte[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsUInt8();
        }
    }
}
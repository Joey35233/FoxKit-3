using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<uint64>")]
    public class DynamicProperty_StaticArray_uint64 : DynamicProperty
    {
        [SerializeField]
        private ulong[] SerializedField = new ulong[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt64, 0, (uint)SerializedField.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            ulong[] newList = new ulong[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override object GetValue() => SerializedField;
        public override object GetElement(int index) => SerializedField[index];

        public override void SetElement(int index, object value) => SerializedField[index] = (ulong)value;

        public override void AddElement(int index, object value)
        {
            if (index >= SerializedField.LongLength)
                ChangeStaticArraySize((uint)index + 1);
            SerializedField[index] = (ulong)value;
        }
    }
}
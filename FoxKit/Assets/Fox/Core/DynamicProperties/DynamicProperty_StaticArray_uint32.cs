using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<uint32>")]
    public class DynamicProperty_StaticArray_uint32 : DynamicProperty
    {
        [SerializeField]
        private uint[] SerializedField = new uint[1];
        public uint[] Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt32, 0, (uint)SerializedField.LongLength, PropertyInfo.ContainerType.StaticArray);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            uint[] newList = new uint[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.LongLength;

        public override void SetElement(ushort index, object value) => SerializedField[index] = (uint)value;
    }
}
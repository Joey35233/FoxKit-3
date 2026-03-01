using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint8>")]
    public class DynamicProperty_DynamicArray_uint8 : DynamicProperty
    {
        [SerializeField]
        public readonly System.Collections.Generic.List<byte> Value = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt8, 0, container: GetContainerType());
        
        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.Count;

        public override void SetElement(ushort index, object value) => Value.Insert(index, (byte)value);
    }
}
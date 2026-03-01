using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint64>")]
    public class DynamicProperty_DynamicArray_uint64 : DynamicProperty
    {
        [SerializeField]
        public readonly System.Collections.Generic.List<ulong> Value = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt64, 0, container: GetContainerType());
        
        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.Count;

        public override void SetElement(ushort index, object value) => Value.Insert(index, (ulong)value);
    }
}
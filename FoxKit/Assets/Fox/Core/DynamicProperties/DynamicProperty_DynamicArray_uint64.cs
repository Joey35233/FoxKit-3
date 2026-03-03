using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint64>")]
    public class DynamicProperty_DynamicArray_uint64 : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<ulong> SerializedField = new ();
        public System.Collections.Generic.List<ulong> Value => SerializedField;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt64, 0, container: PropertyInfo.ContainerType.DynamicArray);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (ulong)value);
    }
}
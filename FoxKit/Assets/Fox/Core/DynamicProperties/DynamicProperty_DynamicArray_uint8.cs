using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint8>")]
    public class DynamicProperty_DynamicArray_uint8 : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<byte> SerializedField = new ();
        public System.Collections.Generic.List<byte> Value => SerializedField;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt8, 0, container: PropertyInfo.ContainerType.DynamicArray);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (byte)value);
    }
}
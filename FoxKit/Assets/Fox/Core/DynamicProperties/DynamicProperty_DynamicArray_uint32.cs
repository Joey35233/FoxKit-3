using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint32>")]
    public class DynamicProperty_DynamicArray_uint32 : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<uint> SerializedField = new ();
        public System.Collections.Generic.List<uint> Value => SerializedField;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt32, 0, container: PropertyInfo.ContainerType.DynamicArray);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (uint)value);
    }
}
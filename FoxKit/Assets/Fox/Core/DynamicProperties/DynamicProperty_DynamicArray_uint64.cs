using System.Collections;
using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint64>")]
    public class DynamicProperty_DynamicArray_uint64 : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<ulong> SerializedField = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt64, 0, container: GetContainerType());
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsUInt64();
        }
        
    }
}
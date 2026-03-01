using System.Collections;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<bool>")]
    public class DynamicProperty_DynamicArray_bool : DynamicProperty
    {
        public System.Collections.Generic.List<bool> Value = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, container: GetContainerType());
        
        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.Count;

        public override void SetElement(ushort index, object value) => Value.Insert(index, (bool)value);
    }
}
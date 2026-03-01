using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<float>")]
    public class DynamicProperty_DynamicArray_float : DynamicProperty
    {
        [SerializeField]
        public readonly System.Collections.Generic.List<float> Value = new();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, container: GetContainerType());

        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.Count;

        public override void SetElement(ushort index, object value) => Value.Insert(index, (float)value);
    }
}
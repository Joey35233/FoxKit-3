using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - StaticArray<Path>")]
    public class DynamicProperty_StaticArray_Path : DynamicProperty
    {
        [SerializeField]
        private StaticArray<Path> SerializedField = new (1);
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, (uint)SerializedField.Count);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            SerializedField = new StaticArray<Path>(SerializedField, (int)newSize);
        }
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsPath();
        }
    }
}
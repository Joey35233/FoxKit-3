using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<Path>")]
    public class DynamicProperty_DynamicArray_Path : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<Path> SerializedField = new();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, container: GetContainerType());
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(int index) => new Value(SerializedField[index]);

        public override void SetElement(int index, Value value) => SerializedField.Insert(index, value.GetValueAsPath());
    }
}
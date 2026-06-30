using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<float>")]
    public class DynamicProperty_DynamicArray_float : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<float> SerializedField = new();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, container: GetContainerType());

        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(int index) => new Value(SerializedField[index]);

        public override void SetElement(int index, Value value) => SerializedField.Insert(index, value.GetValueAsFloat());
    }
}
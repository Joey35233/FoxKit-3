using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<Path>")]
    public class DynamicProperty_DynamicArray_Path : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<Path> SerializedField = new();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, container: GetContainerType());

        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(int index) => new Value(SerializedField[index]);

        public override void SetElement(int index, Value value)
        {
            SerializedField[index] = value.GetValueAsPath();
        }

        public override void AddElement(int index, Value value)
        {
            while (SerializedField.Count <= index)
                SerializedField.Add(default);
            SerializedField[index] = value.GetValueAsPath();
        }

        public override void RemoveElement(int index) => SerializedField.RemoveAt(index);
    }
}

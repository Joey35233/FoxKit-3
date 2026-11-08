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

        public override object GetValue() => SerializedField;
        public override object GetElement(int index) => SerializedField[index];

        public override void SetElement(int index, object value) => SerializedField[index] = (Path)value;

        public override void AddElement(int index, object value)
        {
            while (SerializedField.Count <= index)
                SerializedField.Add(default);
            SerializedField[index] = (Path)value;
        }

        public override void RemoveElement(int index) => SerializedField.RemoveAt(index);
    }
}

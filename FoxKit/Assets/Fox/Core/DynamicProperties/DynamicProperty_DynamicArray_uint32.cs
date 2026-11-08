using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<uint32>")]
    public class DynamicProperty_DynamicArray_uint32 : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<uint> SerializedField = new();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.UInt32, 0, container: GetContainerType());

        public override object GetValue() => SerializedField;
        public override object GetElement(int index) => SerializedField[index];

        public override void SetElement(int index, object value) => SerializedField[index] = (uint)value;

        public override void AddElement(int index, object value)
        {
            while (SerializedField.Count <= index)
                SerializedField.Add(default);
            SerializedField[index] = (uint)value;
        }

        public override void RemoveElement(int index) => SerializedField.RemoveAt(index);
    }
}

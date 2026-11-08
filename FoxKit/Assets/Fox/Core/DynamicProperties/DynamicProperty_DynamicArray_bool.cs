using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<bool>")]
    public class DynamicProperty_DynamicArray_bool : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<bool> SerializedField = new();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, container: GetContainerType());

        public override object GetValue() => SerializedField;
        public override object GetElement(int index) => SerializedField[index];

        public override void SetElement(int index, object value) => SerializedField[index] = (bool)value;

        public override void AddElement(int index, object value)
        {
            while (SerializedField.Count <= index)
                SerializedField.Add(default);
            SerializedField[index] = (bool)value;
        }

        public override void RemoveElement(int index) => SerializedField.RemoveAt(index);
    }
}

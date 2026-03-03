using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<float>")]
    public class DynamicProperty_DynamicArray_float : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<float> SerializedField = new();
        public System.Collections.Generic.List<float> Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, container: PropertyInfo.ContainerType.DynamicArray);

        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (float)value);
    }
}
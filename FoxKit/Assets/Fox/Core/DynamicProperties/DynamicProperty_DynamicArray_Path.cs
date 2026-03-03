using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<Path>")]
    public class DynamicProperty_DynamicArray_Path : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<Path> SerializedField = new();
        public System.Collections.Generic.List<Path> Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, container: PropertyInfo.ContainerType.DynamicArray);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (Path)value);
    }
}
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<bool>")]
    public class DynamicProperty_DynamicArray_bool : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<bool> SerializedField = new ();
        public System.Collections.Generic.List<bool> Value => SerializedField;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, container: PropertyInfo.ContainerType.DynamicArray);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(ushort index, object value) => SerializedField.Insert(index, (bool)value);
    }
}
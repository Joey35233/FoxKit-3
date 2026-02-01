using System.Collections;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<bool>")]
    public class DynamicProperty_DynamicArray_bool : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<bool> SerializedField = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, container: GetContainerType());
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value) => SerializedField.Insert(index, value.GetValueAsBool());
    }
}
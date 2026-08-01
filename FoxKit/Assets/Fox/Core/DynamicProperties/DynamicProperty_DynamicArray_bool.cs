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
        public override Value GetElement(int index) => new Value(SerializedField[index]);

        public override void SetElement(int index, Value value) => SerializedField[index] = value.GetValueAsBool();
        public override void AddElement(int index, Value value) => SerializedField.Insert(index, value.GetValueAsBool());
        public override void RemoveElement(int index) => SerializedField.RemoveAt(index);
    }
}
using System.Collections;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - DynamicArray<String>")]
    public class DynamicProperty_DynamicArray_String : DynamicProperty
    {
        [SerializeField]
        private DynamicArray<string> SerializedField = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, container: GetContainerType());
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsString();
        }
    }
}
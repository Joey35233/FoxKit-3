using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - StaticArray<String>")]
    public class DynamicProperty_StaticArray_String : DynamicProperty
    {
        [SerializeField]
        private StaticArray<string> SerializedField = new (1);
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo("", PropertyInfo.PropertyType.String, 0, (uint)SerializedField.Count);
        
        internal override bool IsStaticArrayOverride() => true;

        internal override void ChangeStaticArraySize(uint newSize)
        {
            SerializedField = new StaticArray<string>(SerializedField, (int)newSize);
        }

        public override Value GetValue() => new Value(SerializedField);
    }
}
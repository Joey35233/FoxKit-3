using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<String>")]
    public class DynamicProperty_StaticArray_String : DynamicProperty
    {
        [SerializeField]
        public string[] Value = new string[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, (uint)Value.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            string[] newList = new string[newSize];
            
            for (uint i = 0; i < (newSize <= Value.LongLength ? newSize : Value.LongLength); i++)
                newList[i] = Value[i];
            
            Value = newList;
        }
        
        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.LongLength;

        public override void SetElement(ushort index, object value) => Value[index] = (string)value;
    }
}
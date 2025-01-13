using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<String>")]
    public class DynamicProperty_StaticArray_String : DynamicProperty
    {
        [SerializeField]
        private string[] SerializedField = new string[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, (uint)SerializedField.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            string[] newList = new string[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }
        
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsString();
        }
    }
}
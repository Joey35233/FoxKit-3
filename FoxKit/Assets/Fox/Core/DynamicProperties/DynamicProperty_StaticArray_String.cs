using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<String>")]
    public class DynamicProperty_StaticArray_String : DynamicProperty
    {
        [SerializeField]
        private string[] SerializedField = new string[1];
        public string[] Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, (uint)SerializedField.LongLength, PropertyInfo.ContainerType.StaticArray);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            string[] newList = new string[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.LongLength;

        public override void SetElement(ushort index, object value) => SerializedField[index] = (string)value;
    }
}
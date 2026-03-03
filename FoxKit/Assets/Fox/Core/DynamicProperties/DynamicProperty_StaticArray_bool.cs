using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<bool>")]
    public class DynamicProperty_StaticArray_bool : DynamicProperty
    {
        [SerializeField]
        private bool[] SerializedField = new bool[1];
        public bool[] Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, (uint)SerializedField.LongLength, PropertyInfo.ContainerType.StaticArray);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            bool[] newList = new bool[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.LongLength;

        public override void SetElement(ushort index, object value) => SerializedField[index] = (bool)value;
    }
}
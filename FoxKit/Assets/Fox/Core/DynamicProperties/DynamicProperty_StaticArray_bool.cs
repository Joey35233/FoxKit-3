using System;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<bool>")]
    public class DynamicProperty_StaticArray_bool : DynamicProperty
    {
        [SerializeField]
        private bool[] SerializedField = new bool[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Bool, 0, (uint)SerializedField.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            bool[] newList = new bool[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(int index) => new Value(SerializedField[index]);

        public override void SetElement(int index, Value value)
        {
            SerializedField[index] = value.GetValueAsBool();
        }
    }
}
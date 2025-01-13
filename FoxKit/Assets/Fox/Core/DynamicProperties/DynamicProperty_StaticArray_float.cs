using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - StaticArray<float>")]
    public class DynamicProperty_StaticArray_float : DynamicProperty
    {
        [SerializeField]
        private float[] SerializedField = new float[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, (uint)SerializedField.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            float[] newList = new float[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsFloat();
        }
    }
}
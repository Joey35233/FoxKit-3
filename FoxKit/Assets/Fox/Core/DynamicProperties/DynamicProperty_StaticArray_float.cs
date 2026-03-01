using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<float>")]
    public class DynamicProperty_StaticArray_float : DynamicProperty
    {
        [SerializeField]
        public float[] Value = new float[1];
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, (uint)Value.LongLength);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            float[] newList = new float[newSize];
            
            for (uint i = 0; i < (newSize <= Value.LongLength ? newSize : Value.LongLength); i++)
                newList[i] = Value[i];
            
            Value = newList;
        }

        public override object GetValue() => Value;
        public override object GetElement(ushort index) => Value[index];
        public override uint GetArraySize() => (uint)Value.LongLength;

        public override void SetElement(ushort index, object value) => Value[index] = (float)value;
    }
}
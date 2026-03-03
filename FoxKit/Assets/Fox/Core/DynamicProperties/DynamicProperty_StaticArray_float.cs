using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<float>")]
    public class DynamicProperty_StaticArray_float : DynamicProperty
    {
        [SerializeField]
        private float[] SerializedField = new float[1];
        public float[] Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, (uint)SerializedField.LongLength, PropertyInfo.ContainerType.StaticArray);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            float[] newList = new float[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }

        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.LongLength;

        public override void SetElement(ushort index, object value) => SerializedField[index] = (float)value;
    }
}
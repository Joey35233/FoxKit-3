using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<float>")]
    public class DynamicProperty_DynamicArray_float : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<float> SerializedField = new();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Float, 0, container: GetContainerType());

        internal override void ChangeStaticArraySize(uint newSize)
        {
            float[] newList = new float[newSize];
            
            for (int i = 0; i < (newSize <= SerializedField.Capacity ? newSize : SerializedField.Capacity); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList.ToList();
        }
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsFloat();
        }
    }
}
using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<Path>")]
    public class DynamicProperty_DynamicArray_Path : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<Path> SerializedField = new();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StaticArray;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, container: GetContainerType());
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            Path[] newList = new Path[newSize];
            
            for (int i = 0; i < (newSize <= SerializedField.Capacity ? newSize : SerializedField.Capacity); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList.ToList();
        }
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value)
        {
            SerializedField[index] = value.GetValueAsPath();
        }
    }
}
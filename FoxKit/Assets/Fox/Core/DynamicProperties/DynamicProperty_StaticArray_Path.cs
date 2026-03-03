using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StaticArray<Path>")]
    public class DynamicProperty_StaticArray_Path : DynamicProperty
    {
        [SerializeField]
        private Path[] SerializedField = new Path[1];
        public Path[] Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.Path, 0, (uint)SerializedField.LongLength, PropertyInfo.ContainerType.StaticArray);
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            Path[] newList = new Path[newSize];
            
            for (uint i = 0; i < (newSize <= SerializedField.LongLength ? newSize : SerializedField.LongLength); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList;
        }
        
        public override object GetValue() => SerializedField;
        public override object GetElement(ushort index) => SerializedField[index];
        public override uint GetArraySize() => (uint)SerializedField.LongLength;

        public override void SetElement(ushort index, object value) => SerializedField[index] = (Path)value;
    }
}
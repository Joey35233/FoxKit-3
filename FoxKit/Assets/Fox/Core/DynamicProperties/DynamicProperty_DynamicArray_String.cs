using System.Collections;
using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - DynamicArray<String>")]
    public class DynamicProperty_DynamicArray_String : DynamicProperty
    {
        [SerializeField]
        private System.Collections.Generic.List<string> SerializedField = new ();

        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.DynamicArray;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, container: GetContainerType());
        
        internal override void ChangeStaticArraySize(uint newSize)
        {
            string[] newList = new string[newSize];
            
            for (int i = 0; i < (newSize <= SerializedField.Capacity ? newSize : SerializedField.Capacity); i++)
                newList[i] = SerializedField[i];
            
            SerializedField = newList.ToList();
        }
        public override Value GetValue() => new Value(SerializedField);
        public override Value GetElement(ushort index) => new Value(SerializedField[index]);

        public override void SetElement(ushort index, Value value) => SerializedField.Insert(index, value.GetValueAsString());
    }
}
using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StringMap<String>")]
    public class DynamicProperty_StringMap_String : DynamicProperty
    {
        [SerializeField]
        private StringMap<string> SerializedField = new ();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StringMap;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, container: GetContainerType());
        
        public override Value GetValue() => new Value(SerializedField as IStringMap);
        public override Value GetElement(string key) => new Value(SerializedField[key]);

        public override void SetElement(string key, Value value)
        {
            SerializedField[key] = value.GetValueAsString();
        }
    }
}
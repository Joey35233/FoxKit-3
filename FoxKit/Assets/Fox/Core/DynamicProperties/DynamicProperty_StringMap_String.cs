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
        
        public override object GetValue() => SerializedField as IStringMap;
        public override object GetElement(string key) => SerializedField[key];

        public override void SetElement(string key, object value) => SerializedField[key] = (string)value;
        public override void RemoveElement(string key) => SerializedField.Remove(key);
    }
}
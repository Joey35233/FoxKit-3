using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StringMap<String>")]
    public class DynamicProperty_StringMap_String : DynamicProperty
    {
        [SerializeField]
        private StringMap<string> SerializedField = new ();
        public StringMap<string> Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.String, 0, container: PropertyInfo.ContainerType.StringMap);        
        
        public override object GetValue() => SerializedField;
        public override object GetElement(string key) => SerializedField[key];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(string key, object value) => SerializedField[key] = (string)value;
    }
}
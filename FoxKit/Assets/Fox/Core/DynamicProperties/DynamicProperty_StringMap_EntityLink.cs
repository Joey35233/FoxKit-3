using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StringMap<EntityLink>")]
    public class DynamicProperty_StringMap_EntityLink : DynamicProperty
    {
        [SerializeField]
        private StringMap<EntityLink> SerializedField = new ();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StringMap;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.EntityLink, 0, container: GetContainerType());
        
        public override object GetValue() => SerializedField as IStringMap;
        public override object GetElement(string key) => SerializedField[key];

        public override void SetElement(string key, object value) => SerializedField[key] = (EntityLink)value;
        public override void RemoveElement(string key) => SerializedField.Remove(key);
    }
}
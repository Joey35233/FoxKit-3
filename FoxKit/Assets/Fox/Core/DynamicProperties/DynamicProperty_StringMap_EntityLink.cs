using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StringMap<EntityLink>")]
    public class DynamicProperty_StringMap_EntityLink : DynamicProperty
    {
        [SerializeField]
        public StringMap<EntityLink> Value = new ();
        
        internal override PropertyInfo.ContainerType GetContainerType() => PropertyInfo.ContainerType.StringMap;
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.EntityLink, 0, container: GetContainerType());
        
        public override object GetValue() => Value;
        public override object GetElement(string key) => Value[key];
        public override uint GetArraySize() => (uint)Value.Count;

        public override void SetElement(string key, object value) => Value[key] = (EntityLink)value;
    }
}
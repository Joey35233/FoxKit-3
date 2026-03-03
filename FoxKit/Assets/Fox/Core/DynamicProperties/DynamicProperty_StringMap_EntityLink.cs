using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("FoxCore/DynamicProperty - StringMap<EntityLink>")]
    public class DynamicProperty_StringMap_EntityLink : DynamicProperty
    {
        [SerializeField]
        private StringMap<EntityLink> SerializedField = new ();
        public StringMap<EntityLink> Value => SerializedField;
        
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo(Name, PropertyInfo.PropertyType.EntityLink, 0, container: PropertyInfo.ContainerType.StringMap);
        
        public override object GetValue() => SerializedField;
        public override object GetElement(string key) => SerializedField[key];
        public override uint GetArraySize() => (uint)SerializedField.Count;

        public override void SetElement(string key, object value) => SerializedField[key] = (EntityLink)value;
    }
}
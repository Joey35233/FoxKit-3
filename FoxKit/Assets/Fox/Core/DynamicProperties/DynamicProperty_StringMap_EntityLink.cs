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
        
        public override Value GetValue() => new Value(SerializedField as IStringMap);
        public override Value GetElement(string key) => new Value(SerializedField[key]);

        public override void SetElement(string key, Value value)
        {
            if (SerializedField.ContainsKey(key))
                SerializedField[key] = value.GetValueAsEntityLink();
            else
                SerializedField.Insert(key, value.GetValueAsEntityLink());
        }
    }
}
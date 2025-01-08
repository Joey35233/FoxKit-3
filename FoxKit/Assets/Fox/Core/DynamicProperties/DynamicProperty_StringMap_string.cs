using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - StringMap<String>")]
    public class DynamicProperty_StringMap_String : DynamicProperty
    {
        [SerializeField]
        private StringMap<string> SerializedField = new ();
        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo("", PropertyInfo.PropertyType.String, 0, container: PropertyInfo.ContainerType.StringMap);
        
        internal override bool IsStaticArrayOverride() => true;

        public override Value GetValue() => new Value(SerializedField as IStringMap);
    }
}
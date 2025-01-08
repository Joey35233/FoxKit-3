using UnityEngine;

namespace Fox.Core
{
    [AddComponentMenu("DynamicProperty - String")]
    public class DynamicProperty_String : DynamicProperty
    {
        [SerializeField]
        private string SerializedField;

        internal override PropertyInfo GetPropertyInfo() => new PropertyInfo("", PropertyInfo.PropertyType.String, 0);

        public override Value GetValue() => new Value(SerializedField);
    }
}
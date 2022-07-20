using UnityEngine;

namespace Fox.Core
{
    public partial class SphereShape : Fox.Core.ShapeData
    {
        protected partial float Get_radius()
        {
            var transformEntity = this.transform.Get();
            return Mathf.Min(transformEntity.scale.x, transformEntity.scale.y, transformEntity.scale.z);
        }
        protected partial void Set_radius(float value)
        {
            var transformEntity = this.transform.Get();
            transformEntity.scale = new Vector3(value, value, value);
        }
    }
}
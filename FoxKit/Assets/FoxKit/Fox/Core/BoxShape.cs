using UnityEngine;

namespace Fox.Core
{
    public partial class BoxShape : Fox.Core.ShapeData
    {
        protected partial UnityEngine.Vector3 Get_size()
        {
            var transformEntity = this.transform.Get();
            return transformEntity.scale;
        }
        protected partial void Set_size(UnityEngine.Vector3 value)
        {
            var transformEntity = this.transform.Get();
            transformEntity.scale = value;
        }
    }
}
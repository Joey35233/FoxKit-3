using UnityEngine;

namespace Fox.Core
{
    public partial class BoxShape : Fox.Core.ShapeData
    {
        private partial UnityEngine.Vector3 size_Get()
        {
            UnityEngine.Transform transform = this.transform;
            return transform.localScale / 2;
        }
        private partial void size_Set(UnityEngine.Vector3 value)
        {
            UnityEngine.Transform transform = this.transform;
            transform.localScale = 2 * value;
        }
    }
}
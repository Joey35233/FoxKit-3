using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Core
{
    public partial class SphereShape : Fox.Core.ShapeData
    {
        private partial float radius_Get()
        {
            UnityEngine.Transform transform = this.transform;
            return Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        private partial void radius_Set(float value)
        {
            UnityEngine.Transform transform = this.transform;
            transform.localScale = new Vector3(value, value, value);
        }

        public override void Reset()
        {
            base.Reset();
            radius = 1;
        }
    }
}
using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Core
{
    public partial class SphereShape : Fox.Core.ShapeData
    {
        private partial float Get_radius()
        {
            UnityEngine.Transform transform = this.transform;
            return Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        private partial void Set_radius(float value)
        {
            UnityEngine.Transform transform = this.transform;
            transform.localScale = new Vector3(value, value, value);
        }

        private readonly SphereGizmo Gizmo = new SphereGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = this.name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmos();
        }
    }
}
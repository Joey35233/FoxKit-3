using Fox.Core.Utils;
using System;
using UnityEngine;

namespace Fox.Core
{
    public partial class SphereShape : Fox.Core.ShapeData
    {
        protected partial float Get_radius()
        {
            UnityEngine.Transform transform = (this as MonoBehaviour).transform;
            return Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        protected partial void Set_radius(float value)
        {
            UnityEngine.Transform transform = (this as MonoBehaviour).transform;
            transform.localScale = new Vector3(value, value, value);
        }

        private readonly SphereGizmo Gizmo = new SphereGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Label = (this as MonoBehaviour).name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmos();
        }
    }
}
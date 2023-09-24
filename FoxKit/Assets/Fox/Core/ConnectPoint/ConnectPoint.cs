using System;
using UnityEngine;

namespace Fox.Core
{
    public class ConnectPoint : MonoBehaviour
    {
        private readonly PointGizmo Gizmo = new() { ScaleMode = PointGizmo.GizmoScaleMode.InheritLocal, Scale = new Vector3(0.05f, 0.05f, 0.05f) };

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
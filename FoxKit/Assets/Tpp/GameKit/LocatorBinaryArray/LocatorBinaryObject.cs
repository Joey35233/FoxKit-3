using Fox.Core;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tpp.GameKit
{
    public class LocatorBinaryObject : MonoBehaviour
    {
        private PointGizmo Gizmo = new PointGizmo
        {
            Color = Color.cyan, Scale = Vector3.one, ScaleMode = PointGizmo.GizmoScaleMode.Explicit
        };

        public bool ShouldDrawGizmo = false;

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
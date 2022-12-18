using System;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class PointGizmo : MonoBehaviour
    {
        public enum GizmoScaleMode
        {
            Explicit,
            InheritLocal,
            InheritWorld,
        }

        [HideInInspector]
        public Color Color = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);

        [HideInInspector]
        public GizmoScaleMode ScaleMode = GizmoScaleMode.Explicit;

        [HideInInspector]
        public Vector3 Scale = Vector3.one;

        public void OnDrawGizmos()
        {
            Gizmos.color = Color;

            Debug.Assert((int)ScaleMode > -1 && (int)ScaleMode < 3);
            Vector3 inheritedScale = ScaleMode switch
            {
                GizmoScaleMode.Explicit => Vector3.one,
                GizmoScaleMode.InheritLocal => this.transform.localScale,
                GizmoScaleMode.InheritWorld => this.transform.lossyScale,
                _ => Vector3.zero,
            };

            var position = this.transform.position;

            var right = this.transform.right * inheritedScale.x * Scale.x;
            Gizmos.DrawLine(position - right, position + right);

            var up = this.transform.up * inheritedScale.y * Scale.y;
            Gizmos.DrawLine(position - up, position + up);

            var forward = this.transform.forward * inheritedScale.z * Scale.z;
            Gizmos.DrawLine(position - forward, position + forward);
        }
    }
}
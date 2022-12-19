using System;
using UnityEditor;
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

        public Color Color = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);
        public bool DrawLabel = false;

        [HideInInspector]
        public GizmoScaleMode ScaleMode = GizmoScaleMode.Explicit;

        [HideInInspector]
        public Vector3 Scale = Vector3.one;

        public void DrawGizmos(bool isSelected)
        {
            if (isSelected)
                Gizmos.color = Color.white;
            else
                Gizmos.color = Color;

            Debug.Assert(Enum.IsDefined(typeof(GizmoScaleMode), ScaleMode));
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

            if (DrawLabel)
                Handles.Label(position, gameObject.name);
        }
        public void OnDrawGizmos()
        {
            DrawGizmos(false);
        }
        public void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a point gizmo in the scene.
    /// </summary>
    public class PointGizmo
    {
        public enum GizmoScaleMode
        {
            Explicit,
            InheritLocal,
            InheritWorld,
        }

        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public Color Color = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);
        public GizmoScaleMode ScaleMode = GizmoScaleMode.Explicit;
        public Vector3 Scale = Vector3.one;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.color = isSelected ? Color.white : Color;

            Vector3 inheritedScale = ScaleMode switch
            {
                GizmoScaleMode.Explicit => Vector3.one,
                GizmoScaleMode.InheritLocal => Transform.localScale,
                GizmoScaleMode.InheritWorld => Transform.lossyScale,
                _ => Vector3.zero,
            };

            Vector3 position = Transform.position;

            Vector3 right = Transform.right * inheritedScale.x * Scale.x;
            Gizmos.DrawLine(position - right, position + right);

            Vector3 up = Transform.up * inheritedScale.y * Scale.y;
            Gizmos.DrawLine(position - up, position + up);

            Vector3 forward = Transform.forward * inheritedScale.z * Scale.z;
            Gizmos.DrawLine(position - forward, position + forward);

            if (!isSelected && Label is not null)
                Handles.Label(position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
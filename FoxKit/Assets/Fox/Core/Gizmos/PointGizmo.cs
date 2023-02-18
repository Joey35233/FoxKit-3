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
            Gizmos.color = isSelected ? Color.white : Color;

            Debug.Assert(Enum.IsDefined(typeof(GizmoScaleMode), ScaleMode));
            Vector3 inheritedScale = ScaleMode switch
            {
                GizmoScaleMode.Explicit => Vector3.one,
                GizmoScaleMode.InheritLocal => transform.localScale,
                GizmoScaleMode.InheritWorld => transform.lossyScale,
                _ => Vector3.zero,
            };

            Vector3 position = transform.position;

            Vector3 right = transform.right * inheritedScale.x * Scale.x;
            Gizmos.DrawLine(position - right, position + right);

            Vector3 up = transform.up * inheritedScale.y * Scale.y;
            Gizmos.DrawLine(position - up, position + up);

            Vector3 forward = transform.forward * inheritedScale.z * Scale.z;
            Gizmos.DrawLine(position - forward, position + forward);

            if (DrawLabel)
                Handles.Label(position, gameObject.name);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
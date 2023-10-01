using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a sphere gizmo in the scene.
    /// </summary>
    public class SphereGizmo
    {
        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public string GizmoPath = null;
        public Color SelectedColor = EditorColors.GenericSelectedColor;
        public float Radius = 1.0f;
        public GUIStyle LabelStyle;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.matrix = Transform.localToWorldMatrix;

            if (isSelected)
            {
                Gizmos.color = SelectedColor;
                Gizmos.DrawWireSphere(Vector3.zero, Radius);
            }

            // TODO Store the GuiStyle in a global location
            if (LabelStyle == null)
            {
                LabelStyle = new GUIStyle();
                LabelStyle.alignment = TextAnchor.MiddleCenter;
                LabelStyle.normal.textColor = EditorColors.LabelIdleColor;
            }

            if (!String.IsNullOrEmpty(this.GizmoPath))
            {
                Gizmos.DrawIcon(Transform.position, GizmoPath, true);
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

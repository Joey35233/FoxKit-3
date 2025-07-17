using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a box gizmo in the scene.
    /// </summary>
    public class BoxGizmo
    {
        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public Color UnselectedColor = EditorColors.GenericUnselectedColor;
        public Color SelectedColor = EditorColors.GenericSelectedColor;
        public Vector3 Scale = Vector3.one;
        public GUIStyle LabelStyle;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.matrix = Transform.localToWorldMatrix;

            Color faceColor = isSelected ? SelectedColor : UnselectedColor;

            Gizmos.color = faceColor;
            Gizmos.DrawWireCube(Vector3.zero, Scale);

            // TODO Store the GuiStyle in a global location
            if (LabelStyle == null)
            {
                LabelStyle = new GUIStyle();
                LabelStyle.alignment = TextAnchor.MiddleCenter;
                LabelStyle.normal.textColor = EditorColors.LabelIdleColor;
            }

            if (!System.String.IsNullOrEmpty(this.Label))
            {
                Handles.Label(Transform.position, Label, LabelStyle);
            }
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

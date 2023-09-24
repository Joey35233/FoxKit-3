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
        public Color Color = Color.red;
        public Vector3 Scale = Vector3.one;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.matrix = Transform.localToWorldMatrix;

            Color faceColor = Color;
            faceColor.a = isSelected ? 0.5f : 0.25f;
            Gizmos.color = faceColor;
            Gizmos.DrawCube(Vector3.zero, Scale);

            Color edgeColor = isSelected ? Color.white : Color * 0.25f;
            edgeColor *= 0.25f;
            edgeColor.a = 1.0f;
            Gizmos.color = edgeColor;
            Gizmos.DrawWireCube(Vector3.zero, Scale);

            if (!isSelected && Label is not null)
                Handles.Label(Transform.position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

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
        public Color Color = Color.red;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.matrix = Transform.localToWorldMatrix;

            Color faceColor = Color;
            faceColor.a = isSelected ? 0.5f : 0.25f;
            Gizmos.color = faceColor;
            Gizmos.DrawSphere(Vector3.zero, 1.0f);

            Color edgeColor = Color;
            if (isSelected)
                edgeColor = Color.white;
            else
                edgeColor *= 0.25f;
            edgeColor.a = 1.0f;
            Gizmos.color = edgeColor;
            Gizmos.DrawWireSphere(Vector3.zero, 1.0f);

            if (!isSelected && Label is not null)
                Handles.Label(Transform.position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a sphere gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class SphereGizmo : MonoBehaviour
    {
        public Color Color = Color.red;

        public bool DrawLabel = false;

        private void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = transform.localToWorldMatrix;

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

            if (DrawLabel)
                Handles.Label(transform.position, gameObject.name);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

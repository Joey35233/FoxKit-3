using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class BoxGizmo : MonoBehaviour
    {
        public Color Color = Color.red;
        public bool DrawLabel = false;

        [HideInInspector]
        public Vector3 Scale = Vector3.one;

        private void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Color faceColor = Color;
            faceColor.a = isSelected ? 0.5f : 0.25f;
            Gizmos.color = faceColor;
            Gizmos.DrawCube(Vector3.zero, Scale);

            Color edgeColor = Color;
            if (isSelected)
                edgeColor = Color.white;
            else
                edgeColor *= 0.25f;
            edgeColor.a = 1.0f;
            Gizmos.color = edgeColor;
            Gizmos.DrawWireCube(Vector3.zero, Scale);

            if (DrawLabel)
                Handles.Label(transform.position, gameObject.name);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

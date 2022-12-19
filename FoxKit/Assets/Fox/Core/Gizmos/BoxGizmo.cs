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
        void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Color faceColor = Color;
            if (isSelected)
                faceColor.a = 0.5f;
            else
                faceColor.a = 0.25f;
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
                Handles.Label(this.transform.position, gameObject.name);
        }
        void OnDrawGizmos()
        {
            DrawGizmos(false);
        }

        void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}

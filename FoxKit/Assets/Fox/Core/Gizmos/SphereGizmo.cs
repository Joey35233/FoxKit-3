using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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

        void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Color faceColor = Color;
            if (isSelected)
                faceColor.a = 0.5f;
            else
                faceColor.a = 0.25f;
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

using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class SphereGizmo : MonoBehaviour
    {
        public Color LocatorColor = Color.red;
        void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Color sideColor = LocatorColor;
            if (isSelected)
                sideColor.a = 0.5f;
            else
                sideColor.a = 0.25f;
            Gizmos.color = sideColor;
            Gizmos.DrawSphere(Vector3.zero, 1.0f);
            Color lineColor = LocatorColor;
            if (isSelected)
                lineColor = Color.white;
            else
                lineColor.a = 1.0f;
            Gizmos.color = lineColor;
            Gizmos.DrawWireSphere(Vector3.zero, 1.0f);
            Handles.Label(transform.position, gameObject.name);
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

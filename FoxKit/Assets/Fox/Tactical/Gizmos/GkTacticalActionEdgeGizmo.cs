using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Tactical
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GkTacticalActionEdgeGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.yellow;
        public void OnDrawGizmos()
        {
            Vector3[] Waypoints = new Vector3[2]; //TODO

            Gizmos.color = Color;
            for (int i = 1; i < Waypoints.Length; i++)
            {
                if (i < Waypoints.Length)
                {
                    var pointFrom = transform.position + Waypoints[i - 1];
                    var pointTo = transform.position + Waypoints[i];
                    Gizmos.DrawLine(pointFrom, pointTo);
                }
            }
        }
    }
}

using UnityEngine;

namespace Fox.Tactical
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GkTacticalActionWaypointGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.green;

        [HideInInspector]
        public Vector3 Scale = Vector3.one * 0.5f;

        public void OnDrawGizmos()
        {
            Vector3[] Waypoints = new Vector3[2]; //TODO

            Gizmos.color = Color;
            for (int i = 0; i < Waypoints.Length; i++)
            {
                var worldPosition = transform.position + Waypoints[i];

                var right = Vector3.right * Scale.x;
                Gizmos.DrawLine(worldPosition - right, worldPosition + right);

                var up = Vector3.up * Scale.y;
                Gizmos.DrawLine(worldPosition - up, worldPosition + up);

                var forward = Vector3.forward * Scale.z;
                Gizmos.DrawLine(worldPosition - forward, worldPosition + forward);
            }
        }
    }
}

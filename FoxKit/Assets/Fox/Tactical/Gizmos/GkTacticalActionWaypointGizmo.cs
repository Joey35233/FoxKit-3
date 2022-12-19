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
            Gizmos.color = Color;
            var worldPosition = transform.position;//TODO

            var right = Vector3.right * Scale.x;
            Gizmos.DrawLine(worldPosition - right, worldPosition + right);

            var up = Vector3.up * Scale.y;
            Gizmos.DrawLine(worldPosition - up, worldPosition + up);

            var forward = Vector3.forward * Scale.z;
            Gizmos.DrawLine(worldPosition - forward, worldPosition + forward);
        }
    }
}

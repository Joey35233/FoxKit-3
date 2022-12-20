using UnityEditor;
using UnityEngine;

namespace Fox.Tactical
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GkTacticalActionGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Vector3[] Waypoints;
        [HideInInspector]
        public Color Color = Color.white;
        [HideInInspector]
        public Color ColorEdge = Color.yellow;
        [HideInInspector]
        public Color ColorWaypoint = new Color(0.0f, 0.5f, 0.0f);
        [HideInInspector]
        public Vector3 Scale = Vector3.one*0.5f;
        public void DrawGizmos(bool isSelected)
        {
            var rootPos = transform.position;

            //Get the entity
            var entityComponent = gameObject.GetComponent<Fox.Core.FoxEntity>();
            if (entityComponent == null)
                return;

            GkTacticalAction entity = entityComponent.Entity as GkTacticalAction;
            if (entity == null)
                return;

            //Root gizmo
            if (isSelected)
                Gizmos.color = Color;
            else
                Gizmos.color = Color * 0.5f;

            Gizmos.DrawWireCube(rootPos, Vector3.one * 0.25f);

            Waypoints = new Vector3[entity.waypoints.Count];

            //Draw waypoints and edges
            for (int i = 0; i < entity.waypoints.Count; i++)
            {
                var waypoint = entity.waypoints[i].Get();

                Waypoints[i] = transform.TransformPoint(new Vector3(-waypoint.position.x, waypoint.position.y, waypoint.position.z));

                Gizmos.color = ColorWaypoint;

                var right = Vector3.right * Scale.x;
                Gizmos.DrawLine(Waypoints[i] - right, Waypoints[i] + right);

                var up = Vector3.up * Scale.y;
                Gizmos.DrawLine(Waypoints[i] - up, Waypoints[i] + up);

                var forward = Vector3.forward * Scale.z;
                Gizmos.DrawLine(Waypoints[i] - forward, Waypoints[i] + forward);

                if (i > 0)
                {
                    Gizmos.color = ColorEdge;
                    Gizmos.DrawLine(Waypoints[i - 1], Waypoints[i]);
                }
            }
        }
        public void OnDrawGizmos()
        {
            DrawGizmos(false);
        }
        public void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
        public void Update()
        {
            //Get the entity
            var entityComponent = gameObject.GetComponent<Fox.Core.FoxEntity>();
            if (entityComponent == null)
                return;

            GkTacticalAction entity = entityComponent.Entity as GkTacticalAction;
            if (entity == null)
                return;

            for (int i = 0; i < entity.waypoints.Count; i++)
            {
                var newLocalPosition = transform.InverseTransformPoint(Waypoints[i]);

                entity.waypoints[i].Get().position = new Vector3(-newLocalPosition.x, newLocalPosition.y, newLocalPosition.z);
            }
        }
    }
}
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
    public class GkTacticalActionGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.white;
        [HideInInspector]
        public Color ColorEdge = Color.yellow;
        [HideInInspector]
        public Color ColorWaypoint = Color.green;
        [HideInInspector]
        public Vector3 Scale = Vector3.one*0.5f;
        public void DrawGizmos(bool isSelected)
        {
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

            Gizmos.DrawWireCube(transform.position, Vector3.one * 0.25f);

            //Draw waypoints and edges
            for (int i = 0; i < entity.waypoints.Count; i++)
            {
                var waypoint = entity.waypoints[i].Get();

                //but rotation???
                var worldPosition = transform.position + waypoint.position;
                if (isSelected)
                {
                    var newWorldPosition = Handles.PositionHandle(worldPosition, transform.rotation);
                    waypoint.position = newWorldPosition - transform.position;
                }

                Gizmos.color = ColorWaypoint;

                var right = Vector3.right * Scale.x;
                Gizmos.DrawLine(worldPosition - right, worldPosition + right);

                var up = Vector3.up * Scale.y;
                Gizmos.DrawLine(worldPosition - up, worldPosition + up);

                var forward = Vector3.forward * Scale.z;
                Gizmos.DrawLine(worldPosition - forward, worldPosition + forward);

                if (i > 0)
                {
                    var prevWaypoint = entity.waypoints[i - 1].Get();

                    Gizmos.color = ColorEdge;
                    var pointFrom = transform.position + prevWaypoint.position;
                    var pointTo = transform.position + waypoint.position;
                    Gizmos.DrawLine(pointFrom, pointTo);
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
    }
}

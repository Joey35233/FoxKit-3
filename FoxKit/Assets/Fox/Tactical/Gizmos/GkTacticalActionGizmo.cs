using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.Tactical
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GkTacticalActionGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.white;

        [HideInInspector]
        public Color EdgeColor = Color.yellow;

        [HideInInspector]
        public Color WaypointColor = new Color(0.0f, 0.5f, 0.0f);

        [HideInInspector]
        public Vector3 Scale = Vector3.one*0.5f;

        public void DrawGizmos(bool isSelected)
        {
            var rootPos = transform.position;

            //Get the entity
            var entityComponent = gameObject.GetComponent<FoxEntity>();
            if (entityComponent?.Entity is GkTacticalAction action)
            {
                //Root gizmo
                if (isSelected)
                    Gizmos.color = Color;
                else
                    Gizmos.color = Color * 0.5f;

                Gizmos.DrawWireCube(rootPos, Vector3.one * 0.25f);

                Vector3[] globalWaypointPositions = new Vector3[action.waypoints.Count];

                //Draw waypoints and edges
                for (int i = 0; i < action.waypoints.Count; i++)
                {
                    var waypoint = action.waypoints[i].Get();

                    globalWaypointPositions[i] = transform.TransformPoint(new Vector3(-waypoint.position.x, waypoint.position.y, waypoint.position.z));

                    Gizmos.color = WaypointColor;

                    var right = Vector3.right * Scale.x;
                    Gizmos.DrawLine(globalWaypointPositions[i] - right, globalWaypointPositions[i] + right);

                    var up = Vector3.up * Scale.y;
                    Gizmos.DrawLine(globalWaypointPositions[i] - up, globalWaypointPositions[i] + up);

                    var forward = Vector3.forward * Scale.z;
                    Gizmos.DrawLine(globalWaypointPositions[i] - forward, globalWaypointPositions[i] + forward);

                    if (i > 0)
                    {
                        Gizmos.color = EdgeColor;
                        Gizmos.DrawLine(globalWaypointPositions[i - 1], globalWaypointPositions[i]);
                    }
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
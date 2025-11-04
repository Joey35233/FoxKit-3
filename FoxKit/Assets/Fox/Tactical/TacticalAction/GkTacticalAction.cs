using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Tactical
{
    [System.Serializable]
    public partial class GkTacticalAction : Fox.Core.TransformData
    {
        public override void Reset()
        {
            base.Reset();
            enable = true;
            enableInGame = true;

        }
        private static readonly Color Color = Color.white;
        private static Color EdgeColor = Color.yellow;
        private static Color WaypointColor = new(0.0f, 0.5f, 0.0f);
        private static Vector3 Scale = Vector3.one * 0.5f;

        private void DrawGizmos(bool isSelected)
        {
            Vector3 rootPos = this.transform.position;

            //Root gizmo
            Gizmos.color = isSelected ? Color : Color * 0.5f;

            Gizmos.DrawWireCube(rootPos, Vector3.one * 0.25f);

            var globalWaypointPositions = new Vector3[waypoints.Count];

            //Draw waypoints and edges
            for (int i = 0; i < waypoints.Count; i++)
            {
                GkTacticalActionWaypoint waypoint = waypoints[i];

                if (waypoint is null)
                    return;

                globalWaypointPositions[i] = this.transform.TransformPoint(new Vector3(waypoint.position.x, waypoint.position.y, waypoint.position.z));

                Gizmos.color = isSelected? WaypointColor : WaypointColor * 0.5f;

                Vector3 right = Vector3.right * Scale.x;
                Gizmos.DrawLine(globalWaypointPositions[i] - right, globalWaypointPositions[i] + right);

                Vector3 up = Vector3.up * Scale.y;
                Gizmos.DrawLine(globalWaypointPositions[i] - up, globalWaypointPositions[i] + up);

                Vector3 forward = Vector3.forward * Scale.z;
                Gizmos.DrawLine(globalWaypointPositions[i] - forward, globalWaypointPositions[i] + forward);

                if (i > 0 && edges.Count>0)
                {
                    Gizmos.color = isSelected? EdgeColor : EdgeColor * 0.5f;
                    Gizmos.DrawLine(globalWaypointPositions[i - 1], globalWaypointPositions[i]);
                }
            }
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
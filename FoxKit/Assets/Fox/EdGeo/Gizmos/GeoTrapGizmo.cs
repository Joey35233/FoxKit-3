using Fox.Geo;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeo
{
    public static class GeoTrapGizmo
    {
        private const string GizmoPath = "../Fox/EdGeo/Gizmos/GeoTrap.png";

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GeoTrap geoTrap, GizmoType gizmoType)
        {
            Gizmos.DrawIcon(geoTrap.transform.position, GizmoPath);
        }
    }
}
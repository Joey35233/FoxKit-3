using UnityEditor;
using UnityEngine;

namespace Fox.Geo
{
	public partial class GeoTrap : Fox.Core.TransformData
	{
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(GeoTrap obj, GizmoType gizmoType)
        {
            Gizmos.DrawIcon(obj.transform.position, "Fox/Geo/GeoTrap.png");
        }
    }
}
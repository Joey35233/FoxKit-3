using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public static class SphereShapeGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(SphereShape sphereShape, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            Gizmos.DrawWireSphere(sphereShape.transform.position, sphereShape.radius);
        }
    }
}

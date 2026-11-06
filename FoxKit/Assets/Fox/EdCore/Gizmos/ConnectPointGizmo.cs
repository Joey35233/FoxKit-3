using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public static class ConnectPointGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(ConnectPoint connectPoint, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            Gizmos.DrawWireSphere(connectPoint.transform.position, 0.05f);
        }
    }
}

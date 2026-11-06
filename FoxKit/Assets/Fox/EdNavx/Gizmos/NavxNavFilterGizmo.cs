using Fox.EdCore;
using Fox.Navx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdNavx
{
    public static class NavxNavFilterGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(NavxNavFilter navFilter, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = navFilter.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}

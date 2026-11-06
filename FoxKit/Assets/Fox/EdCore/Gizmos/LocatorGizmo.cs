using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public static class LocatorGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(Locator locator, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;
            Gizmos.DrawWireSphere(locator.transform.position, locator.Size / 2f);
        }
    }
}

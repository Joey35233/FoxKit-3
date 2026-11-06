using Fox.EdCore;
using Fox.Fx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdFx
{
    public static class FxLocatorDataGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(FxLocatorData locatorData, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = locatorData.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}

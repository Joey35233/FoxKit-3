using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.EdCore
{
    public static class BoxShapeGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(BoxShape boxShape, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = boxShape.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}

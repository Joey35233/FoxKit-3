using Fox.EdCore;
using Fox.Geox;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeox
{
    public static class GeoxCollisionPyraidFreeShapeGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GeoxCollisionPyraidFreeShape shape, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = shape.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            Vector3[] points = shape.points;

            Gizmos.DrawLine(points[0], points[1]);
            Gizmos.DrawLine(points[1], points[2]);
            Gizmos.DrawLine(points[2], points[3]);
            Gizmos.DrawLine(points[3], points[0]);

            Gizmos.DrawLine(points[4], points[0]);
            Gizmos.DrawLine(points[4], points[1]);
            Gizmos.DrawLine(points[4], points[2]);
            Gizmos.DrawLine(points[4], points[3]);
        }
    }
}

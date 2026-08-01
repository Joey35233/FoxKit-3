using Fox.EdCore;
using Fox.Geox;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeox
{
    public static class GeoxDynamicPolygonGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GeoxDynamicPolygon polygon, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = polygon.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            var vertices = polygon.vertices;
            for (int i = 0; i < vertices.Count - 1; i++)
                Gizmos.DrawLine(vertices[i], vertices[i + 1]);
        }
    }
}

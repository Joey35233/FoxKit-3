using System.Collections.Generic;
using Fox.EdCore;
using Fox.Geo;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeo
{
    public static class CollisionPolyGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(CollisionPoly collisionPoly, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = collisionPoly.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            IReadOnlyList<Vector3> vertices = collisionPoly.Vertices;
            for (int i = 0; i < vertices.Count - 1; i++)
                Gizmos.DrawLine(vertices[i], vertices[i + 1]);
        }
    }
}

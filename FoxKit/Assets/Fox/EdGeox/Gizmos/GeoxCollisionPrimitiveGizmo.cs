using Fox.EdCore;
using Fox.Geox;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGeox
{
    public static class GeoxCollisionPrimitiveGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(GeoxCollisionPrimitive primitive, GizmoType gizmoType)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.matrix = primitive.transform.localToWorldMatrix;
            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : EditorColors.GenericUnselectedColor;

            switch (primitive.primitiveType)
            {
                case CollisionPrimitive_PrimType.PRIM_CIRCLE:
                    Gizmos.DrawSphere(Vector3.zero, 1);
                    break;
                case CollisionPrimitive_PrimType.PRIM_RECT:
                    Gizmos.DrawCube(Vector3.zero, Vector3.one);
                    break;
            }
        }
    }
}

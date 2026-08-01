using Fox.EdCore;
using Fox.Grx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGrx
{
    public static class PointLightGizmo
    {
        private static readonly Color SphereColor = new(0.765f, 0.22f, 0.961f);
        private static readonly Vector3 OriginScale = Vector3.one * 0.5f;

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(PointLight pointLight, GizmoType gizmoType)
        {
            DrawGizmos(pointLight.transform, gizmoType, pointLight.outerRange);
        }

        public static void DrawGizmos(Transform transform, GizmoType gizmoType, float outerRange)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : SphereColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            if (isSelected)
                Gizmos.DrawWireSphere(Vector3.zero, outerRange);
        }
    }
}

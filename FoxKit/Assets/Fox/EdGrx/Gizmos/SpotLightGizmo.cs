using Fox.EdCore;
using Fox.Grx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGrx
{
    public static class SpotLightGizmo
    {
        private static readonly Color UmbraColor = new(0.22f, 0.765f, 0.961f);
        private static readonly Color PenumbraColor = new(0.961f, 0.271f, 0.22f);
        private const float ShadowColorScale = 0.6f;
        private static readonly Vector3 OriginScale = Vector3.one * 0.5f;

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(SpotLight spotLight, GizmoType gizmoType)
        {
            DrawGizmos(
                spotLight.transform,
                gizmoType,
                spotLight.reachPoint.normalized,
                spotLight.umbraAngle,
                spotLight.penumbraAngle,
                spotLight.shadowUmbraAngle,
                spotLight.shadowPenumbraAngle,
                spotLight.outerRange);
        }

        public static void DrawGizmos(
            Transform transform,
            GizmoType gizmoType,
            Vector3 axis,
            float umbraAngle,
            float penumbraAngle,
            float shadowUmbraAngle,
            float shadowPenumbraAngle,
            float outerRange)
        {
            bool isSelected = (gizmoType & GizmoType.Selected) != 0;

            Gizmos.color = isSelected ? EditorColors.GenericSelectedColor : UmbraColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            if (!isSelected)
                return;

            DrawCone(transform, axis, outerRange, umbraAngle, UmbraColor);
            DrawCone(transform, axis, outerRange, penumbraAngle, PenumbraColor);
            DrawCone(transform, axis, outerRange, shadowUmbraAngle, UmbraColor * ShadowColorScale);
            DrawCone(transform, axis, outerRange, shadowPenumbraAngle, PenumbraColor * ShadowColorScale);
        }

        private static void DrawCone(Transform transform, Vector3 axis, float range, float angle, Color color)
        {
            Matrix4x4 basisMatrix = Fox.Math.GetOrthonormalBasisMatrix(axis);

            float halfAngle = Mathf.Clamp(angle * Mathf.Deg2Rad / 2, 1e-10f, Mathf.PI / 2);
            float r = range / Mathf.Cos(halfAngle / 2);
            float coneHeight = r * Mathf.Cos(halfAngle);
            float coneBaseRadius = r * Mathf.Sin(halfAngle);

            Gizmos.color = color;
            Gizmos.matrix = transform.localToWorldMatrix * basisMatrix;

            Vector3 unnormalizedAxis = Vector3.forward * coneHeight;

            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(-coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, coneBaseRadius, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, -coneBaseRadius, 0));

            Matrix4x4 squashMatrix = Matrix4x4.identity;
            squashMatrix[2, 2] = 0;
            squashMatrix[2, 3] = coneHeight;

            Gizmos.matrix = Gizmos.matrix * squashMatrix;
            Gizmos.DrawWireSphere(unnormalizedAxis, coneBaseRadius);
        }
    }
}

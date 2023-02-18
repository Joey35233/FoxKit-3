using Fox.Core;
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Grx
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class SpotLightGizmo : MonoBehaviour
    {
        [NonSerialized]
        public Color UmbraColor = new(0.22f, 0.765f, 0.961f);

        [NonSerialized]
        public Color PenumbraColor = new(0.961f, 0.271f, 0.22f);

        [NonSerialized]
        public float ShadowColorScale = 0.6f;

        public Color ShadowUmbraColor => UmbraColor * ShadowColorScale;
        public Color ShadowPenumbraColor => PenumbraColor * ShadowColorScale;

        [HideInInspector]
        public Vector3 OriginScale = Vector3.one * 0.5f;

        [NonSerialized]
        public bool DrawLabel = false;

        private void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<FoxEntity>()?.Entity is not SpotLight spotLight)
                return;

            Gizmos.matrix = transform.localToWorldMatrix;

            Vector3 axis = spotLight.reachPoint.normalized;

            Gizmos.color = UmbraColor;
            DrawCone(axis, spotLight.outerRange, spotLight.umbraAngle);

            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            Gizmos.color = PenumbraColor;
            DrawCone(axis, spotLight.outerRange, spotLight.penumbraAngle);

            Gizmos.color = ShadowUmbraColor;
            DrawCone(axis, spotLight.outerRange, spotLight.shadowUmbraAngle);

            Gizmos.color = ShadowPenumbraColor;
            DrawCone(axis, spotLight.outerRange, spotLight.shadowPenumbraAngle);
        }

        private void DrawCone(Vector3 axis, float range, float angle)
        {
            float halfAngle = angle * Mathf.Deg2Rad / 2;

            halfAngle = Mathf.Clamp(halfAngle, 1e-10f, Mathf.PI / 2);

            float r = range / Mathf.Cos(halfAngle / 2);

            float coneHeight = r * Mathf.Cos(halfAngle);
            float coneBaseRadius = r * Mathf.Sin(halfAngle);

            Vector3 unnormalizedAxis = axis * coneHeight;

            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(-coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, 0, coneBaseRadius));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, 0, -coneBaseRadius));

            // Could be a little dicey
            Handles.matrix = Gizmos.matrix;
            Handles.color = Gizmos.color;
            Handles.DrawWireDisc(unnormalizedAxis, axis, coneBaseRadius);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

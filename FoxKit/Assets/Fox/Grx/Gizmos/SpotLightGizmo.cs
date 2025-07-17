using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.Grx
{
    public class SpotLightGizmo
    {
        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public Vector3 Axis = Vector3.forward;
        public float OuterRange = 1;
        public float UmbraAngle = 5;
        public float PenumbraAngle = 10;
        public float ShadowUmbraAngle = 20;
        public float ShadowPenumbraAngle = 25;

        private Color UmbraColor = new(0.22f, 0.765f, 0.961f);
        private Color PenumbraColor = new(0.961f, 0.271f, 0.22f);
        private float ShadowColorScale = 0.6f;
        private Vector3 OriginScale = Vector3.one * 0.5f;

        private ConeGizmo Gizmo = new ConeGizmo();

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.color = isSelected ? Color.white : UmbraColor;
            Gizmos.matrix = Transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            if (isSelected)
            {
                Gizmo.Transform = Transform;
                Gizmo.Axis = Axis;
                Gizmo.Range = OuterRange;

                Gizmo.Color = UmbraColor;
                Gizmo.Angle = UmbraAngle;
                Gizmo.OnDrawGizmos();

                Gizmo.Color = PenumbraColor;
                Gizmo.Angle = PenumbraAngle;
                Gizmo.OnDrawGizmos();

                Gizmo.Color = UmbraColor * ShadowColorScale;
                Gizmo.Angle = ShadowUmbraAngle;
                Gizmo.OnDrawGizmos();

                Gizmo.Color = PenumbraColor * ShadowColorScale;
                Gizmo.Angle = ShadowPenumbraAngle;
                Gizmo.OnDrawGizmos();
            }

            if (!isSelected && Label is not null)
                Handles.Label(Transform.position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
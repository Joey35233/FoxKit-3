using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.Grx
{
    public class PointLightGizmo
    {
        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public float OuterRange = 1;
        private Color SphereColor = new(0.765f, 0.22f, 0.961f);
        private Vector3 OriginScale = Vector3.one * 0.5f;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.color = isSelected ? Color.white : SphereColor;
            Gizmos.matrix = Transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            if (isSelected)
                Gizmos.DrawWireSphere(Vector3.zero, OuterRange);

            if (!isSelected && Label is not null)
                Handles.Label(Transform.position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
using Fox;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a cone gizmo in the scene.
    /// </summary>
    public class ConeGizmo
    {
        public UnityEngine.Transform Transform = null;
        public string Label = null;
        public Vector3 Axis = Vector3.forward;
        public float Range = 1;
        public float Angle = 1;
        public Color Color = Color.red;

        private void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            Gizmos.color = isSelected ? Color.white : Color;

            Matrix4x4 basisMatrix = Math.GetOrthonormalBasisMatrix(Axis);

            float halfAngle = Angle * Mathf.Deg2Rad / 2;

            halfAngle = Mathf.Clamp(halfAngle, 1e-10f, Mathf.PI / 2);

            float r = Range / Mathf.Cos(halfAngle / 2);

            float coneHeight = r * Mathf.Cos(halfAngle);
            float coneBaseRadius = r * Mathf.Sin(halfAngle);

            Gizmos.matrix = Transform.localToWorldMatrix * basisMatrix;

            Vector3 unnormalizedAxis = Vector3.forward * coneHeight;

            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(-coneBaseRadius, 0, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, coneBaseRadius, 0));
            Gizmos.DrawLine(Vector3.zero, unnormalizedAxis + new Vector3(0, -coneBaseRadius, 0));

            // Squash sphere along forward axis and shift by coneHeight along forward
            Matrix4x4 squashMatrix = Matrix4x4.identity;
            squashMatrix[2, 2] = 0;
            squashMatrix[2, 3] = coneHeight;

            Gizmos.matrix = Gizmos.matrix * squashMatrix;
            Gizmos.DrawWireSphere(unnormalizedAxis, coneBaseRadius);

            if (!isSelected && Label is not null)
                Handles.Label(Transform.position, Label);
        }

        public void OnDrawGizmos() => DrawGizmos(false);

        public void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
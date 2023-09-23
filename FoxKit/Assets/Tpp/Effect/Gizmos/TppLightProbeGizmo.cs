using Fox.Core;
using System;
using UnityEngine;

namespace Tpp.Effect
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class TppLightProbeGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Vector3 OriginScale = Vector3.one * 0.5f;

        [NonSerialized]
        public bool DrawLabel = false;

        private void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<TppLightProbe>() is not { } lightProbe)
                return;

            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}

using UnityEditor;
using UnityEngine;
using Fox.Core;
using System;

namespace Tpp.Effect
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class TppLightProbeGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Vector3 OriginScale = Vector3.one * 0.5f;

        [NonSerialized]
        public bool DrawLabel = false;

        void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<FoxEntity>()?.Entity is not TppLightProbe lightProbe)
                return;

            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

        void OnDrawGizmos()
        {
            DrawGizmos(false);
        }

        void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}

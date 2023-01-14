using Fox.Grx;
using UnityEngine;
using Fox.Core;
using System;

namespace Tpp.Effect
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class TppPointLightGizmo : MonoBehaviour
    {
        [NonSerialized]
        public Color BoxColor = new Color(0.22f, 0.765f, 0.961f);

        [NonSerialized]
        public Color SphereColor = new Color(0.765f, 0.22f, 0.961f);

        [HideInInspector]
        public Vector3 OriginScale = Vector3.one * 0.5f;

        [NonSerialized]
        public bool DrawLabel = false;

        void DrawGizmos(bool isSelected)
        {
            if (gameObject.GetComponent<FoxEntity>()?.Entity is not TppPointLight pointLight)
                return;

            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = ColorUtils.AdjustColorForWhitePoint(6500, 0, pointLight.color, 1.5e+07f);
            Gizmos.DrawWireCube(Vector3.zero, OriginScale);

            Gizmos.color = SphereColor;
            Gizmos.DrawWireSphere(Vector3.zero, pointLight.outerRange);
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

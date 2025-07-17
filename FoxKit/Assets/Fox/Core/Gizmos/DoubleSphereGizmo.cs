using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a sphere gizmo with a second, outer radius in the scene.
    /// </summary>
    public class DoubleSphereGizmo : SphereGizmo
    {
        public float OuterRadius = 2.0f;
        public Color OuterRadiusColor = EditorColors.GenericSelectedColor;

        protected override void DrawGizmos(bool isSelected)
        {
            if (Transform is null)
                return;

            base.DrawGizmos(isSelected);

            if (isSelected)
            {
                Gizmos.color = OuterRadiusColor;
                Gizmos.DrawWireSphere(Vector3.zero, OuterRadius);
            }
        }
    }
}

using Fox.EdGrx;
using Tpp.Effect;
using UnityEditor;

namespace Tpp.EdEffect
{
    public static class TppPointLightGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(TppPointLight pointLight, GizmoType gizmoType)
        {
            PointLightGizmo.DrawGizmos(pointLight.transform, gizmoType, pointLight.outerRange);
        }
    }
}

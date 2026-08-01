using Fox.EdGrx;
using Tpp.Effect;
using UnityEditor;

namespace Tpp.EdEffect
{
    public static class TppSpotLightGizmo
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected | GizmoType.Pickable)]
        private static void DrawGizmo(TppSpotLight spotLight, GizmoType gizmoType)
        {
            SpotLightGizmo.DrawGizmos(
                spotLight.transform,
                gizmoType,
                spotLight.reachPoint.normalized,
                spotLight.umbraAngle,
                spotLight.penumbraAngle,
                spotLight.shadowUmbraAngle,
                spotLight.shadowPenumbraAngle,
                spotLight.outerRange);
        }
    }
}

using Fox.Core;
using Fox.Core.Utils;
using Fox.Kernel;
using UnityEngine;

namespace Fox.Grx
{
    public partial class SpotLight : Fox.Core.TransformData
    {
        private partial bool Get_enable() => FlagUtils.GetFlag(lightFlags, 0);
        private partial void Set_enable(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 0, value);

        private partial SpotLight_PackingGeneration Get_packingGeneration() => throw new System.NotImplementedException();
        private partial void Set_packingGeneration(SpotLight_PackingGeneration value)
        {
            if (value == SpotLight_PackingGeneration.GENERATION_ALL)
            {
                lightFlags |= 0xFF000000;
            }
            else
            {
                lightFlags ^= (uint)(-((int)value ^ lightFlags) & (0xFF << 24));
            }
        }

        private partial bool Get_castShadow() => FlagUtils.GetFlag(lightFlags, 1);
        private partial void Set_castShadow(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 1, value);

        private partial bool Get_isBounced() => FlagUtils.GetFlag(lightFlags, 2);
        private partial void Set_isBounced(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 2, value);

        private partial bool Get_showObject() => FlagUtils.GetFlag(lightFlags, 4);
        private partial void Set_showObject(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 4, value);

        private partial bool Get_showRange() => FlagUtils.GetFlag(lightFlags, 5);
        private partial void Set_showRange(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 5, value);

        private partial bool Get_isDebugLightVolumeBound() => FlagUtils.GetFlag(lightFlags, 6);
        private partial void Set_isDebugLightVolumeBound(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 6, value);

        private partial bool Get_useAutoDimmer() => FlagUtils.GetFlag(lightFlags, 7);
        private partial void Set_useAutoDimmer(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 7, value);

        private partial bool Get_hasSpecular() => FlagUtils.GetFlag(lightFlags, 3);
        private partial void Set_hasSpecular(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 3, value);

        private SpotLightGizmo Gizmo = new SpotLightGizmo();

        private void DrawGizmos(bool isSelected)
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = isSelected ? this.name : null;
            Gizmo.Axis = reachPoint.normalized;
            Gizmo.UmbraAngle = umbraAngle;
            Gizmo.PenumbraAngle = penumbraAngle;
            Gizmo.ShadowUmbraAngle = shadowUmbraAngle;
            Gizmo.ShadowPenumbraAngle = shadowPenumbraAngle;
            Gizmo.OuterRange = outerRange;

            if (isSelected)
                Gizmo.OnDrawGizmosSelected();
            else
                Gizmo.OnDrawGizmos();
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
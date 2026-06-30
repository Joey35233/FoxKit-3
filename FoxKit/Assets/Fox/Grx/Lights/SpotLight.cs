using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Grx
{
    public partial class SpotLight : Fox.Core.TransformData
    {
        private partial bool enable_Get() => FlagUtils.GetFlag(lightFlags, 0);
        private partial void enable_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 0, value);

        private partial SpotLight_PackingGeneration packingGeneration_Get() => throw new System.NotImplementedException();
        private partial void packingGeneration_Set(SpotLight_PackingGeneration value)
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

        private partial bool castShadow_Get() => FlagUtils.GetFlag(lightFlags, 1);
        private partial void castShadow_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 1, value);

        private partial bool isBounced_Get() => FlagUtils.GetFlag(lightFlags, 2);
        private partial void isBounced_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 2, value);

        private partial bool showObject_Get() => FlagUtils.GetFlag(lightFlags, 4);
        private partial void showObject_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 4, value);

        private partial bool showRange_Get() => FlagUtils.GetFlag(lightFlags, 5);
        private partial void showRange_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 5, value);

        private partial bool isDebugLightVolumeBound_Get() => FlagUtils.GetFlag(lightFlags, 6);
        private partial void isDebugLightVolumeBound_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 6, value);

        private partial bool useAutoDimmer_Get() => FlagUtils.GetFlag(lightFlags, 7);
        private partial void useAutoDimmer_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 7, value);

        private partial bool hasSpecular_Get() => FlagUtils.GetFlag(lightFlags, 3);
        private partial void hasSpecular_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 3, value);

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            reachPoint = Fox.Math.FoxToUnityVector3(reachPoint);
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(reachPoint), Fox.Math.UnityToFoxVector3(reachPoint));
        }

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
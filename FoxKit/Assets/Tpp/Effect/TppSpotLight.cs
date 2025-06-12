using Fox;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Grx;
using UnityEngine;
using CsSystem = System;

namespace Tpp.Effect
{
    public partial class TppSpotLight : Fox.Core.TransformData
    {
        private partial bool Get_enable() => throw new CsSystem.NotImplementedException();
        private partial void Set_enable(bool value) => throw new CsSystem.NotImplementedException();

        private partial TppSpotLight_PackingGeneration Get_packingGeneration() => throw new CsSystem.NotImplementedException();
        private partial void Set_packingGeneration(TppSpotLight_PackingGeneration value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_castShadow() => throw new CsSystem.NotImplementedException();
        private partial void Set_castShadow(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isBounced() => throw new CsSystem.NotImplementedException();
        private partial void Set_isBounced(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_showObject() => throw new CsSystem.NotImplementedException();
        private partial void Set_showObject(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_showRange() => throw new CsSystem.NotImplementedException();
        private partial void Set_showRange(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isDebugLightVolumeBound() => throw new CsSystem.NotImplementedException();
        private partial void Set_isDebugLightVolumeBound(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_useAutoDimmer() => throw new CsSystem.NotImplementedException();
        private partial void Set_useAutoDimmer(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_hasSpecular() => throw new CsSystem.NotImplementedException();
        private partial void Set_hasSpecular(bool value) => throw new CsSystem.NotImplementedException();

        private partial Path Get_importFilePath() => throw new CsSystem.NotImplementedException();
        private partial void Set_importFilePath(Path value) => throw new CsSystem.NotImplementedException();

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            reachPoint = Fox.Math.FoxToUnityVector3(reachPoint);
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

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

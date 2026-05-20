using Fox;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Grx;
using UnityEngine;
using CsSystem = System;

namespace Tpp.Effect
{
    public partial class TppPointLight : Fox.Core.TransformData
    {
        private partial bool Get_enable() => throw new CsSystem.NotImplementedException();
        private partial void Set_enable(bool value) => throw new CsSystem.NotImplementedException();

        private partial TppPointLight_PackingGeneration Get_packingGeneration() => throw new CsSystem.NotImplementedException();
        private partial void Set_packingGeneration(TppPointLight_PackingGeneration value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_castShadow() => throw new CsSystem.NotImplementedException();
        private partial void Set_castShadow(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isBounced() => throw new CsSystem.NotImplementedException();
        private partial void Set_isBounced(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_showObject() => throw new CsSystem.NotImplementedException();
        private partial void Set_showObject(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_showRange() => throw new CsSystem.NotImplementedException();
        private partial void Set_showRange(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isDebugLightVolumeBounding() => throw new CsSystem.NotImplementedException();
        private partial void Set_isDebugLightVolumeBounding(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_hasSpecular() => throw new CsSystem.NotImplementedException();
        private partial void Set_hasSpecular(bool value) => throw new CsSystem.NotImplementedException();

        private partial Path Get_importFilePath() => throw new CsSystem.NotImplementedException();
        private partial void Set_importFilePath(Path value) => throw new CsSystem.NotImplementedException();

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
        private PointLightGizmo Gizmo = new PointLightGizmo();

        private void DrawGizmos(bool isSelected)
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = isSelected ? this.name : null;
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

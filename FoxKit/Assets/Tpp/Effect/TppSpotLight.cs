using Fox;
using Fox.Core;
using Fox.Core.Utils;
using CsSystem = System;

namespace Tpp.Effect
{
    public partial class TppSpotLight : Fox.Core.TransformData
    {
        private partial bool enable_Get() => throw new CsSystem.NotImplementedException();
        private partial void enable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial TppSpotLight_PackingGeneration packingGeneration_Get() => throw new CsSystem.NotImplementedException();
        private partial void packingGeneration_Set(TppSpotLight_PackingGeneration value) => throw new CsSystem.NotImplementedException();

        private partial bool castShadow_Get() => throw new CsSystem.NotImplementedException();
        private partial void castShadow_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool isBounced_Get() => throw new CsSystem.NotImplementedException();
        private partial void isBounced_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool showObject_Get() => throw new CsSystem.NotImplementedException();
        private partial void showObject_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool showRange_Get() => throw new CsSystem.NotImplementedException();
        private partial void showRange_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool isDebugLightVolumeBound_Get() => throw new CsSystem.NotImplementedException();
        private partial void isDebugLightVolumeBound_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool useAutoDimmer_Get() => throw new CsSystem.NotImplementedException();
        private partial void useAutoDimmer_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool hasSpecular_Get() => throw new CsSystem.NotImplementedException();
        private partial void hasSpecular_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial Path importFilePath_Get() => throw new CsSystem.NotImplementedException();
        private partial void importFilePath_Set(Path value) => throw new CsSystem.NotImplementedException();

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
    }
}

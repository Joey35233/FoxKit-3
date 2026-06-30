using CsSystem = System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppAtmosphere : Fox.Core.Data
    {
        private partial bool useBakedData_Get() => throw new CsSystem.NotImplementedException();
        private partial void useBakedData_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool enable_Get() => throw new CsSystem.NotImplementedException();
        private partial void enable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool skyEnable_Get() => throw new CsSystem.NotImplementedException();
        private partial void skyEnable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool sunLightEnable_Get() => throw new CsSystem.NotImplementedException();
        private partial void sunLightEnable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool isCascadeBlend_Get() => throw new CsSystem.NotImplementedException();
        private partial void isCascadeBlend_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool castShadow_Get() => throw new CsSystem.NotImplementedException();
        private partial void castShadow_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool dirLightFade_Get() => throw new CsSystem.NotImplementedException();
        private partial void dirLightFade_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool disableSkyCapture_Get() => throw new CsSystem.NotImplementedException();
        private partial void disableSkyCapture_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool skyLightEnable_Get() => throw new CsSystem.NotImplementedException();
        private partial void skyLightEnable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool usePrecomputedAmbient_Get() => throw new CsSystem.NotImplementedException();
        private partial void usePrecomputedAmbient_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool fogEnable_Get() => throw new CsSystem.NotImplementedException();
        private partial void fogEnable_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool expandHorizontalLineColor_Get() => throw new CsSystem.NotImplementedException();
        private partial void expandHorizontalLineColor_Set(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool isSteppedMoveOfDirectionalLight_Get() => throw new CsSystem.NotImplementedException();
        private partial void isSteppedMoveOfDirectionalLight_Set(bool value) => throw new CsSystem.NotImplementedException();
        
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            fixedLightDirSunRise = Fox.Math.FoxToUnityVector3(fixedLightDirSunRise);
            fixedLightDirSunSet = Fox.Math.FoxToUnityVector3(fixedLightDirSunSet);
            fixedLightDirMoonRise = Fox.Math.FoxToUnityVector3(fixedLightDirMoonRise);
            fixedLightDirMoonSet = Fox.Math.FoxToUnityVector3(fixedLightDirMoonSet);
            fixedRisingSunDir = Fox.Math.FoxToUnityVector3(fixedRisingSunDir);
            fixedFallingSunDir = Fox.Math.FoxToUnityVector3(fixedFallingSunDir);
            fixedRisingMoonDir = Fox.Math.FoxToUnityVector3(fixedRisingMoonDir);
            fixedFallingMoonDir = Fox.Math.FoxToUnityVector3(fixedFallingMoonDir);
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            context.OverrideProperty(nameof(fixedLightDirSunRise), Fox.Math.UnityToFoxVector3(fixedLightDirSunRise));
            context.OverrideProperty(nameof(fixedLightDirSunSet), Fox.Math.UnityToFoxVector3(fixedLightDirSunSet));
            context.OverrideProperty(nameof(fixedLightDirMoonRise), Fox.Math.UnityToFoxVector3(fixedLightDirMoonRise));
            context.OverrideProperty(nameof(fixedLightDirMoonSet), Fox.Math.UnityToFoxVector3(fixedLightDirMoonSet));
            context.OverrideProperty(nameof(fixedRisingSunDir), Fox.Math.UnityToFoxVector3(fixedRisingSunDir));
            context.OverrideProperty(nameof(fixedFallingSunDir), Fox.Math.UnityToFoxVector3(fixedFallingSunDir));
            context.OverrideProperty(nameof(fixedRisingMoonDir), Fox.Math.UnityToFoxVector3(fixedRisingMoonDir));
            context.OverrideProperty(nameof(fixedFallingMoonDir), Fox.Math.UnityToFoxVector3(fixedFallingMoonDir));
        }
    }
}

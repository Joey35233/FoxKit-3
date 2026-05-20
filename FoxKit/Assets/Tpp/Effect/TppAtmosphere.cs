using CsSystem = System;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppAtmosphere : Fox.Core.Data
    {
        private partial bool Get_useBakedData() => throw new CsSystem.NotImplementedException();
        private partial void Set_useBakedData(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_enable() => throw new CsSystem.NotImplementedException();
        private partial void Set_enable(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_skyEnable() => throw new CsSystem.NotImplementedException();
        private partial void Set_skyEnable(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_sunLightEnable() => throw new CsSystem.NotImplementedException();
        private partial void Set_sunLightEnable(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isCascadeBlend() => throw new CsSystem.NotImplementedException();
        private partial void Set_isCascadeBlend(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_castShadow() => throw new CsSystem.NotImplementedException();
        private partial void Set_castShadow(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_dirLightFade() => throw new CsSystem.NotImplementedException();
        private partial void Set_dirLightFade(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_disableSkyCapture() => throw new CsSystem.NotImplementedException();
        private partial void Set_disableSkyCapture(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_skyLightEnable() => throw new CsSystem.NotImplementedException();
        private partial void Set_skyLightEnable(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_usePrecomputedAmbient() => throw new CsSystem.NotImplementedException();
        private partial void Set_usePrecomputedAmbient(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_fogEnable() => throw new CsSystem.NotImplementedException();
        private partial void Set_fogEnable(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_expandHorizontalLineColor() => throw new CsSystem.NotImplementedException();
        private partial void Set_expandHorizontalLineColor(bool value) => throw new CsSystem.NotImplementedException();

        private partial bool Get_isSteppedMoveOfDirectionalLight() => throw new CsSystem.NotImplementedException();
        private partial void Set_isSteppedMoveOfDirectionalLight(bool value) => throw new CsSystem.NotImplementedException();
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

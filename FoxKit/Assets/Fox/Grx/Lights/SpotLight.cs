using Fox.Core;
using Fox.Core.Utils;

namespace Fox.Grx
{
    public partial class SpotLight : Fox.Core.TransformData
    {
        public float LodFarSizeValue { get => LodFarSize; set => LodFarSize = value; }
        public float LodNearSizeValue { get => LodNearSize; set => LodNearSize = value; }
        public float LodShadowDrawRateValue { get => LodShadowDrawRate; set => LodShadowDrawRate = value; }
        public float AttenuationExponent { get => attenuationExponent; set => attenuationExponent = value; }
        public UnityEngine.Color Color { get => color; set => color = value; }
        public float ColorDeflection { get => colorDeflection; set => colorDeflection = value; }
        public float Dimmer { get => dimmer; set => dimmer = value; }
        public float InnerRange { get => innerRange; set => innerRange = value; }
        public Fox.Core.EntityLink IrradiationPoint { get => irradiationPoint; set => irradiationPoint = value; }
        public Fox.Core.EntityLink LightArea { get => lightArea; set => lightArea = value; }
        public float LightSize { get => lightSize; set => lightSize = value; }
        public byte LodFadeType { get => lodFadeType; set => lodFadeType = value; }
        public SpotLight_LodRadiusLevel LodRadiusLevel { get => lodRadiusLevel; set => lodRadiusLevel = value; }
        public float Lumen { get => lumen; set => lumen = value; }
        public float OuterRange { get => outerRange; set => outerRange = value; }
        public float PenumbraAngle { get => penumbraAngle; set => penumbraAngle = value; }
        public float PowerScale { get => powerScale; set => powerScale = value; }
        public UnityEngine.Vector3 ReachPoint { get => reachPoint; set => reachPoint = value; }
        public float ShadowAttenuationExponent { get => shadowAttenuationExponent; set => shadowAttenuationExponent = value; }
        public float ShadowBias { get => shadowBias; set => shadowBias = value; }
        public float ShadowPenumbraAngle { get => shadowPenumbraAngle; set => shadowPenumbraAngle = value; }
        public float ShadowUmbraAngle { get => shadowUmbraAngle; set => shadowUmbraAngle = value; }
        public float Temperature { get => temperature; set => temperature = value; }
        public float UmbraAngle { get => umbraAngle; set => umbraAngle = value; }
        public float ViewBias { get => viewBias; set => viewBias = value; }

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
    }
}
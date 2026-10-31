using Fox.Core.Utils;
using Fox.Core;

namespace Fox.Grx
{
    public partial class PointLight : Fox.Core.TransformData
    {
        public float LodFarSizeValue { get => LodFarSize; set => LodFarSize = value; }
        public float LodNearSizeValue { get => LodNearSize; set => LodNearSize = value; }
        public float LodShadowDrawRateValue { get => LodShadowDrawRate; set => LodShadowDrawRate = value; }
        public UnityEngine.Color Color { get => color; set => color = value; }
        public float ColorDeflection { get => colorDeflection; set => colorDeflection = value; }
        public float Dimmer { get => dimmer; set => dimmer = value; }
        public float InnerRange { get => innerRange; set => innerRange = value; }
        public Fox.Core.EntityLink LightArea { get => lightArea; set => lightArea = value; }
        public float LightSize { get => lightSize; set => lightSize = value; }
        public byte LodFadeType { get => lodFadeType; set => lodFadeType = value; }
        public PointLight_LodRadiusLevel LodRadiusLevel { get => lodRadiusLevel; set => lodRadiusLevel = value; }
        public float Lumen { get => lumen; set => lumen = value; }
        public float OuterRange { get => outerRange; set => outerRange = value; }
        public UnityEngine.Vector3 ReachPoint { get => reachPoint; set => reachPoint = value; }
        public float ShadowBias { get => shadowBias; set => shadowBias = value; }
        public float Temperature { get => temperature; set => temperature = value; }

        private partial bool enable_Get() => FlagUtils.GetFlag(lightFlags, 0);
        private partial void enable_Set(bool value) => lightFlags = FlagUtils.SetFlag(lightFlags, 0, value);

        private partial PointLight_PackingGeneration packingGeneration_Get()
        {
            sbyte packingGeneration = (sbyte)(lightFlags >> 24);
            return packingGeneration == -1 ? PointLight_PackingGeneration.GENERATION_ALL : (PointLight_PackingGeneration)packingGeneration;
        }
        private partial void packingGeneration_Set(PointLight_PackingGeneration value)
        {
            if (value == PointLight_PackingGeneration.GENERATION_ALL)
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
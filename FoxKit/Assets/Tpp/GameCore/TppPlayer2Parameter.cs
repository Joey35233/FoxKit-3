namespace Tpp.GameCore
{
    public partial class TppPlayer2Parameter
    {
        public uint ClipCount { get => clipCount; set => clipCount = value; }
        public float FireInterval { get => fireInterval; set => fireInterval = value; }
        public uint LifeMax { get => lifeMax; set => lifeMax = value; }
        public float LifeRecoveryCooldownTimer { get => lifeRecoveryCooldownTimer; set => lifeRecoveryCooldownTimer = value; }
        public float LifeRecoveryPerSecond { get => lifeRecoveryPerSecond; set => lifeRecoveryPerSecond = value; }
        public float RespawnTime { get => respawnTime; set => respawnTime = value; }
        public Fox.StringMap<Fox.Core.FilePtr> VfxFiles => vfxFiles;
    }
}

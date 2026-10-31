namespace Fox.Sim
{
    public partial class SimEngineOnPhysicsParam
    {
        public bool ConvertMoveToWind { get => convertMoveToWind; set => convertMoveToWind = value; }
        public bool IsEnableGeoCheck { get => isEnableGeoCheck; set => isEnableGeoCheck = value; }
        public SimLodLevelName MaxLodLevel { get => maxLodLevel; set => maxLodLevel = value; }
        public SimLodLevelName MinLodLevel { get => minLodLevel; set => minLodLevel = value; }
    }
}

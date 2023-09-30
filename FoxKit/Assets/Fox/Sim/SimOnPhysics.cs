namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject
    {
        private SimEngineOnPhysicsParam simEngineOnPhysics => engineParam as SimEngineOnPhysicsParam;

        private partial SimLodLevelName Get_minLodLevel() => simEngineOnPhysics.minLodLevel;
        private partial void Set_minLodLevel(SimLodLevelName value) => simEngineOnPhysics.minLodLevel = value;

        private partial SimLodLevelName Get_maxLodLevel() => simEngineOnPhysics.maxLodLevel;
        private partial void Set_maxLodLevel(SimLodLevelName value) => simEngineOnPhysics.maxLodLevel = value;

        private partial bool Get_isEnableGeoCheck() => simEngineOnPhysics.isEnableGeoCheck;
        private partial void Set_isEnableGeoCheck(bool value) => simEngineOnPhysics.isEnableGeoCheck = value;

        private partial bool Get_convertMoveToWind() => simEngineOnPhysics.convertMoveToWind;
        private partial void Set_convertMoveToWind(bool value) => simEngineOnPhysics.convertMoveToWind = value;
    }
}

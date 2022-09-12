using Fox.Core;

namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject
    {
        private SimEngineOnPhysicsParam simEngineOnPhysics => (engineParam.Get() as SimEngineOnPhysicsParam);

        protected partial SimLodLevelName Get_minLodLevel() => simEngineOnPhysics.minLodLevel;
        protected partial void Set_minLodLevel(SimLodLevelName value) { simEngineOnPhysics.minLodLevel = value; }

        protected partial SimLodLevelName Get_maxLodLevel() => simEngineOnPhysics.maxLodLevel;
        protected partial void Set_maxLodLevel(SimLodLevelName value) { simEngineOnPhysics.maxLodLevel = value; }

        protected partial bool Get_isEnableGeoCheck() => simEngineOnPhysics.isEnableGeoCheck;
        protected partial void Set_isEnableGeoCheck(bool value) => simEngineOnPhysics.isEnableGeoCheck = value;

        protected partial bool Get_convertMoveToWind() => simEngineOnPhysics.convertMoveToWind;
        protected partial void Set_convertMoveToWind(bool value) => simEngineOnPhysics.convertMoveToWind = value;
    }
}

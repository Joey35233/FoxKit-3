namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject
    {
        private SimEngineOnPhysicsParam param => engineParam as SimEngineOnPhysicsParam;

        private partial SimLodLevelName minLodLevel_Get() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.minLodLevel;
        private partial void minLodLevel_Set(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.minLodLevel = value;
        }

        private partial SimLodLevelName maxLodLevel_Get() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.maxLodLevel;
        private partial void maxLodLevel_Set(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.maxLodLevel = value;
        }

        private partial bool isEnableGeoCheck_Get() => param == null ? false : param.isEnableGeoCheck;
        private partial void isEnableGeoCheck_Set(bool value)
        {
            if (param == null)
                return;
            
            param.isEnableGeoCheck = value;
        }

        private partial bool convertMoveToWind_Get() => param == null ? false : param.convertMoveToWind;
        private partial void convertMoveToWind_Set(bool value)
        {
            if (param == null)
                return;
            
            param.convertMoveToWind = value;
        }
    }
}

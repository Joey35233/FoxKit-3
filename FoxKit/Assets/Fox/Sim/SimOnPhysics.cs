namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject
    {
        private SimEngineOnPhysicsParam param => engineParam as SimEngineOnPhysicsParam;

        private partial SimLodLevelName minLodLevel_Get() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.MinLodLevel;
        private partial void minLodLevel_Set(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.MinLodLevel = value;
        }

        private partial SimLodLevelName maxLodLevel_Get() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.MaxLodLevel;
        private partial void maxLodLevel_Set(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.MaxLodLevel = value;
        }

        private partial bool isEnableGeoCheck_Get() => param == null ? false : param.IsEnableGeoCheck;
        private partial void isEnableGeoCheck_Set(bool value)
        {
            if (param == null)
                return;
            
            param.IsEnableGeoCheck = value;
        }

        private partial bool convertMoveToWind_Get() => param == null ? false : param.ConvertMoveToWind;
        private partial void convertMoveToWind_Set(bool value)
        {
            if (param == null)
                return;
            
            param.ConvertMoveToWind = value;
        }
    }
}

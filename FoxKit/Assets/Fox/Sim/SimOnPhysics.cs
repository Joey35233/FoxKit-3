namespace Fox.Sim
{
    public partial class SimOnPhysics : Fox.Sim.SimObject
    {
        private SimEngineOnPhysicsParam param => engineParam as SimEngineOnPhysicsParam;

        private partial SimLodLevelName Get_minLodLevel() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.minLodLevel;
        private partial void Set_minLodLevel(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.minLodLevel = value;
        }

        private partial SimLodLevelName Get_maxLodLevel() => param == null ? SimLodLevelName.SIM_UPDATE_SIMPLE : param.maxLodLevel;
        private partial void Set_maxLodLevel(SimLodLevelName value)
        {
            if (param == null)
                return;
            
            param.maxLodLevel = value;
        }

        private partial bool Get_isEnableGeoCheck() => param == null ? false : param.isEnableGeoCheck;
        private partial void Set_isEnableGeoCheck(bool value)
        {
            if (param == null)
                return;
            
            param.isEnableGeoCheck = value;
        }

        private partial bool Get_convertMoveToWind() => param == null ? false : param.convertMoveToWind;
        private partial void Set_convertMoveToWind(bool value)
        {
            if (param == null)
                return;
            
            param.convertMoveToWind = value;
        }
    }
}

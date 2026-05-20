namespace Fox.Sim
{
    public partial class SimClothControl : Fox.Sim.SimControlElement
    {
        private SimClothControlParam param => controlParam;

        private partial float Get_windCoefficient() => param == null ? 1.0f : param.GetWindCoefficient();
        private partial void Set_windCoefficient(float value)
        {
            if (param == null)
                return;
            
            param.SetWindCoefficient(value);
        }

        private partial bool Get_isLoop() => param == null ? false : param.GetIsLoop();
        private partial void Set_isLoop(bool value)
        {
            if (param == null)
                return;
            
            param.SetIsLoop(value);
        }
    }
}

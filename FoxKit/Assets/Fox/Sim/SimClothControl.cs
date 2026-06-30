namespace Fox.Sim
{
    public partial class SimClothControl : Fox.Sim.SimControlElement
    {
        private SimClothControlParam param => controlParam;

        private partial float windCoefficient_Get() => param == null ? 1.0f : param.GetWindCoefficient();
        private partial void windCoefficient_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetWindCoefficient(value);
        }

        private partial bool isLoop_Get() => param == null ? false : param.GetIsLoop();
        private partial void isLoop_Set(bool value)
        {
            if (param == null)
                return;
            
            param.SetIsLoop(value);
        }
    }
}

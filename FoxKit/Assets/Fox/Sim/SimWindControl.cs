namespace Fox.Sim
{
    public partial class SimWindControl : Fox.Sim.SimControlElement
    {
        private SimWindControlParam param => controlParam;

        private partial float windCoefficient_Get() => param == null ? 1.0f : param.GetCoefficient();
        private partial void windCoefficient_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetCoefficient(value);
        }
    }
}

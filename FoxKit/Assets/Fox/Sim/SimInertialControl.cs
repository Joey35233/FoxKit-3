namespace Fox.Sim
{
    public partial class SimInertialControl : Fox.Sim.SimControlElement
    {
        private SimInertialControlParam param => controlParam;

        private partial float inertialCoefficient_Get() => param == null ? 1.0f : param.GetCoefficient();
        private partial void inertialCoefficient_Set(float value)
        {
            if (param == null)
                return;
            
            param.SetCoefficient(value);
        }
    }
}

namespace Fox.Sim
{
    public partial class SimInertialControl : Fox.Sim.SimControlElement
    {
        private SimInertialControlParam param => controlParam;

        private partial float Get_inertialCoefficient() => param == null ? 1.0f : param.GetCoefficient();
        private partial void Set_inertialCoefficient(float value)
        {
            if (param == null)
                return;
            
            param.SetCoefficient(value);
        }
    }
}

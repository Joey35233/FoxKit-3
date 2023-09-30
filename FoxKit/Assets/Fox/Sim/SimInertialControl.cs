namespace Fox.Sim
{
    public partial class SimInertialControl : Fox.Sim.SimControlElement
    {
        private SimInertialControlParam param => controlParam;

        private partial float Get_inertialCoefficient() => param.GetCoefficient();
        private partial void Set_inertialCoefficient(float value) => param.SetCoefficient(value);
    }
}

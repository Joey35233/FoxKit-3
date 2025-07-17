namespace Fox.Sim
{
    public partial class SimWindControl : Fox.Sim.SimControlElement
    {
        private SimWindControlParam param => controlParam;

        private partial float Get_windCoefficient() => param.GetCoefficient();
        private partial void Set_windCoefficient(float value) => param.SetCoefficient(value);
    }
}

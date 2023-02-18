namespace Fox.Sim
{
    public partial class SimWindControlParam : Fox.Sim.SimControlParam
    {
        internal float GetCoefficient() => coefficient;
        internal void SetCoefficient(float value) => coefficient = value;
    }
}

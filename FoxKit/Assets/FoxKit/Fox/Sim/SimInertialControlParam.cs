using Fox.Core;

namespace Fox.Sim
{
    public partial class SimInertialControlParam : Fox.Sim.SimControlParam
    {
        internal float GetCoefficient() => coefficient;
        internal void SetCoefficient(float value) => coefficient = value;
    }
}

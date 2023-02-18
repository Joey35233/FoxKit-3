namespace Fox.Sim
{
    public partial class SimClothControlParam : Fox.Sim.SimControlParam
    {
        internal float GetWindCoefficient() => windCoefficient;
        internal void SetWindCoefficient(float value) => windCoefficient = value;

        internal bool GetIsLoop() => isLoop;
        internal void SetIsLoop(bool value) => isLoop = value;
    }
}

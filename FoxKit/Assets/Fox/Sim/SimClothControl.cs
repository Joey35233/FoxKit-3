namespace Fox.Sim
{
    public partial class SimClothControl : Fox.Sim.SimControlElement
    {
        private SimClothControlParam param => controlParam.Get();

        private partial float Get_windCoefficient() => param.GetWindCoefficient();
        private partial void Set_windCoefficient(float value) => param.SetWindCoefficient(value);

        private partial bool Get_isLoop() => param.GetIsLoop();
        private partial void Set_isLoop(bool value) => param.SetIsLoop(value);
    }
}

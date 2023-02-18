namespace Fox.Sim
{
    public partial class SimClothControl : Fox.Sim.SimControlElement
    {
        private SimClothControlParam param => controlParam.Get();

        protected partial float Get_windCoefficient() => param.GetWindCoefficient();
        protected partial void Set_windCoefficient(float value) => param.SetWindCoefficient(value);

        protected partial bool Get_isLoop() => param.GetIsLoop();
        protected partial void Set_isLoop(bool value) => param.SetIsLoop(value);
    }
}

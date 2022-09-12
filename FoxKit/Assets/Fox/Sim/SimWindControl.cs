using Fox.Core;

namespace Fox.Sim
{
    public partial class SimWindControl : Fox.Sim.SimControlElement
    {
        private SimWindControlParam param => (controlParam.Get() as SimWindControlParam);

        protected partial float Get_windCoefficient() => param.GetCoefficient();
        protected partial void Set_windCoefficient(float value) { param.SetCoefficient(value); }
    }
}

namespace Fox.Sim
{
    public partial class SimWindControl : Fox.Sim.SimControlElement
    {
        private SimWindControlParam param => controlParam;

        private partial float Get_windCoefficient() => param == null ? 1.0f : param.GetCoefficient();
        private partial void Set_windCoefficient(float value)
        {
            if (param == null)
                return;
            
            param.SetCoefficient(value);
        }
    }
}

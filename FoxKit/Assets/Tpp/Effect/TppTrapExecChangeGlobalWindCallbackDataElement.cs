namespace Tpp.Effect
{
    public partial class TppTrapExecChangeGlobalWindCallbackDataElement
    {
        public override void Reset()
        {
            base.Reset();
            funcName = "ChangeGlobalWind";
            //afgh WindParameter has Vector3 velocity(0,0,3)
            speed = 3;
            rotation = UnityEngine.Quaternion.identity;
            //afgh WindParameter
            speedTurbulentRate = 0.5f;
            speedTurbulentCycle = 0.1f;
            rotTurbulentRate = 0.1f;
            rotTurbulentCycle = 0.01f;
            interpTime = 3;
        }
    }
}

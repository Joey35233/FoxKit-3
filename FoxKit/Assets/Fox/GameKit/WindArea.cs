namespace Fox.GameKit
{
    public partial class WindArea : Fox.GameKit.EnvironmentArea
    {
        private WindParameter windParameter => parameter.Get() as WindParameter;

        private partial float Get_influenceOfGlobal() => windParameter.GetInfluenceOfGlobal();
        private partial void Set_influenceOfGlobal(float value) => windParameter.SetInfluenceOfGlobal(value);
    }
}
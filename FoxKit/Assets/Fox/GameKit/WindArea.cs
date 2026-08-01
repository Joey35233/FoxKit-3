namespace Fox.GameKit
{
    public partial class WindArea : Fox.GameKit.EnvironmentArea
    {
        private WindParameter windParameter => parameter as WindParameter;

        private partial float influenceOfGlobal_Get() => windParameter.GetInfluenceOfGlobal();
        private partial void influenceOfGlobal_Set(float value) => windParameter.SetInfluenceOfGlobal(value);
    }
}
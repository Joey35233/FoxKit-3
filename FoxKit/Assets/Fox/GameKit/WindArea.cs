using Fox.Core;

namespace Fox.GameKit
{
    public partial class WindArea : Fox.GameKit.EnvironmentArea
    {
        private WindParameter windParameter => (parameter.Get() as WindParameter);

        protected partial float Get_influenceOfGlobal() => windParameter.GetInfluenceOfGlobal();
        protected partial void Set_influenceOfGlobal(float value) => windParameter.SetInfluenceOfGlobal(value);
    }
}
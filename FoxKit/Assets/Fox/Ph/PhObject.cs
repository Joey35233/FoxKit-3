using Fox.Kernel;

namespace Fox.Ph
{
    public partial class PhObject : Fox.Core.TransformData
    {
        private PhObjectParam objectParam => param.Get();

        private partial String Get_worldName() => objectParam.GetWorldName();
        private partial void Set_worldName(String value) => objectParam.SetWorldName(value);
    }
}
using Fox.Core;
using Fox.Kernel;

namespace Fox.Ph
{
    public partial class PhObject : Fox.Core.TransformData
    {
        private PhObjectParam objectParam => (param.Get() as PhObjectParam);

        protected partial String Get_worldName() => objectParam.GetWorldName();
        protected partial void Set_worldName(String value) { objectParam.SetWorldName(value); }
    }
}
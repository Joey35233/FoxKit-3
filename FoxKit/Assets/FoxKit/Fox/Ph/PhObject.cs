using Fox.Core;

namespace Fox.Ph
{
    public partial class PhObject : Fox.Core.TransformData
    {
        private PhObjectParam objectParam => (param.Get() as PhObjectParam);

        protected partial Fox.Core.String Get_worldName() => objectParam.GetWorldName();
        protected partial void Set_worldName(Fox.Core.String value) { objectParam.SetWorldName(value); }
    }
}
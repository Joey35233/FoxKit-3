using Fox;

namespace Fox.Ph
{
    public partial class PhObject : Fox.Core.TransformData
    {
        private PhObjectParam objectParam => param;

        private partial string Get_worldName() => objectParam == null ? string.Empty : objectParam.GetWorldName();
        private partial void Set_worldName(string value)
        {
            if (param == null)
                return;

            objectParam.SetWorldName(value);
        }
    }
}
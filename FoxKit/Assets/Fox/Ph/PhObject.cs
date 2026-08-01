using Fox;

namespace Fox.Ph
{
    public partial class PhObject : Fox.Core.TransformData
    {
        private PhObjectParam objectParam => param;

        private partial string worldName_Get() => objectParam == null ? string.Empty : objectParam.GetWorldName();
        private partial void worldName_Set(string value)
        {
            if (param == null)
                return;

            objectParam.SetWorldName(value);
        }
    }
}
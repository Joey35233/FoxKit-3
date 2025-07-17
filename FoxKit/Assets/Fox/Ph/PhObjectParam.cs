using Fox;

namespace Fox.Ph
{
    public partial class PhObjectParam : Fox.Core.Entity
    {
        internal string GetWorldName() => worldName;
        internal void SetWorldName(string value) => worldName = value;
    }
}

using Fox.Core;

namespace Fox.Ph
{
    public partial class PhObjectParam : Fox.Core.Entity
    {
        internal Fox.Core.String GetWorldName() => worldName;
        internal void SetWorldName(Fox.Core.String value) { worldName = value; }
    }
}

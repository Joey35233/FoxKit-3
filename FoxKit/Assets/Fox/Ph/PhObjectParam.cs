using Fox.Core;
using Fox.Kernel;

namespace Fox.Ph
{
    public partial class PhObjectParam : Fox.Core.Entity
    {
        internal String GetWorldName() => worldName;
        internal void SetWorldName(String value) { worldName = value; }
    }
}

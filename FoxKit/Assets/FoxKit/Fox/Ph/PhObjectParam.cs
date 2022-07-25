using Fox.Core;
using Fox.FoxKernel;

namespace Fox.Ph
{
    public partial class PhObjectParam : Fox.Core.Entity
    {
        internal String GetWorldName() => worldName;
        internal void SetWorldName(String value) { worldName = value; }
    }
}

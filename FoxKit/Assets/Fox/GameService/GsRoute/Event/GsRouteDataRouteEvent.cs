using Fox.Core;
using Fox;

namespace Fox.GameService
{
    public abstract partial class GsRouteDataRouteEvent : DataElement
    {
        public abstract StrCode32 GetId();

        public virtual uint[] Serialize() => new uint[4];
    }
}
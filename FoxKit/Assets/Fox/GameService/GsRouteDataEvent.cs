using System;

namespace Fox.GameService
{
    public partial class GsRouteDataEvent
    {
        public virtual void WriteExtensions(Span<uint> destination)
        {
            extensions.AsSpan(0, GameServiceModule.ExtensionCount).CopyTo(destination);
        }

        public string Id { get => id; set => id = value; }
    }
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSwitchRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SwitchRoute");
		public override StrCode32 GetId() => Id;

		public static TppRouteSwitchRouteNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteSwitchRouteNodeEvent
            {
                routeId = reader.ReadUInt32(),
                function = reader.ReadUInt32(),
                argument = reader.ReadUInt32(),
            };

            reader.SkipPadding(4);

            return result;
        }
    }
}

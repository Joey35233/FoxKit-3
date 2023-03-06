using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleBackFast");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleBackFastEdgeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteVehicleBackFastEdgeEvent { railId = new String(reader.ReadStrCode32().ToString()), rpm = reader.ReadUInt32() };

            reader.SkipPadding(8);

            return result;
        }
    }
}

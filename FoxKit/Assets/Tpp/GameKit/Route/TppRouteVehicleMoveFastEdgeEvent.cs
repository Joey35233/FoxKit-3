using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveFast");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleMoveFastEdgeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteVehicleMoveFastEdgeEvent { railId = new String(reader.ReadStrCode32().ToString()), rpm = reader.ReadUInt32() };

            reader.SkipPadding(8);

            return result;
        }
    }
}

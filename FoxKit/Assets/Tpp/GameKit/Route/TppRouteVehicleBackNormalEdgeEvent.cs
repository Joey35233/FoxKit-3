using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackNormalEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleBackNormal");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleBackNormalEdgeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteVehicleBackNormalEdgeEvent { railId = new String(reader.ReadStrCode32().ToString()), rpm = reader.ReadUInt32() };

            reader.SkipPadding(8);

            return result;
        }
    }
}

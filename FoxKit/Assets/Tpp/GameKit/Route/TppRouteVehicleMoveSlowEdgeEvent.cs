using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveSlowEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveSlow");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleMoveSlowEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteVehicleMoveSlowEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

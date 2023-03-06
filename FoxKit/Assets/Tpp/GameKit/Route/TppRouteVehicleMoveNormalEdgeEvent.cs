using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveNormalEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveNormal");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleMoveNormalEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteVehicleMoveNormalEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleAntiPlayerFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleAntiPlayerFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleAntiPlayerFireNodeEvent Deserialize(FileStreamReader reader) => new TppRouteVehicleAntiPlayerFireNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

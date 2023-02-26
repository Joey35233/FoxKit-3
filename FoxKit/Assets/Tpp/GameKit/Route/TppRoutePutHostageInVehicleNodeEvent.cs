using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePutHostageInVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PutHostageInVehicle");
		public override StrCode32 GetId() => Id;

		public static TppRoutePutHostageInVehicleNodeEvent Deserialize(FileStreamReader reader) => new TppRoutePutHostageInVehicleNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

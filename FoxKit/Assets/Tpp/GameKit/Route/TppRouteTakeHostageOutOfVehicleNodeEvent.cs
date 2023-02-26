using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteTakeHostageOutOfVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("TakeHostageOutOfVehicle");
		public override StrCode32 GetId() => Id;

		public static TppRouteTakeHostageOutOfVehicleNodeEvent Deserialize(FileStreamReader reader) => new TppRouteTakeHostageOutOfVehicleNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteOpenDoorNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("OpenDoor");
		public override StrCode32 GetId() => Id;

		public static TppRouteOpenDoorNodeEvent Deserialize(FileStreamReader reader) => new TppRouteOpenDoorNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

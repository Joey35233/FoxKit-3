using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveVeryFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("MoveVeryFast");
		public override StrCode32 GetId() => Id;

		public static TppRouteMoveVeryFastEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteMoveVeryFastEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

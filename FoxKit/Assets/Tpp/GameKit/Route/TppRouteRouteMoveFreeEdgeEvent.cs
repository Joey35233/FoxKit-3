using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRouteMoveFreeEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RouteMoveFree");
		public override StrCode32 GetId() => Id;

		public static TppRouteRouteMoveFreeEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteRouteMoveFreeEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

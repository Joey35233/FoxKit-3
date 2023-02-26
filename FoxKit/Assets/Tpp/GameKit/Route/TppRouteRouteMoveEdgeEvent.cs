using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRouteMoveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RouteMove");
		public override StrCode32 GetId() => Id;

		public static TppRouteRouteMoveEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteRouteMoveEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandWalkReadyEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandWalkReady");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandWalkReadyEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteCautionStandWalkReadyEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

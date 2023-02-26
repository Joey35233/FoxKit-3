using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkSearchEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalkSearch");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkSearchEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteCautionWalkSearchEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedStandWalkActEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedStandWalkAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedStandWalkActEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteRelaxedStandWalkActEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

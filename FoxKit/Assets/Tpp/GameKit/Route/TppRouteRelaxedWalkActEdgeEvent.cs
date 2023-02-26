using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedWalkActEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedWalkAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedWalkActEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteRelaxedWalkActEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

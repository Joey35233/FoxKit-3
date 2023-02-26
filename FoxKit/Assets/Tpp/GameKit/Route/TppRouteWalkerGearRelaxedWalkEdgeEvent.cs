using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedWalkEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteWalkerGearRelaxedWalkEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCarryHoneyBeeEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CarryHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRouteCarryHoneyBeeEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteCarryHoneyBeeEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

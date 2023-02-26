using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteForwardChangeSpeedEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("ForwardChangeSpeed");
		public override StrCode32 GetId() => Id;

		public static TppRouteForwardChangeSpeedEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteForwardChangeSpeedEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

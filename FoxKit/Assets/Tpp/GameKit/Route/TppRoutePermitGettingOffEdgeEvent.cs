using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePermitGettingOffEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PermitGettingOff");
		public override StrCode32 GetId() => Id;

		public static TppRoutePermitGettingOffEdgeEvent Deserialize(FileStreamReader reader) => new TppRoutePermitGettingOffEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

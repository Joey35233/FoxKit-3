using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteEMPTY_STRINGEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("");
		public override StrCode32 GetId() => Id;

		public static TppRouteEMPTY_STRINGEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteEMPTY_STRINGEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

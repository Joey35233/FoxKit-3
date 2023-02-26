using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteLOWERCASE_moveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("move");
		public override StrCode32 GetId() => Id;

		public static TppRouteLOWERCASE_moveEdgeEvent Deserialize(FileStreamReader reader) => new TppRouteLOWERCASE_moveEdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

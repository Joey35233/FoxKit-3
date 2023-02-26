using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteOnBaseRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("OnBaseRoute");
		public override StrCode32 GetId() => Id;

		public static TppRouteOnBaseRouteNodeEvent Deserialize(FileStreamReader reader) => new TppRouteOnBaseRouteNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePutDownHoneyBeeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PutDownHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRoutePutDownHoneyBeeNodeEvent Deserialize(FileStreamReader reader) => new TppRoutePutDownHoneyBeeNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}
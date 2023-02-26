using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePickUpHoneyBeeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PickUpHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRoutePickUpHoneyBeeNodeEvent Deserialize(FileStreamReader reader) => new TppRoutePickUpHoneyBeeNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

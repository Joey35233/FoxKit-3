using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSaluteGreetingNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SaluteGreeting");
		public override StrCode32 GetId() => Id;

		public static TppRouteSaluteGreetingNodeEvent Deserialize(FileStreamReader reader) => new TppRouteSaluteGreetingNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}
using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePileBunkerNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PileBunker");
		public override StrCode32 GetId() => Id;

		public static TppRoutePileBunkerNodeEvent Deserialize(FileStreamReader reader) => new TppRoutePileBunkerNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

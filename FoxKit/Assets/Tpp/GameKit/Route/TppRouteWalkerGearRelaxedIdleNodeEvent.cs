using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedIdleNodeEvent Deserialize(FileStreamReader reader) => new TppRouteWalkerGearRelaxedIdleNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

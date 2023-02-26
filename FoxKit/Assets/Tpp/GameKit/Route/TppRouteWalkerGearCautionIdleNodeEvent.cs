using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearCautionIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearCautionIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearCautionIdleNodeEvent Deserialize(FileStreamReader reader) => new TppRouteWalkerGearCautionIdleNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleAimCarryingNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdleAimCarrying");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleAimCarryingNodeEvent Deserialize(FileStreamReader reader) => new TppRouteCautionStandIdleAimCarryingNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

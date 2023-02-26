using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionSquatIdleAimNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionSquatIdleAim");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionSquatIdleAimNodeEvent Deserialize(FileStreamReader reader) => new TppRouteCautionSquatIdleAimNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

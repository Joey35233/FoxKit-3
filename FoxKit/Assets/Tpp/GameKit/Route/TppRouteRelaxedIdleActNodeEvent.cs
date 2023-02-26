using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedIdleActNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedIdleAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedIdleActNodeEvent Deserialize(FileStreamReader reader) => new TppRouteRelaxedIdleActNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

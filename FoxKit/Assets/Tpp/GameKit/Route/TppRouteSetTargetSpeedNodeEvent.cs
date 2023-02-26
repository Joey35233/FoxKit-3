using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSetTargetSpeedNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SetTargetSpeed");
		public override StrCode32 GetId() => Id;

		public static TppRouteSetTargetSpeedNodeEvent Deserialize(FileStreamReader reader) => new TppRouteSetTargetSpeedNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

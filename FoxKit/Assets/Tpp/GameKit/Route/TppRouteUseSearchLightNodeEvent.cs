using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUseSearchLightNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("UseSearchLight");
		public override StrCode32 GetId() => Id;

		public static TppRouteUseSearchLightNodeEvent Deserialize(FileStreamReader reader) => new TppRouteUseSearchLightNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}
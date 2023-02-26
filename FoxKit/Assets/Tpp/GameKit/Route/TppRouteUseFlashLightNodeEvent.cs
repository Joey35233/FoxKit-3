using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUseFlashLightNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("UseFlashLight");
		public override StrCode32 GetId() => Id;

		public static TppRouteUseFlashLightNodeEvent Deserialize(FileStreamReader reader) => new TppRouteUseFlashLightNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown41204288EdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(41204288);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown41204288EdgeEvent Deserialize(FileStreamReader reader) => new TppRouteUnknown41204288EdgeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}

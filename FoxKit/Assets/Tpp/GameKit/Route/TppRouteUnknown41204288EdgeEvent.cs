using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown41204288EdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(41204288);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown41204288EdgeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteUnknown41204288EdgeEvent { railId = new String(reader.ReadStrCode32().ToString()), rpm = reader.ReadUInt32() };

            reader.SkipPadding(8);

            return result;
        }
    }
}

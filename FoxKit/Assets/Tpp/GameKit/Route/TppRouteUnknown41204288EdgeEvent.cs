using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown41204288EdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(41204288);
		public override StrCode32 GetId() => Id;

        public static TppRouteUnknown41204288EdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteUnknown41204288EdgeEvent result = gameObject.AddComponent<TppRouteUnknown41204288EdgeEvent>();

            StrCode32 railId;
            uint rpm;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    railId = *(StrCode32*)ptr;
                    ptr += 1;
                    rpm = *ptr;
                }
            }

            result.railId = new String(railId.ToString());
            result.rpm = rpm;

            return result;
        }
    }
}

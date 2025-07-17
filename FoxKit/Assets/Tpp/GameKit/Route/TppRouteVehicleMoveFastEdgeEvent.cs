using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveFast");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleMoveFastEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteVehicleMoveFastEdgeEvent result = gameObject.AddComponent<TppRouteVehicleMoveFastEdgeEvent>();

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

            result.railId = railId.ToString();
            result.rpm = rpm;

            return result;
        }
    }
}

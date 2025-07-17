using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleBackFast");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleBackFastEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteVehicleBackFastEdgeEvent result = gameObject.AddComponent<TppRouteVehicleBackFastEdgeEvent>();

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

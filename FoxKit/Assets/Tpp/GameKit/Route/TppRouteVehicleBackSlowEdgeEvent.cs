using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackSlowEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleBackSlow");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleBackSlowEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteVehicleBackSlowEdgeEvent result = gameObject.AddComponent<TppRouteVehicleBackSlowEdgeEvent>();

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

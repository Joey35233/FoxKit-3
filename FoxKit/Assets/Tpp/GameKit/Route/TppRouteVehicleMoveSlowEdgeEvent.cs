using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveSlowEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveSlow");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleMoveSlowEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteVehicleMoveSlowEdgeEvent result = gameObject.AddComponent<TppRouteVehicleMoveSlowEdgeEvent>();

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

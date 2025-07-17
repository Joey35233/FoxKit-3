using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackNormalEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleBackNormal");
		public override StrCode32 GetId() => Id;

        public static TppRouteVehicleBackNormalEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteVehicleBackNormalEdgeEvent result = gameObject.AddComponent<TppRouteVehicleBackNormalEdgeEvent>();

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

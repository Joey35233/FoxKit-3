using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRoutePutHostageInVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PutHostageInVehicle");
		public override StrCode32 GetId() => Id;

        public static TppRoutePutHostageInVehicleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRoutePutHostageInVehicleNodeEvent result = gameObject.AddComponent<TppRoutePutHostageInVehicleNodeEvent>();

            uint unknown;
            StrCode32 message;
            StrCode32 routeName;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    unknown = *ptr;
                    ptr += 1;
                    message = *(StrCode32*)ptr;
                    ptr += 1;
                    routeName = *(StrCode32*)ptr;
                }
            }

            Debug.Assert(unknown == 0);

            result.unknown = unknown;
            result.message = new String(message.ToString());
            result.routeName = new String(routeName.ToString());

            return result;
        }
    }
}

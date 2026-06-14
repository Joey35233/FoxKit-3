using Fox.Fio;
using Fox.GameService;
using Fox;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteSendMessageNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SendMessage");
		public override StrCode32 GetId() => Id;

        public static TppRouteSendMessageNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteSendMessageNodeEvent result = gameObject.AddComponent<TppRouteSendMessageNodeEvent>();

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

            result.unknown = unknown;
            result.message = message.ToString();
            result.routeName = routeName.ToString();

            return result;
        }
    }
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedIdleActNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedIdleAct");
		public override StrCode32 GetId() => Id;

        public static TppRouteRelaxedIdleActNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteRelaxedIdleActNodeEvent result = gameObject.AddComponent<TppRouteRelaxedIdleActNodeEvent>();

            StrCode32 animationName;
            ushort unknown;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    animationName = *(StrCode32*)ptr;
                    ptr += 1;
                    unknown = *(ushort*)ptr;
                }
            }

            Debug.Assert(unknown == 0);

            result.animationName = new String(animationName.ToString());
            result.unknown = unknown;

            return result;
        }
    }
}

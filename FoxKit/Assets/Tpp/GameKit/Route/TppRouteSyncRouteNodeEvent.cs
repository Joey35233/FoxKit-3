using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSyncRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SyncRoute");
		public override StrCode32 GetId() => Id;

        public static TppRouteSyncRouteNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteSyncRouteNodeEvent result = gameObject.AddComponent<TppRouteSyncRouteNodeEvent>();

            StrCode32 syncTableId;
            int step;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    syncTableId = *(StrCode32*)ptr;
                    ptr += 1;
                    step = *(int*)ptr;
                }
            }

            result.syncTableId = syncTableId.ToString();
            result.step = step;

            return result;
        }
    }
}

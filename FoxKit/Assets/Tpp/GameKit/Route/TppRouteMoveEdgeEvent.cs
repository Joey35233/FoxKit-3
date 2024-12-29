using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Move");
		public override StrCode32 GetId() => Id;

        public static TppRouteMoveEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteMoveEdgeEvent result = gameObject.AddComponent<TppRouteMoveEdgeEvent>();

            int speed;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    speed = *(int*)ptr;
                }
            }

            result.speed = speed;

            return result;
        }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteJumpWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("JumpWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteJumpWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteJumpWalkEdgeEvent component = gameObject.AddComponent<TppRouteJumpWalkEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

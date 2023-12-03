using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearCautionWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearCautionWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearCautionWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearCautionWalkEdgeEvent component = gameObject.AddComponent<TppRouteWalkerGearCautionWalkEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

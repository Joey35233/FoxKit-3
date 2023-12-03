using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearRelaxedWalkEdgeEvent component = gameObject.AddComponent<TppRouteWalkerGearRelaxedWalkEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

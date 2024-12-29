using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCarryHoneyBeeEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CarryHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRouteCarryHoneyBeeEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCarryHoneyBeeEdgeEvent component = gameObject.AddComponent<TppRouteCarryHoneyBeeEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

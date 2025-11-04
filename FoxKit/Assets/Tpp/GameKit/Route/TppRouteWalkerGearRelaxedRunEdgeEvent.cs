using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedRunEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedRun");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedRunEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearRelaxedRunEdgeEvent component = gameObject.AddComponent<TppRouteWalkerGearRelaxedRunEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

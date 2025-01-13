using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearCautionRunEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearCautionRun");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearCautionRunEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearCautionRunEdgeEvent component = gameObject.AddComponent<TppRouteWalkerGearCautionRunEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

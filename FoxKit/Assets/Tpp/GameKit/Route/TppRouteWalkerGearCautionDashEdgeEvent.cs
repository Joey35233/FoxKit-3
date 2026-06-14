using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearCautionDashEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearCautionDash");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearCautionDashEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearCautionDashEdgeEvent component = gameObject.AddComponent<TppRouteWalkerGearCautionDashEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

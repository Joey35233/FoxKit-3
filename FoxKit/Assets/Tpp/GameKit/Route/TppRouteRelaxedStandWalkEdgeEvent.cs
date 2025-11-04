using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedStandWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedStandWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedStandWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedStandWalkEdgeEvent component = gameObject.AddComponent<TppRouteRelaxedStandWalkEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

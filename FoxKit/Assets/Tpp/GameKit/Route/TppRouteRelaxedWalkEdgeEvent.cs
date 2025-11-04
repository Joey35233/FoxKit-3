using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedWalkEdgeEvent component = gameObject.AddComponent<TppRouteRelaxedWalkEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

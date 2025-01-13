using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRouteMoveFreeEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RouteMoveFree");
		public override StrCode32 GetId() => Id;

		public static TppRouteRouteMoveFreeEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRouteMoveFreeEdgeEvent component = gameObject.AddComponent<TppRouteRouteMoveFreeEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

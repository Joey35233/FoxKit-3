using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRouteMoveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RouteMove");
		public override StrCode32 GetId() => Id;

		public static TppRouteRouteMoveEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRouteMoveEdgeEvent component = gameObject.AddComponent<TppRouteRouteMoveEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

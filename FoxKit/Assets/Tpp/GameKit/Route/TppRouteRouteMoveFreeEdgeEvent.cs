using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRouteMoveFreeEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RouteMoveFree");
		public override StrCode32 GetId() => Id;

		public static TppRouteRouteMoveFreeEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRouteMoveFreeEdgeEvent component = gameObject.AddComponent<TppRouteRouteMoveFreeEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

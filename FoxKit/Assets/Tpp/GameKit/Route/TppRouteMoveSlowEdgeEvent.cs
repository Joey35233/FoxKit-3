using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveSlowEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("MoveSlow");
		public override StrCode32 GetId() => Id;

		public static TppRouteMoveSlowEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteMoveSlowEdgeEvent component = gameObject.AddComponent<TppRouteMoveSlowEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

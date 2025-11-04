using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteDashEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Dash");
		public override StrCode32 GetId() => Id;

		public static TppRouteDashEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteDashEdgeEvent component = gameObject.AddComponent<TppRouteDashEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteForwardChangeSpeedEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("ForwardChangeSpeed");
		public override StrCode32 GetId() => Id;

		public static TppRouteForwardChangeSpeedEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteForwardChangeSpeedEdgeEvent component = gameObject.AddComponent<TppRouteForwardChangeSpeedEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

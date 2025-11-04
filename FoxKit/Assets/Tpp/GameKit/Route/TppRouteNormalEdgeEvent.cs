using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteNormalEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Normal");
		public override StrCode32 GetId() => Id;

		public static TppRouteNormalEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteNormalEdgeEvent component = gameObject.AddComponent<TppRouteNormalEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

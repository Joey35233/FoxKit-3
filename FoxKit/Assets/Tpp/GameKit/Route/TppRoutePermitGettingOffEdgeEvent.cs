using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutePermitGettingOffEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PermitGettingOff");
		public override StrCode32 GetId() => Id;

		public static TppRoutePermitGettingOffEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePermitGettingOffEdgeEvent component = gameObject.AddComponent<TppRoutePermitGettingOffEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

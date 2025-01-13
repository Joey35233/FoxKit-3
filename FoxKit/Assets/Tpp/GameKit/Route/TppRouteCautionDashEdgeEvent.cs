using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionDashEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionDash");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionDashEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionDashEdgeEvent component = gameObject.AddComponent<TppRouteCautionDashEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

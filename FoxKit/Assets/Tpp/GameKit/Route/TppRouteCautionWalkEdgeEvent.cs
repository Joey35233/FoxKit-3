using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionWalkEdgeEvent component = gameObject.AddComponent<TppRouteCautionWalkEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

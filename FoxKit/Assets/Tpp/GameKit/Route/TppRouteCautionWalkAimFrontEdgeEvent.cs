using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkAimFrontEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalkAimFront");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkAimFrontEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionWalkAimFrontEdgeEvent component = gameObject.AddComponent<TppRouteCautionWalkAimFrontEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

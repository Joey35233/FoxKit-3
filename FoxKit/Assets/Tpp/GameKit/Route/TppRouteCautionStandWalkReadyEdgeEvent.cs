using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandWalkReadyEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandWalkReady");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandWalkReadyEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandWalkReadyEdgeEvent component = gameObject.AddComponent<TppRouteCautionStandWalkReadyEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

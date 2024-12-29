using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkFireEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalkFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkFireEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionWalkFireEdgeEvent component = gameObject.AddComponent<TppRouteCautionWalkFireEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

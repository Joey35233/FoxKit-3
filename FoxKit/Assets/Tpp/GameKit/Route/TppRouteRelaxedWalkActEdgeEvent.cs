using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedWalkActEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedWalkAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedWalkActEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedWalkActEdgeEvent component = gameObject.AddComponent<TppRouteRelaxedWalkActEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

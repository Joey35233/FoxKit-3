using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedStandWalkActEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedStandWalkAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedStandWalkActEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedStandWalkActEdgeEvent component = gameObject.AddComponent<TppRouteRelaxedStandWalkActEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

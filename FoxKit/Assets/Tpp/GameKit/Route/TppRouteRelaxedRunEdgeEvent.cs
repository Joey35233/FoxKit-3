using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedRunEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedRun");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedRunEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedRunEdgeEvent component = gameObject.AddComponent<TppRouteRelaxedRunEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkOnlyEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkOnly");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkOnlyEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkOnlyEdgeEvent component = gameObject.AddComponent<TppRouteWalkOnlyEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

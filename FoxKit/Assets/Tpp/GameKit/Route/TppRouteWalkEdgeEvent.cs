using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Walk");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkEdgeEvent component = gameObject.AddComponent<TppRouteWalkEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

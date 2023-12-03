using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRunWalkEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RunWalk");
		public override StrCode32 GetId() => Id;

		public static TppRouteRunWalkEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRunWalkEdgeEvent component = gameObject.AddComponent<TppRouteRunWalkEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

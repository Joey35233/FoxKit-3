using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteStairsDownEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("StairsDown");
		public override StrCode32 GetId() => Id;

		public static TppRouteStairsDownEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteStairsDownEdgeEvent component = gameObject.AddComponent<TppRouteStairsDownEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

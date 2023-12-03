using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveFastEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("MoveFast");
		public override StrCode32 GetId() => Id;

		public static TppRouteMoveFastEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteMoveFastEdgeEvent component = gameObject.AddComponent<TppRouteMoveFastEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

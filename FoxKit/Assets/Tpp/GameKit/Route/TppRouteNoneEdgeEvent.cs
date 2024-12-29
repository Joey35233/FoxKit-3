using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteNoneEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("None");
		public override StrCode32 GetId() => Id;

		public static TppRouteNoneEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteNoneEdgeEvent component = gameObject.AddComponent<TppRouteNoneEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

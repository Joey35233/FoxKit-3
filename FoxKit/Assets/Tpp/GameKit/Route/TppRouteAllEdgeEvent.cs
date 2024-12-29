using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteAllEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("All");
		public override StrCode32 GetId() => Id;

		public static TppRouteAllEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteAllEdgeEvent component = gameObject.AddComponent<TppRouteAllEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteDashEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Dash");
		public override StrCode32 GetId() => Id;

		public static TppRouteDashEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteDashEdgeEvent component = gameObject.AddComponent<TppRouteDashEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

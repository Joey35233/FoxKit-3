using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteOnBaseRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("OnBaseRoute");
		public override StrCode32 GetId() => Id;

		public static TppRouteOnBaseRouteNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteOnBaseRouteNodeEvent component = gameObject.AddComponent<TppRouteOnBaseRouteNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

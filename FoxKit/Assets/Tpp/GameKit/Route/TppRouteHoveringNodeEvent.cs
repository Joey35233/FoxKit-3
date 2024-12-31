using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteHoveringNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Hovering");
		public override StrCode32 GetId() => Id;

		public static TppRouteHoveringNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteHoveringNodeEvent component = gameObject.AddComponent<TppRouteHoveringNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

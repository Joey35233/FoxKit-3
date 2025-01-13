using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutePickUpHoneyBeeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PickUpHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRoutePickUpHoneyBeeNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePickUpHoneyBeeNodeEvent component = gameObject.AddComponent<TppRoutePickUpHoneyBeeNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

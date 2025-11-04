using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutePutDownHoneyBeeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PutDownHoneyBee");
		public override StrCode32 GetId() => Id;

		public static TppRoutePutDownHoneyBeeNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePutDownHoneyBeeNodeEvent component = gameObject.AddComponent<TppRoutePutDownHoneyBeeNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

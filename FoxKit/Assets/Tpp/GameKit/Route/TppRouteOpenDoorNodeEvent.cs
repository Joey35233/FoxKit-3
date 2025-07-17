using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteOpenDoorNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("OpenDoor");
		public override StrCode32 GetId() => Id;

		public static TppRouteOpenDoorNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteOpenDoorNodeEvent component = gameObject.AddComponent<TppRouteOpenDoorNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

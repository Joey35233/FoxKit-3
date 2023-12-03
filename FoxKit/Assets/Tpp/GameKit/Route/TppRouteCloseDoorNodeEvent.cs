using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCloseDoorNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CloseDoor");
		public override StrCode32 GetId() => Id;

		public static TppRouteCloseDoorNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCloseDoorNodeEvent component = gameObject.AddComponent<TppRouteCloseDoorNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

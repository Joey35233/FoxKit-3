using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSetTargetSpeedNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SetTargetSpeed");
		public override StrCode32 GetId() => Id;

		public static TppRouteSetTargetSpeedNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSetTargetSpeedNodeEvent component = gameObject.AddComponent<TppRouteSetTargetSpeedNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

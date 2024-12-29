using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleIdleNodeEvent component = gameObject.AddComponent<TppRouteVehicleIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRideVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RideVehicle");
		public override StrCode32 GetId() => Id;

		public static TppRouteRideVehicleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRideVehicleNodeEvent component = gameObject.AddComponent<TppRouteRideVehicleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

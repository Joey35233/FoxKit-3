using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleFireNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleFireNodeEvent component = gameObject.AddComponent<TppRouteVehicleFireNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

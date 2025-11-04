using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleGetOffNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleGetOff");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleGetOffNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleGetOffNodeEvent component = gameObject.AddComponent<TppRouteVehicleGetOffNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

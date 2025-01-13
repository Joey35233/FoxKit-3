using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleGetInNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleGetIn");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleGetInNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleGetInNodeEvent component = gameObject.AddComponent<TppRouteVehicleGetInNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackSlowEdgeEvent : TppRouteVehicleMoveNormalEdgeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("VehicleBackSlow");
		public override StrCode32 GetId() => Id;
	}
}

using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveSlowEdgeEvent : TppRouteVehicleMoveNormalEdgeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveSlow");
		public override StrCode32 GetId() => Id;
	}
}

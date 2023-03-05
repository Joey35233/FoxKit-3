using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackFastEdgeEvent : TppRouteVehicleMoveNormalEdgeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("VehicleBackFast");
		public override StrCode32 GetId() => Id;
	}
}

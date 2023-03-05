using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleBackNormalEdgeEvent : TppRouteVehicleMoveNormalEdgeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("VehicleBackNormal");
		public override StrCode32 GetId() => Id;
	}
}

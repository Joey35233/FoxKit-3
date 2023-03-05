using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleMoveFastEdgeEvent : TppRouteVehicleMoveNormalEdgeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("VehicleMoveFast");
		public override StrCode32 GetId() => Id;
	}
}

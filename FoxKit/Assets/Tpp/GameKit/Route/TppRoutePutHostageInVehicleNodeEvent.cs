using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePutHostageInVehicleNodeEvent : TppRouteSendMessageNodeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("PutHostageInVehicle");
		public override StrCode32 GetId() => Id;
	}
}

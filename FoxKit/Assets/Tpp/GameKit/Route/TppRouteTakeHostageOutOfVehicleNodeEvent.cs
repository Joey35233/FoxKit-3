using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteTakeHostageOutOfVehicleNodeEvent : TppRouteSendMessageNodeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("TakeHostageOutOfVehicle");
		public override StrCode32 GetId() => Id;
    }
}

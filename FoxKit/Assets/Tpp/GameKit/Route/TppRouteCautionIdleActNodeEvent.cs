using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionIdleActNodeEvent : TppRouteRelaxedIdleActNodeEvent
    {
		public static readonly StrCode32 Id = new StrCode32("CautionIdleAct");
		public override StrCode32 GetId() => Id;
	}
}

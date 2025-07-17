using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutePermitToGetOffNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PermitToGetOff");
		public override StrCode32 GetId() => Id;

		public static TppRoutePermitToGetOffNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePermitToGetOffNodeEvent component = gameObject.AddComponent<TppRoutePermitToGetOffNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

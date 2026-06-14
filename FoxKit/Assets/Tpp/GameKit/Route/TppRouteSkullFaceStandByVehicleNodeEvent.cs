using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSkullFaceStandByVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SkullFaceStandByVehicle");
		public override StrCode32 GetId() => Id;

		public static TppRouteSkullFaceStandByVehicleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSkullFaceStandByVehicleNodeEvent component = gameObject.AddComponent<TppRouteSkullFaceStandByVehicleNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

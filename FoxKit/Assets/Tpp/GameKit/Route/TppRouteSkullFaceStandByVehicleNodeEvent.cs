using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSkullFaceStandByVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SkullFaceStandByVehicle");
		public override StrCode32 GetId() => Id;

		public static TppRouteSkullFaceStandByVehicleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSkullFaceStandByVehicleNodeEvent component = gameObject.AddComponent<TppRouteSkullFaceStandByVehicleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

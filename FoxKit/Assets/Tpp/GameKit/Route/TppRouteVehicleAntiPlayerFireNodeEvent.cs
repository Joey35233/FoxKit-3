using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleAntiPlayerFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleAntiPlayerFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleAntiPlayerFireNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleAntiPlayerFireNodeEvent component = gameObject.AddComponent<TppRouteVehicleAntiPlayerFireNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

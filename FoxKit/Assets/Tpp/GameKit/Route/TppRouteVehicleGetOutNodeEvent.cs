using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteVehicleGetOutNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("VehicleGetOut");
		public override StrCode32 GetId() => Id;

		public static TppRouteVehicleGetOutNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVehicleGetOutNodeEvent component = gameObject.AddComponent<TppRouteVehicleGetOutNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

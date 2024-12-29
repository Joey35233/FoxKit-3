using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteUseFlashLightNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("UseFlashLight");
		public override StrCode32 GetId() => Id;

		public static TppRouteUseFlashLightNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUseFlashLightNodeEvent component = gameObject.AddComponent<TppRouteUseFlashLightNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

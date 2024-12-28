using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUseFlashLightAlwaysNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("UseFlashLightAlways");
		public override StrCode32 GetId() => Id;

		public static TppRouteUseFlashLightAlwaysNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUseFlashLightAlwaysNodeEvent component = gameObject.AddComponent<TppRouteUseFlashLightAlwaysNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

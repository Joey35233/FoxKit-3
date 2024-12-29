using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteDisableStealthModeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("DisableStealthMode");
		public override StrCode32 GetId() => Id;

		public static TppRouteDisableStealthModeNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteDisableStealthModeNodeEvent component = gameObject.AddComponent<TppRouteDisableStealthModeNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteUseSearchLightNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("UseSearchLight");
		public override StrCode32 GetId() => Id;

		public static TppRouteUseSearchLightNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUseSearchLightNodeEvent component = gameObject.AddComponent<TppRouteUseSearchLightNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

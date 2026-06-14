using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleReadyNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdleReady");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleReadyNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleReadyNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleReadyNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionSquatIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionSquatIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionSquatIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionSquatIdleNodeEvent component = gameObject.AddComponent<TppRouteCautionSquatIdleNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

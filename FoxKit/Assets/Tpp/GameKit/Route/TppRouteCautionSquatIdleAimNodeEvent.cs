using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionSquatIdleAimNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionSquatIdleAim");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionSquatIdleAimNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionSquatIdleAimNodeEvent component = gameObject.AddComponent<TppRouteCautionSquatIdleAimNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

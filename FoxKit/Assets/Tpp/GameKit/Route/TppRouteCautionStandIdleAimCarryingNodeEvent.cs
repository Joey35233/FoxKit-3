using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleAimCarryingNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdleAimCarrying");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleAimCarryingNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleAimCarryingNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleAimCarryingNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

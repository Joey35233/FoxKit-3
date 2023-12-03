using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearCautionIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearCautionIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearCautionIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearCautionIdleNodeEvent component = gameObject.AddComponent<TppRouteWalkerGearCautionIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

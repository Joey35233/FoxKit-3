using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearRelaxedIdleNodeEvent component = gameObject.AddComponent<TppRouteWalkerGearRelaxedIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

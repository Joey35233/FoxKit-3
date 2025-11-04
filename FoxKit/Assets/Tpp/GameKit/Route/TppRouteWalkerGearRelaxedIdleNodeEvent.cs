using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteWalkerGearRelaxedIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WalkerGearRelaxedIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWalkerGearRelaxedIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWalkerGearRelaxedIdleNodeEvent component = gameObject.AddComponent<TppRouteWalkerGearRelaxedIdleNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

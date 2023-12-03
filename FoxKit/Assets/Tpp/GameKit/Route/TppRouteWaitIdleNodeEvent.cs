using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteWaitIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("WaitIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteWaitIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteWaitIdleNodeEvent component = gameObject.AddComponent<TppRouteWaitIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

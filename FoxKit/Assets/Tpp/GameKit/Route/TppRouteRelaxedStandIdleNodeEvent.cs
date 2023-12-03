using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedStandIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedStandIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedStandIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRelaxedStandIdleNodeEvent component = gameObject.AddComponent<TppRouteRelaxedStandIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

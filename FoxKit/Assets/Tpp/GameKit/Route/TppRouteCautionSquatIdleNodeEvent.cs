using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionSquatIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionSquatIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionSquatIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionSquatIdleNodeEvent component = gameObject.AddComponent<TppRouteCautionSquatIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

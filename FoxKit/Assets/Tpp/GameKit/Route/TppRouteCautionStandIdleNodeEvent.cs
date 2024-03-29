using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleSearchNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdleSearch");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleSearchNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleSearchNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleSearchNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

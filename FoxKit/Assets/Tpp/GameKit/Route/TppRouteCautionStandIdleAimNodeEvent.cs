using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandIdleAimNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandIdleAim");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandIdleAimNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandIdleAimNodeEvent component = gameObject.AddComponent<TppRouteCautionStandIdleAimNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

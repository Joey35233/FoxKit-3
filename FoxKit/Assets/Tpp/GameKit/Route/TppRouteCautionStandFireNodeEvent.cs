using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionStandFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionStandFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionStandFireNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionStandFireNodeEvent component = gameObject.AddComponent<TppRouteCautionStandFireNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

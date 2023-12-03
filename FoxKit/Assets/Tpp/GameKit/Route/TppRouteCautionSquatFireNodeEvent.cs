using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionSquatFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionSquatFire");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionSquatFireNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionSquatFireNodeEvent component = gameObject.AddComponent<TppRouteCautionSquatFireNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

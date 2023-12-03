using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Caution");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionNodeEvent component = gameObject.AddComponent<TppRouteCautionNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

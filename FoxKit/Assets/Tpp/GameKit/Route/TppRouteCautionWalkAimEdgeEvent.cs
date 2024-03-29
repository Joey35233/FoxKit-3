using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkAimEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalkAim");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkAimEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionWalkAimEdgeEvent component = gameObject.AddComponent<TppRouteCautionWalkAimEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

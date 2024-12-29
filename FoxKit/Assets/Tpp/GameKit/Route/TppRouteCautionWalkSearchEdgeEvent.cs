using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionWalkSearchEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionWalkSearch");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionWalkSearchEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionWalkSearchEdgeEvent component = gameObject.AddComponent<TppRouteCautionWalkSearchEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

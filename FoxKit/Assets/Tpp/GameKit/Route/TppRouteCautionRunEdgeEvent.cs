using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionRunEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionRun");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionRunEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionRunEdgeEvent component = gameObject.AddComponent<TppRouteCautionRunEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCautionRunAimEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CautionRunAim");
		public override StrCode32 GetId() => Id;

		public static TppRouteCautionRunAimEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCautionRunAimEdgeEvent component = gameObject.AddComponent<TppRouteCautionRunAimEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

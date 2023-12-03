using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteEMPTY_STRINGEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("");
		public override StrCode32 GetId() => Id;

		public static TppRouteEMPTY_STRINGEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteEMPTY_STRINGEdgeEvent component = gameObject.AddComponent<TppRouteEMPTY_STRINGEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

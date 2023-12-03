using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRunOnlyEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RunOnly");
		public override StrCode32 GetId() => Id;

		public static TppRouteRunOnlyEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRunOnlyEdgeEvent component = gameObject.AddComponent<TppRouteRunOnlyEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

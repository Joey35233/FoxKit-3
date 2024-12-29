using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveNormalEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("MoveNormal");
		public override StrCode32 GetId() => Id;

		public static TppRouteMoveNormalEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteMoveNormalEdgeEvent component = gameObject.AddComponent<TppRouteMoveNormalEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

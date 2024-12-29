using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRoutechaseEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("chase");
		public override StrCode32 GetId() => Id;

		public static TppRoutechaseEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutechaseEdgeEvent component = gameObject.AddComponent<TppRoutechaseEdgeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

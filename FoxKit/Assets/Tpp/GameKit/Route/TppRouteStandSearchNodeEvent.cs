using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteStandSearchNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("StandSearch");
		public override StrCode32 GetId() => Id;

		public static TppRouteStandSearchNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteStandSearchNodeEvent component = gameObject.AddComponent<TppRouteStandSearchNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

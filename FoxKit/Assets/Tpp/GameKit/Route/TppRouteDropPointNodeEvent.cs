using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteDropPointNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("DropPoint");
		public override StrCode32 GetId() => Id;

		public static TppRouteDropPointNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteDropPointNodeEvent component = gameObject.AddComponent<TppRouteDropPointNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

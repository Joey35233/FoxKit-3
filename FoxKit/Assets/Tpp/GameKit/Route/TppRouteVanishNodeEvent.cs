using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteVanishNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Vanish");
		public override StrCode32 GetId() => Id;

		public static TppRouteVanishNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteVanishNodeEvent component = gameObject.AddComponent<TppRouteVanishNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSnipeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Snipe");
		public override StrCode32 GetId() => Id;

		public static TppRouteSnipeNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSnipeNodeEvent component = gameObject.AddComponent<TppRouteSnipeNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

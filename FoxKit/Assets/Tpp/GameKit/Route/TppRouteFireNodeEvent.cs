using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteFireNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Fire");
		public override StrCode32 GetId() => Id;

		public static TppRouteFireNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteFireNodeEvent component = gameObject.AddComponent<TppRouteFireNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSaluteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Salute");
		public override StrCode32 GetId() => Id;

		public static TppRouteSaluteNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSaluteNodeEvent component = gameObject.AddComponent<TppRouteSaluteNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSaluteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Salute");
		public override StrCode32 GetId() => Id;

		public static TppRouteSaluteNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSaluteNodeEvent component = gameObject.AddComponent<TppRouteSaluteNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

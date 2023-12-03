using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSaluteGreetingNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SaluteGreeting");
		public override StrCode32 GetId() => Id;

		public static TppRouteSaluteGreetingNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSaluteGreetingNodeEvent component = gameObject.AddComponent<TppRouteSaluteGreetingNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

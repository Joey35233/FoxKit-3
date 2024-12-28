using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSleepOnSofaNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SleepOnSofa");
		public override StrCode32 GetId() => Id;

		public static TppRouteSleepOnSofaNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSleepOnSofaNodeEvent component = gameObject.AddComponent<TppRouteSleepOnSofaNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteKillNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Kill");
		public override StrCode32 GetId() => Id;

		public static TppRouteKillNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteKillNodeEvent component = gameObject.AddComponent<TppRouteKillNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

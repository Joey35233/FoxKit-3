using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSitInChairNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SitInChair");
		public override StrCode32 GetId() => Id;

		public static TppRouteSitInChairNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSitInChairNodeEvent component = gameObject.AddComponent<TppRouteSitInChairNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

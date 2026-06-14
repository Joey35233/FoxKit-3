using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteOnTheHillNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("OnTheHill");
		public override StrCode32 GetId() => Id;

		public static TppRouteOnTheHillNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteOnTheHillNodeEvent component = gameObject.AddComponent<TppRouteOnTheHillNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

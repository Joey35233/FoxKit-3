using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteDemoNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Demo");
		public override StrCode32 GetId() => Id;

		public static TppRouteDemoNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteDemoNodeEvent component = gameObject.AddComponent<TppRouteDemoNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

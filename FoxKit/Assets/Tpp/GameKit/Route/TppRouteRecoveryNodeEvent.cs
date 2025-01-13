using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteRecoveryNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Recovery");
		public override StrCode32 GetId() => Id;

		public static TppRouteRecoveryNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteRecoveryNodeEvent component = gameObject.AddComponent<TppRouteRecoveryNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

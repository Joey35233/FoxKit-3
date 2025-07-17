using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCurtainOutNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CurtainOut");
		public override StrCode32 GetId() => Id;

		public static TppRouteCurtainOutNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCurtainOutNodeEvent component = gameObject.AddComponent<TppRouteCurtainOutNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

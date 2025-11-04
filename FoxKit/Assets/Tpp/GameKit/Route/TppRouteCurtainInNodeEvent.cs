using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteCurtainInNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CurtainIn");
		public override StrCode32 GetId() => Id;

		public static TppRouteCurtainInNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCurtainInNodeEvent component = gameObject.AddComponent<TppRouteCurtainInNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteCurtainInNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("CurtainIn");
		public override StrCode32 GetId() => Id;

		public static TppRouteCurtainInNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteCurtainInNodeEvent component = gameObject.AddComponent<TppRouteCurtainInNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

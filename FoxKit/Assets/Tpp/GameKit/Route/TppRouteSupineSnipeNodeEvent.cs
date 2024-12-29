using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSupineSnipeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SupineSnipe");
		public override StrCode32 GetId() => Id;

		public static TppRouteSupineSnipeNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSupineSnipeNodeEvent component = gameObject.AddComponent<TppRouteSupineSnipeNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

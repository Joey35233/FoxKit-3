using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteSearchMissileNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SearchMissile");
		public override StrCode32 GetId() => Id;

		public static TppRouteSearchMissileNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSearchMissileNodeEvent component = gameObject.AddComponent<TppRouteSearchMissileNodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

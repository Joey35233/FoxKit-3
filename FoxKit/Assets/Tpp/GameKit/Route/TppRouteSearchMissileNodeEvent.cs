using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSearchMissileNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SearchMissile");
		public override StrCode32 GetId() => Id;

		public static TppRouteSearchMissileNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteSearchMissileNodeEvent component = gameObject.AddComponent<TppRouteSearchMissileNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

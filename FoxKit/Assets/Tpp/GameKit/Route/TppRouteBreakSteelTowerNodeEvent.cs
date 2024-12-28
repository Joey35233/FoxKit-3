using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteBreakSteelTowerNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("BreakSteelTower");
		public override StrCode32 GetId() => Id;

		public static TppRouteBreakSteelTowerNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteBreakSteelTowerNodeEvent component = gameObject.AddComponent<TppRouteBreakSteelTowerNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

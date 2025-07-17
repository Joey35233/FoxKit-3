using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown3589755714NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(3589755714);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown3589755714NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown3589755714NodeEvent component = gameObject.AddComponent<TppRouteUnknown3589755714NodeEvent>(); component.binaryData = binaryData; return component; }
	}
}

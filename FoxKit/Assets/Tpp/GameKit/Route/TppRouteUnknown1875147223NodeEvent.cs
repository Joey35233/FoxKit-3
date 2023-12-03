using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown1875147223NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(1875147223);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown1875147223NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown1875147223NodeEvent component = gameObject.AddComponent<TppRouteUnknown1875147223NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown2795470991NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(2795470991);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown2795470991NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown2795470991NodeEvent component = gameObject.AddComponent<TppRouteUnknown2795470991NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

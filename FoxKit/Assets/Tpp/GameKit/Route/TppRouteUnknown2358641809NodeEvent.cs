using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown2358641809NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(2358641809);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown2358641809NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown2358641809NodeEvent component = gameObject.AddComponent<TppRouteUnknown2358641809NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

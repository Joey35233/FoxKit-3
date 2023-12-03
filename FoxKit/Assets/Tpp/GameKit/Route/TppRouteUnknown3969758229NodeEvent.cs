using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown3969758229NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(3969758229);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown3969758229NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown3969758229NodeEvent component = gameObject.AddComponent<TppRouteUnknown3969758229NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

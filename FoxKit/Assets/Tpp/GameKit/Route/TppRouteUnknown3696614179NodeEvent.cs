using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown3696614179NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(3696614179);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown3696614179NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown3696614179NodeEvent component = gameObject.AddComponent<TppRouteUnknown3696614179NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

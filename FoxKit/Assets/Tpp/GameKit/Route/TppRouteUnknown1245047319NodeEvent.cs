using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown1245047319NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(1245047319);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown1245047319NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown1245047319NodeEvent component = gameObject.AddComponent<TppRouteUnknown1245047319NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

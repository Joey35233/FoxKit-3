using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteUnknown4257632892NodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = HashingBitConverter.ToStrCode32(4257632892);
		public override StrCode32 GetId() => Id;

		public static TppRouteUnknown4257632892NodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteUnknown4257632892NodeEvent component = gameObject.AddComponent<TppRouteUnknown4257632892NodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRoutePileBunkerNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("PileBunker");
		public override StrCode32 GetId() => Id;

		public static TppRoutePileBunkerNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRoutePileBunkerNodeEvent component = gameObject.AddComponent<TppRoutePileBunkerNodeEvent>(); component.binaryData = new StaticArray<uint>(binaryData); return component; }
	}
}

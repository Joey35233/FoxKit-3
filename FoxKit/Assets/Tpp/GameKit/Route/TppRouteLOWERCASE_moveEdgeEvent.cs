using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteLOWERCASE_moveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("move");
		public override StrCode32 GetId() => Id;

		public static TppRouteLOWERCASE_moveEdgeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData) { TppRouteLOWERCASE_moveEdgeEvent component = gameObject.AddComponent<TppRouteLOWERCASE_moveEdgeEvent>(); component.binaryData = binaryData; return component; }
	}
}

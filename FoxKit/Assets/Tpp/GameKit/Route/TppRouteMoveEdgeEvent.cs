using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteMoveEdgeEvent : GsRouteDataEdgeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("Move");
		public override StrCode32 GetId() => Id;

        public static TppRouteMoveEdgeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteMoveEdgeEvent { speed = reader.ReadInt32(), };

            reader.SkipPadding(12);

            return result;
        }
	}
}

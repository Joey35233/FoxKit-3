using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSyncRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SyncRoute");
		public override StrCode32 GetId() => Id;

		public static TppRouteSyncRouteNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteSyncRouteNodeEvent
            {
                syncTableId = reader.ReadUInt32(),
                syncRouteStep = reader.ReadUInt32(),
            };

            reader.SkipPadding(8);

            return result;
        }
    }
}

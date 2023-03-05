using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSendMessageNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SendMessage");
		public override StrCode32 GetId() => Id;

		public static TppRouteSendMessageNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteSendMessageNodeEvent
            {
                unknownA = reader.ReadInt32(),
                messageId = reader.ReadUInt32(),
                routeId = reader.ReadUInt32(),
            };

            reader.SkipPadding(4);

            return result;
        }
    }
}

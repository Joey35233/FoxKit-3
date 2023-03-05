using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteConversationIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("ConversationIdle");
		public override StrCode32 GetId() => Id;

		public static TppRouteConversationIdleNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteConversationIdleNodeEvent
            {
                conversationLabel = reader.ReadUInt32(),
                friendCharacterId = reader.ReadUInt32(),
            };

            reader.SkipPadding(4);

            result.range = reader.ReadUInt32();

            return result;
        }
    }
}

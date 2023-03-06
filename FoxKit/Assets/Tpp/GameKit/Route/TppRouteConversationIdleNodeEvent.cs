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
            var result = new TppRouteConversationIdleNodeEvent { conversationLabel = new String(reader.ReadStrCode32().ToString()), friendCharacterId = new String(reader.ReadStrCode32().ToString()), range = reader.ReadUInt32() };

            reader.SkipPadding(4);

            return result;
        }
    }
}

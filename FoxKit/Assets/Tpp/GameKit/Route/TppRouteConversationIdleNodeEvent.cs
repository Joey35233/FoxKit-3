using Fox.Fio;
using Fox.GameService;
using Fox;

namespace Tpp.GameKit
{
	public partial class TppRouteConversationIdleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("ConversationIdle");
		public override StrCode32 GetId() => Id;

        public static TppRouteConversationIdleNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteConversationIdleNodeEvent result = gameObject.AddComponent<TppRouteConversationIdleNodeEvent>();

            StrCode32 conversationLabel;
            StrCode32 friendCharacterId;
            uint range;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    conversationLabel = *(StrCode32*)ptr;
                    ptr += 1;
                    friendCharacterId = *(StrCode32*)ptr;
                    ptr += 1;
                    range = *(uint*)ptr;
                }
            }

            result.conversationLabel = conversationLabel.ToString();
            result.friendCharacterId = friendCharacterId.ToString();
            result.range = range;

            return result;
        }
    }
}

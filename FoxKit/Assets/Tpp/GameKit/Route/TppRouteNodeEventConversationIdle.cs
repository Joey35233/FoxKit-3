using Fox;
using Fox.Core.Utils;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventConversationIdle
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			conversationLabel = HashingBitConverter.ToStrCode32(extensions[0]).ToString();

			friendCharacterId = HashingBitConverter.ToStrCode((ulong)extensions[2] << 32 | extensions[1]).ToString();

			range = extensions[3];
		}
	}
}
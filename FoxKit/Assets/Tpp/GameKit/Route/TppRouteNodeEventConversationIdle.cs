using Fox;
using Fox.Core.Utils;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventConversationIdle
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			GameKitModule.ConversationLabelIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out conversationLabel);

			GameKitModule.CharacterIdMap.Resolve(HashingBitConverter.ToStrCode((ulong)extensions[2] << 32 | extensions[1]), out friendCharacterId);

			range = extensions[3];
		}

		public override uint[] GetExtensions()
		{
			GameKitModule.ConversationLabelIdMap.Add(conversationLabel);
			GameKitModule.CharacterIdMap.Add(friendCharacterId);

			ulong friendCharacterHash = HashingBitConverter.StrCodeToUInt64(new StrCode(friendCharacterId));

			return new uint[]
			{
				HashingBitConverter.StrCode32ToUInt32(new StrCode32(conversationLabel)),
				(uint)(friendCharacterHash & 0xFFFFFFFF),
				(uint)(friendCharacterHash >> 32),
				range,
			};
		}
	}
}
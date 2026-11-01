using Fox;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventSendMessage
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			GameKitModule.MessageIdMap.Resolve(HashingBitConverter.ToStrCode((ulong)extensions[0] << 32 | extensions[1]), out message);
			
			GameKitModule.MessageParamMap.Resolve(HashingBitConverter.ToStrCode32(extensions[2]), out string resolvedParam);
			
			param = resolvedParam;
			
			Debug.Assert(extensions[3] == 0);
		}

		public override uint[] GetExtensions()
		{
			GameKitModule.MessageIdMap.Add(message);
			ulong messageHash = HashingBitConverter.StrCodeToUInt64(new StrCode(message));

			GameKitModule.MessageParamMap.Add(param);

			return new uint[]
			{
				(uint)(messageHash >> 32),
				(uint)(messageHash & 0xFFFFFFFF),
				HashingBitConverter.StrCode32ToUInt32(new StrCode32(param)),
				0,
			};
		}
	}
}

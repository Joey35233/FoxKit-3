using System;
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

		public override void WriteExtensions(Span<uint> destination)
		{
			GameKitModule.MessageIdMap.Add(message);
			ulong messageHash = HashingBitConverter.StrCodeToUInt64(new StrCode(message));

			GameKitModule.MessageParamMap.Add(param);

			destination[0] = (uint)(messageHash >> 32);
			destination[1] = (uint)(messageHash & 0xFFFFFFFF);
			destination[2] = HashingBitConverter.StrCode32ToUInt32(new StrCode32(param));
			destination[3] = 0;
		}
	}
}

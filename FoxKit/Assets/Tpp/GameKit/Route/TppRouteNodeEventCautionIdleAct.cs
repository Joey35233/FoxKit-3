using System;
using Fox;
using Fox.Core.Utils;
using Fox.Geo;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventCautionIdleAct
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			GameKitModule.IdleActionIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out action);
			
			Debug.Assert(extensions[1] == 0 && extensions[2] == 0 && extensions[3] == 0);
		}

		public override void WriteExtensions(Span<uint> destination)
		{
			GameKitModule.IdleActionIdMap.Add(action);

			destination[0] = HashingBitConverter.StrCode32ToUInt32(new StrCode32(action));
			destination[1] = 0;
			destination[2] = 0;
			destination[3] = 0;
		}
	}
}
using System;
using Fox;
using Fox.Core.Utils;
using Fox.GameService;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventSyncRoute
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			GameKitModule.SyncRouteIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out string resolvedId);
			syncTableId = resolvedId;
			
			step = unchecked((int)extensions[1]);
			
			Debug.Assert(extensions[2] == 0 && extensions[3] == 0);
		}
	}
}
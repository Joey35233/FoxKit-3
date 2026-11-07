using System;
using Fox;
using Fox.Core.Utils;
using Fox.GameService;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventSwitchRoute
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			GameServiceModule.RouteIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out string resolvedId);
			routeId = resolvedId;
			
			GameKitModule.SwitchRouteConditionIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[1]), out string resolvedCondition);
			condition = resolvedCondition;
			
			GameKitModule.GimmickIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[2]), out gimmickId);
			
			Debug.Assert(extensions[3] == 0);
		}

		public override void WriteExtensions(Span<uint> destination)
		{
			GameServiceModule.RouteIdMap.Add(routeId);
			GameKitModule.SwitchRouteConditionIdMap.Add(condition);
			GameKitModule.GimmickIdMap.Add(gimmickId);

			destination[0] = HashingBitConverter.StrCode32ToUInt32(new StrCode32(routeId));
			destination[1] = HashingBitConverter.StrCode32ToUInt32(new StrCode32(condition));
			destination[2] = HashingBitConverter.StrCode32ToUInt32(new StrCode32(gimmickId));
			destination[3] = 0;
		}
	}
}
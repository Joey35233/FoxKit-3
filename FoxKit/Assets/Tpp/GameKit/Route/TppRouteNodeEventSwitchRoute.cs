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
			
			gimmickId = HashingBitConverter.ToStrCode32(extensions[2]).ToString();
			
			Debug.Assert(extensions[3] == 0);
		}
	}
}
using Fox;
using Fox.Core.Utils;
using Fox.GameService;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventSendMessage
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			message = HashingBitConverter.ToStrCode((ulong)extensions[0] << 32 | extensions[1]).ToString();
			
			GameServiceModule.RouteIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[2]), out string resolvedId);
			
			routeId = resolvedId;
			
			Debug.Assert(extensions[3] == 0);
		}
	}
}
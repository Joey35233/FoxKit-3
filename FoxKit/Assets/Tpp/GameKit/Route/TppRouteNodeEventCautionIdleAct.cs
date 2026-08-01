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
			
			action = HashingBitConverter.ToStrCode32(extensions[0]).ToString();
			
			Debug.Assert(extensions[1] == 0 && extensions[2] == 0 && extensions[3] == 0);
		}
	}
}
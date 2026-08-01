using Fox;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventRelaxedIdleAct
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			action = HashingBitConverter.ToStrCode32(extensions[0]).ToString();

			uint packedAngles = extensions[1];
			
			angleA = Mathf.Clamp(Mathf.Deg2Rad * (byte)(packedAngles >> 0), 0, Mathf.PI);
			angleB = Mathf.Clamp(Mathf.Deg2Rad * (byte)(packedAngles >> 8), 0, Mathf.PI);
			
			Debug.Assert(extensions[2] == 0 && extensions[3] == 0);
		}
	}
}
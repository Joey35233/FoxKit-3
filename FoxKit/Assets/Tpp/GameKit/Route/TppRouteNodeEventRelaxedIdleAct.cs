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
			
			GameKitModule.IdleActionIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out action);

			uint packedAngles = extensions[1];
			
			angleA = Mathf.Clamp(Mathf.Deg2Rad * (byte)(packedAngles >> 0), 0, Mathf.PI);
			angleB = Mathf.Clamp(Mathf.Deg2Rad * (byte)(packedAngles >> 8), 0, Mathf.PI);
			
			Debug.Assert(packedAngles >> 16 == 0);
			Debug.Assert(extensions[2] == 0 && extensions[3] == 0);
		}

		public override uint[] GetExtensions()
		{
			byte packedAngleA = (byte)Mathf.Clamp(Mathf.RoundToInt(angleA * Mathf.Rad2Deg), 0, 180);
			byte packedAngleB = (byte)Mathf.Clamp(Mathf.RoundToInt(angleB * Mathf.Rad2Deg), 0, 180);

			GameKitModule.IdleActionIdMap.Add(action);

			return new uint[]
			{
				HashingBitConverter.StrCode32ToUInt32(new StrCode32(action)),
				(uint)packedAngleA << 0 | (uint)packedAngleB << 8,
				0,
				0,
			};
		}
	}
}
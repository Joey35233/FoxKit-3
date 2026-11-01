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

		public override uint[] GetExtensions()
		{
			GameKitModule.IdleActionIdMap.Add(action);

			return new uint[]
			{
				HashingBitConverter.StrCode32ToUInt32(new StrCode32(action)),
				0,
				0,
				0,
			};
		}
	}
}
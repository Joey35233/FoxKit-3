using System;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameService
{
	public partial class GsRouteDataNodeEvent
	{
		public override void Reset()
		{
			base.Reset();
			
			dir = Quaternion.identity;
		}

		protected void OnValidate()
		{
			dir = Quaternion.Normalize(dir);
		}

		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			dir = Fox.Math.FoxToUnityQuaternion(dir);
		}
	}
}
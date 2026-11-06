using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteEdgeEventMove
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			speed = extensions[0] == 0 ? 3f : extensions[0] / 100.0f;
			
			Debug.Assert(extensions[1] == 0 && extensions[2] == 0 && extensions[3] == 0);
		}

		public override uint[] GetExtensions()
		{
			// Zero means "default speed" (3) on read, so write the default back as zero
			uint encodedSpeed = speed == 3f ? 0 : (uint)Mathf.RoundToInt(speed * 100f);

			return new uint[] { encodedSpeed, 0, 0, 0 };
		}
	}
}
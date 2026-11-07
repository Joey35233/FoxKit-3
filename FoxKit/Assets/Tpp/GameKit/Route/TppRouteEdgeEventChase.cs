using System;
using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteEdgeEventChase
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);
			
			unknown0 = extensions[0] / 10f;
			unknown1 = extensions[1] / 10f;
			unknown2 = extensions[2] / 10f;
			
			Debug.Assert(extensions[3] == 0);
		}

		public override void WriteExtensions(Span<uint> destination)
		{
			destination[0] = (uint)Mathf.RoundToInt(unknown0 * 10f);
			destination[1] = (uint)Mathf.RoundToInt(unknown1 * 10f);
			destination[2] = (uint)Mathf.RoundToInt(unknown2 * 10f);
			destination[3] = 0;
		}
	}
}
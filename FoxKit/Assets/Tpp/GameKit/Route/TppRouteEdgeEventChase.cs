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
	}
}
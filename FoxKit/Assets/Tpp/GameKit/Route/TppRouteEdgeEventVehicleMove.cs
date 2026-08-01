using Fox;
using Fox.Core.Utils;
using Fox.Geo;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteEdgeEventVehicleMove
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			GeoModule.RailIdMap.Resolve(HashingBitConverter.ToStrCode32(extensions[0]), out string resolvedId);
			
			railId = resolvedId;
			
			kph = extensions[1] / 100f * 1000f / 3600f;

			flags = extensions[2];
			Debug.Assert(flags == 0);
			
			Debug.Assert(extensions[3] == 0);
		}
	}
}
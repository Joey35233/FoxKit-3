using Fox;
using Fox.Core.Utils;
using Fox.GameService;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteNodeEventHelicopter
	{
		public override void OnDeserializeEntity(TaskLogger logger)
		{
			base.OnDeserializeEntity(logger);

			uint flags = extensions[0];
			
			leftDoorState = (TppRouteEdgeEventHelicopter_DoorState)(flags >> 0 & 0x3);
			rightDoorState = (TppRouteEdgeEventHelicopter_DoorState)(flags >> 2 & 0x3);
			landingGearState = (TppRouteEdgeEventHelicopter_DoorState)(flags >> 4 & 0x3);
			directionType = (TppRouteEdgeEventHelicopter_DirectionType)(flags >> 6 & 0x3);
			defaultDoorSide = (TppRouteEdgeEventHelicopter_DoorSide)(flags >> 8 & 0x3);
			setTargetSpeed = (flags >> 10 & 1) != 0;

			direction = unchecked((int)extensions[1]);
			
			targetSpeed = unchecked((int)extensions[2]) * 1000f / 3600f;
			
			changeTime = unchecked((int)extensions[3]);
		}
	}
}
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

			// The tpp param dump only shows door/landing gear bits (0-5) and slot 0 in use for node events.
			// Unverified against the exe; these asserts flag any data that uses more.
			Debug.Assert((flags & ~0x3Fu) == 0);
			Debug.Assert(extensions[1] == 0 && extensions[2] == 0 && extensions[3] == 0);
		}

		public override uint[] GetExtensions()
		{
			uint flags = 0;
			flags |= ((uint)leftDoorState & 0x3) << 0;
			flags |= ((uint)rightDoorState & 0x3) << 2;
			flags |= ((uint)landingGearState & 0x3) << 4;
			flags |= ((uint)directionType & 0x3) << 6;
			flags |= ((uint)defaultDoorSide & 0x3) << 8;
			flags |= (setTargetSpeed ? 1u : 0u) << 10;

			return new uint[]
			{
				flags,
				unchecked((uint)direction),
				unchecked((uint)Mathf.RoundToInt(targetSpeed * 3600f / 1000f)),
				unchecked((uint)Mathf.RoundToInt(changeTime)),
			};
		}
	}
}
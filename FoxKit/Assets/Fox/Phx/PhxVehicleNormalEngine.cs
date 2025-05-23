﻿using Fox;

namespace Fox.Phx
{
    public partial class PhxVehicleNormalEngine : Fox.Core.Data
    {
        private PhVehicleNormalEngineParam vehicleNormalEngine => vehicleNormalEngineParam;

        private partial System.Collections.Generic.List<float> Get_specPointAngularVelocity() => vehicleNormalEngine.specPointAngularVelocity;

        private partial System.Collections.Generic.List<float> Get_specPointTorque() => vehicleNormalEngine.specPointTorque;

        private partial System.Collections.Generic.List<float> Get_specPointBreakTorque() => vehicleNormalEngine.specPointBreakTorque;
    }
}

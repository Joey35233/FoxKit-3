using Fox;

namespace Fox.Phx
{
    public partial class PhxVehicleNormalEngine : Fox.Core.Data
    {
        private PhVehicleNormalEngineParam vehicleNormalEngine => vehicleNormalEngineParam;

        private partial DynamicArray<float> Get_specPointAngularVelocity() => vehicleNormalEngine.specPointAngularVelocity;

        private partial DynamicArray<float> Get_specPointTorque() => vehicleNormalEngine.specPointTorque;

        private partial DynamicArray<float> Get_specPointBreakTorque() => vehicleNormalEngine.specPointBreakTorque;
    }
}

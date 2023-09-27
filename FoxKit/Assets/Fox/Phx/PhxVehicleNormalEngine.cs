using Fox.Kernel;

namespace Fox.Phx
{
    public partial class PhxVehicleNormalEngine : Fox.Core.Data
    {
        private PhVehicleNormalEngineParam vehicleNormalEngine => vehicleNormalEngineParam.Get();

        private partial DynamicArray<float> Get_specPointAngularVelocity() => vehicleNormalEngine.specPointAngularVelocity;
        private partial void Set_specPointAngularVelocity(DynamicArray<float> value) => vehicleNormalEngine.specPointAngularVelocity = value;

        private partial DynamicArray<float> Get_specPointTorque() => vehicleNormalEngine.specPointTorque;
        private partial void Set_specPointTorque(DynamicArray<float> value) => vehicleNormalEngine.specPointTorque = value;

        private partial DynamicArray<float> Get_specPointBreakTorque() => vehicleNormalEngine.specPointBreakTorque;
        private partial void Set_specPointBreakTorque(DynamicArray<float> value) => vehicleNormalEngine.specPointBreakTorque = value;
    }
}

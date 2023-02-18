using Fox.Kernel;

namespace Fox.Phx
{
    public partial class PhxVehicleNormalEngine : Fox.Core.Data
    {
        private PhVehicleNormalEngineParam vehicleNormalEngine => vehicleNormalEngineParam.Get();

        protected partial DynamicArray<float> Get_specPointAngularVelocity() => vehicleNormalEngine.specPointAngularVelocity;
        protected partial void Set_specPointAngularVelocity(DynamicArray<float> value) => vehicleNormalEngine.specPointAngularVelocity = value;

        protected partial DynamicArray<float> Get_specPointTorque() => vehicleNormalEngine.specPointTorque;
        protected partial void Set_specPointTorque(DynamicArray<float> value) => vehicleNormalEngine.specPointTorque = value;

        protected partial DynamicArray<float> Get_specPointBreakTorque() => vehicleNormalEngine.specPointBreakTorque;
        protected partial void Set_specPointBreakTorque(DynamicArray<float> value) => vehicleNormalEngine.specPointBreakTorque = value;
    }
}

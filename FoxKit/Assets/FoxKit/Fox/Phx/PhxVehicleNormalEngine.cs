using Fox.Core;

namespace Fox.Phx
{
    public partial class PhxVehicleNormalEngine : Fox.Core.Data
    {
        private PhVehicleNormalEngineParam vehicleNormalEngine => (vehicleNormalEngineParam.Get() as PhVehicleNormalEngineParam);

        protected partial Fox.Core.DynamicArray<float> Get_specPointAngularVelocity() => vehicleNormalEngine.specPointAngularVelocity;
        protected partial void Set_specPointAngularVelocity(Fox.Core.DynamicArray<float> value) { vehicleNormalEngine.specPointAngularVelocity = value; }

        protected partial Fox.Core.DynamicArray<float> Get_specPointTorque() => vehicleNormalEngine.specPointTorque;
        protected partial void Set_specPointTorque(Fox.Core.DynamicArray<float> value) { vehicleNormalEngine.specPointTorque = value; }

        protected partial Fox.Core.DynamicArray<float> Get_specPointBreakTorque() => vehicleNormalEngine.specPointBreakTorque;
        protected partial void Set_specPointBreakTorque(Fox.Core.DynamicArray<float> value) { vehicleNormalEngine.specPointBreakTorque = value; }
    }
}

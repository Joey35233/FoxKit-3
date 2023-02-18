namespace Fox.Phx
{
    public partial class PhVehicleAxisParam : Fox.Core.Entity
    {
        internal float GetMaxBrakeTorque() => maxBreakTorque;
        internal void SetMaxBrakeTorque(float value) => maxBreakTorque = value;

        internal bool GetUseDifferential() => useDifferential;
        internal void SetUseDifferential(bool value) => useDifferential = value;
    }
}

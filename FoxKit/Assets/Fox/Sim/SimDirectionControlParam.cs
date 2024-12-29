using Fox;

namespace Fox.Sim
{
    public partial class SimDirectionControlParam : Fox.Sim.SimControlParam
    {
        internal string GetRefBone() => refBone;
        internal void SetRefBone(string value) => refBone = value;

        internal UnityEngine.Quaternion GetOffset() => offset;
        internal void SetOffset(UnityEngine.Quaternion value) => offset = value;
    }
}

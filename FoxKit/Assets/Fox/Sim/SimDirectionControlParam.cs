using Fox.Kernel;
using Fox.Core;

namespace Fox.Sim
{
    public partial class SimDirectionControlParam : Fox.Sim.SimControlParam
    {
        internal String GetRefBone() => refBone;
        internal void SetRefBone(String value) => refBone = value;

        internal UnityEngine.Quaternion GetOffset() => offset;
        internal void SetOffset(UnityEngine.Quaternion value) => offset = value;
    }
}

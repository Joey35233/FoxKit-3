using Fox.Core;

namespace Fox.Sim
{
    public partial class SimDirectionControlParam : Fox.Sim.SimControlParam
    {
        internal Fox.Core.String GetRefBone() => refBone;
        internal void SetRefBone(Fox.Core.String value) => refBone = value;

        internal UnityEngine.Quaternion GetOffset() => offset;
        internal void SetOffset(UnityEngine.Quaternion value) => offset = value;
    }
}

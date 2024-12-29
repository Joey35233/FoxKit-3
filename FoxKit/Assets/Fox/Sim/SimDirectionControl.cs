using Fox;

namespace Fox.Sim
{
    public partial class SimDirectionControl : Fox.Sim.SimControlElement
    {
        private SimDirectionControlParam param => controlParam;

        private partial string Get_refBone() => param.GetRefBone();
        private partial void Set_refBone(string value) => param.SetRefBone(value);

        private partial UnityEngine.Quaternion Get_offset() => param.GetOffset();
        private partial void Set_offset(UnityEngine.Quaternion value) => param.SetOffset(value);
    }
}

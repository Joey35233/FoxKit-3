using Fox.Kernel;

namespace Fox.Sim
{
    public partial class SimDirectionControl : Fox.Sim.SimControlElement
    {
        private SimDirectionControlParam param => controlParam.Get();

        protected partial String Get_refBone() => param.GetRefBone();
        protected partial void Set_refBone(String value) => param.SetRefBone(value);

        protected partial UnityEngine.Quaternion Get_offset() => param.GetOffset();
        protected partial void Set_offset(UnityEngine.Quaternion value) => param.SetOffset(value);
    }
}

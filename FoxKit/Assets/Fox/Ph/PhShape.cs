using Fox.Core;

namespace Fox.Ph
{
    public partial class PhShape : Fox.Ph.PhSubObject
    {
        private PhShapeParam shapeParam => (param.Get() as PhShapeParam);

        protected partial UnityEngine.Vector3 Get_offset() => shapeParam.GetOffset();
        protected partial void Set_offset(UnityEngine.Vector3 value) { shapeParam.SetOffset(value); }

        protected partial UnityEngine.Quaternion Get_rotation() => shapeParam.GetRotation();
        protected partial void Set_rotation(UnityEngine.Quaternion value) { shapeParam.SetRotation(value); }
    }
}

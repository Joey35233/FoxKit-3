using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShape : Fox.Ph.PhSubObject
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 Get_offset() => shapeParam == null ? Vector3.zero : shapeParam.GetOffset();
        private partial void Set_offset(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shapeParam.SetOffset(value);
        }

        private partial UnityEngine.Quaternion Get_rotation() => shapeParam == null ? Quaternion.identity : shapeParam.GetRotation();
        private partial void Set_rotation(UnityEngine.Quaternion value)
        {
            if (param == null)
                return;

            shapeParam.SetRotation(value);
        }
    }
}

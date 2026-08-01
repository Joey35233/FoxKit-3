using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShape : Fox.Ph.PhSubObject
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 offset_Get() => shapeParam == null ? Vector3.zero : shapeParam.GetOffset();
        private partial void offset_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shapeParam.SetOffset(value);
        }

        private partial UnityEngine.Quaternion rotation_Get() => shapeParam == null ? Quaternion.identity : shapeParam.GetRotation();
        private partial void rotation_Set(UnityEngine.Quaternion value)
        {
            if (param == null)
                return;

            shapeParam.SetRotation(value);
        }
    }
}

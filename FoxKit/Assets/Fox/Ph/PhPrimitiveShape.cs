using UnityEngine;

namespace Fox.Ph
{
    public partial class PhPrimitiveShape : Fox.Ph.PhShape
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 size_Get() => shapeParam == null ? Vector3.zero : shapeParam.GetSize();
        private partial void size_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shapeParam.SetSize(value);
        }

        private partial float radius_Get() => shapeParam == null ? 0f : size.x;
        private partial void radius_Set(float value)
        {
            if (param == null)
                return;

            size = new Vector3(value, size.y, size.z);
        }

        private partial float height_Get() => shapeParam == null ? 0f : size.y;
        private partial void height_Set(float value)
        {
            if (param == null)
                return;

            size = new Vector3(size.x, value, size.z);
        }

        private partial float radius2_Get() => shapeParam == null ? 0f : size.z;
        private partial void radius2_Set(float value)
        {
            if (param == null)
                return;

            size = new Vector3(size.x, size.y, value);
        }
    }
}

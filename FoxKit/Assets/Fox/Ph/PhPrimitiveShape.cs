using UnityEngine;

namespace Fox.Ph
{
    public partial class PhPrimitiveShape : Fox.Ph.PhShape
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 Get_size() => shapeParam == null ? Vector3.zero : shapeParam.GetSize();
        private partial void Set_size(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            shapeParam.SetSize(value);
        }

        private partial float Get_radius() => shapeParam == null ? 0f : size.x;
        private partial void Set_radius(float value)
        {
            if (param == null)
                return;

            size = new Vector3(value, size.y, size.z);
        }

        private partial float Get_height() => shapeParam == null ? 0f : size.y;
        private partial void Set_height(float value)
        {
            if (param == null)
                return;

            size = new Vector3(size.x, value, size.z);
        }

        private partial float Get_radius2() => shapeParam == null ? 0f : size.z;
        private partial void Set_radius2(float value)
        {
            if (param == null)
                return;

            size = new Vector3(size.x, size.y, value);
        }
    }
}

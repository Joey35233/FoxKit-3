using UnityEngine;

namespace Fox.Ph
{
    public partial class PhPrimitiveShape : Fox.Ph.PhShape
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 Get_size() => shapeParam.GetSize();
        private partial void Set_size(UnityEngine.Vector3 value) => shapeParam.SetSize(value);

        private partial float Get_radius() => size.x;
        private partial void Set_radius(float value) => size = new Vector3(value, size.y, size.z);

        private partial float Get_height() => size.y;
        private partial void Set_height(float value) => size = new Vector3(size.x, value, size.z);

        private partial float Get_radius2() => size.z;
        private partial void Set_radius2(float value) => size = new Vector3(size.x, size.y, value);
    }
}

using Fox.Core;

namespace Fox.Ph
{
    public partial class PhPrimitiveShape : Fox.Ph.PhShape
    {
        private PhShapeParam shapeParam => (param.Get() as PhShapeParam);

        protected partial UnityEngine.Vector3 Get_size() => shapeParam.GetSize();
        protected partial void Set_size(UnityEngine.Vector3 value) { shapeParam.SetSize(value); }

        protected partial float Get_radius() => throw new System.NotImplementedException();
        protected partial void Set_radius(float value) { throw new System.NotImplementedException(); }

        protected partial float Get_height() => throw new System.NotImplementedException();
        protected partial void Set_height(float value) { throw new System.NotImplementedException(); }

        protected partial float Get_radius2() => UnityEngine.Mathf.Pow(radius, 2);
        protected partial void Set_radius2(float value) { radius = UnityEngine.Mathf.Sqrt(value); }
    }
}

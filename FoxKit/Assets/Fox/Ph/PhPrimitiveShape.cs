namespace Fox.Ph
{
    public partial class PhPrimitiveShape : Fox.Ph.PhShape
    {
        private PhShapeParam shapeParam => param.Get();

        private partial UnityEngine.Vector3 Get_size() => shapeParam.GetSize();
        private partial void Set_size(UnityEngine.Vector3 value) => shapeParam.SetSize(value);

        private partial float Get_radius() => throw new System.NotImplementedException();
        private partial void Set_radius(float value) => throw new System.NotImplementedException();

        private partial float Get_height() => throw new System.NotImplementedException();
        private partial void Set_height(float value) => throw new System.NotImplementedException();

        private partial float Get_radius2() => UnityEngine.Mathf.Pow(radius, 2);
        private partial void Set_radius2(float value) => radius = UnityEngine.Mathf.Sqrt(value);
    }
}

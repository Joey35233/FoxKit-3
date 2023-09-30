namespace Fox.Ph
{
    public partial class PhShape : Fox.Ph.PhSubObject
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 Get_offset() => shapeParam.GetOffset();
        private partial void Set_offset(UnityEngine.Vector3 value) => shapeParam.SetOffset(value);

        private partial UnityEngine.Quaternion Get_rotation() => shapeParam.GetRotation();
        private partial void Set_rotation(UnityEngine.Quaternion value) => shapeParam.SetRotation(value);
    }
}

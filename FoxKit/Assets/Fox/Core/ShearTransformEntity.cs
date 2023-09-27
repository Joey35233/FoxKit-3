namespace Fox.Core
{
    public partial class ShearTransformEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Vector3 Get_shear() => shearTransform_shear;
        private partial void Set_shear(UnityEngine.Vector3 value) => shearTransform_shear = value;
    }
}
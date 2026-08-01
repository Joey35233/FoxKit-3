namespace Fox.Core
{
    public partial class ShearTransformEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Vector3 shear_Get() => shearTransform_shear;
        private partial void shear_Set(UnityEngine.Vector3 value) => shearTransform_shear = value;
    }
}
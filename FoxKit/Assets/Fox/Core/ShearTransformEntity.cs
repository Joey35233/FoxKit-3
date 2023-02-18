namespace Fox.Core
{
    public partial class ShearTransformEntity : Fox.Core.DataElement
    {
        protected partial UnityEngine.Vector3 Get_shear() => shearTransform_shear;
        protected partial void Set_shear(UnityEngine.Vector3 value) => shearTransform_shear = value;
    }
}
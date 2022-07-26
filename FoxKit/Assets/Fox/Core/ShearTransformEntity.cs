using UnityEngine;

namespace Fox.Core
{
    public partial class ShearTransformEntity : Fox.Core.DataElement
    {
        protected partial UnityEngine.Vector3 Get_shear()
        {
            return shearTransform_shear;
        }
        protected partial void Set_shear(UnityEngine.Vector3 value)
        {
            shearTransform_shear = value;
        }
    }
}
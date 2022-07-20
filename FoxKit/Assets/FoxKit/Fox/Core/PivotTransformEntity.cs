using UnityEngine;

namespace Fox.Core
{
    public partial class PivotTransformEntity : Fox.Core.DataElement
    {
        protected partial UnityEngine.Vector3 Get_pivot()
        {
            return pivotTransform_pivot;
        }
        protected partial void Set_pivot(UnityEngine.Vector3 value)
        {
            pivotTransform_pivot = value;
        }

        protected partial UnityEngine.Vector3 Get_pivotTranslation()
        {
            return pivotTransform_pivotTranslation;
        }
        protected partial void Set_pivotTranslation(UnityEngine.Vector3 value)
        {
            pivotTransform_pivotTranslation = value;
        }
    }
}
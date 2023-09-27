namespace Fox.Core
{
    public partial class PivotTransformEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Vector3 Get_pivot() => pivotTransform_pivot;
        private partial void Set_pivot(UnityEngine.Vector3 value) => pivotTransform_pivot = value;

        private partial UnityEngine.Vector3 Get_pivotTranslation() => pivotTransform_pivotTranslation;
        private partial void Set_pivotTranslation(UnityEngine.Vector3 value) => pivotTransform_pivotTranslation = value;
    }
}
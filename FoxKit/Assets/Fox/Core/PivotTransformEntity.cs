namespace Fox.Core
{
    public partial class PivotTransformEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Vector3 pivot_Get() => pivotTransform_pivot;
        private partial void pivot_Set(UnityEngine.Vector3 value) => pivotTransform_pivot = value;

        private partial UnityEngine.Vector3 pivotTranslation_Get() => pivotTransform_pivotTranslation;
        private partial void pivotTranslation_Set(UnityEngine.Vector3 value) => pivotTransform_pivotTranslation = value;
    }
}
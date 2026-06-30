namespace Fox.Core
{
    public partial class TransformRTEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Quaternion rotQuat_Get() => transform_rotation_quat;
        private partial void rotQuat_Set(UnityEngine.Quaternion value) => transform_rotation_quat = value;

        private partial UnityEngine.Vector3 translation_Get() => transform_translation;
        private partial void translation_Set(UnityEngine.Vector3 value) => transform_translation = value;
    }
}
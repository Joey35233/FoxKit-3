namespace Fox.Core
{
    public partial class TransformRTEntity : Fox.Core.DataElement
    {
        private partial UnityEngine.Quaternion Get_rotQuat() => transform_rotation_quat;
        private partial void Set_rotQuat(UnityEngine.Quaternion value) => transform_rotation_quat = value;

        private partial UnityEngine.Vector3 Get_translation() => transform_translation;
        private partial void Set_translation(UnityEngine.Vector3 value) => transform_translation = value;
    }
}
using UnityEngine;

namespace Fox.Core
{
    public partial class TransformRTEntity : Fox.Core.DataElement
    {
        protected partial UnityEngine.Quaternion Get_rotQuat()
        {
            return transform_rotation_quat;
        }
        protected partial void Set_rotQuat(UnityEngine.Quaternion value)
        {
            transform_rotation_quat = value;
        }

        protected partial UnityEngine.Vector3 Get_translation()
        {
            return transform_translation;
        }
        protected partial void Set_translation(UnityEngine.Vector3 value)
        {
            transform_translation = value;
        }
    }
}
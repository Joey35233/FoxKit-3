using UnityEngine;

namespace Fox.Core
{
    public partial class TransformEntity : Fox.Core.DataElement
    {
        protected partial UnityEngine.Vector3 Get_scale()
        {
            return transform_scale;
        }
        protected partial void Set_scale(UnityEngine.Vector3 value)
        {
            transform_scale = value;
        }

        protected partial UnityEngine.Quaternion Get_rotQuat()
        {
            return Kernel.Math.FoxToUnityQuaternion(transform_rotation_quat);
        }
        protected partial void Set_rotQuat(UnityEngine.Quaternion value)
        {
            transform_rotation_quat = Kernel.Math.UnityToFoxQuaternion(value);
        }

        protected partial UnityEngine.Vector3 Get_translation()
        {
            return Kernel.Math.FoxToUnityVector3(transform_translation);
        }
        protected partial void Set_translation(UnityEngine.Vector3 value)
        {
            transform_translation = Kernel.Math.FoxToUnityVector3(value);
        }
    }
}
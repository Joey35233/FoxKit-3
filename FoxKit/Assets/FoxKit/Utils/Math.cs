namespace FoxKit
{
    using UnityEngine;
    public static class FoxUtils
    {
        public static Vector3 UnityVectorFromFoxCoordinates(float x, float y, float z)
        {
            return new Vector3(-x, y, z);
        }
        public static Vector3 UnityVectorFromFoxCoordinates(Vector3 v)
        {
            return new Vector3(-v.x, v.y, v.z);
        }

        public static Vector4 UnityVectorFromFoxCoordinates(float x, float y, float z, float w)
        {
            return new Vector4(-x, y, z, w);
        }
        public static Vector4 UnityVectorFromFoxCoordinates(Vector4 v)
        {
            return new Vector4(-v.x, v.y, v.z, v.w);
        }

        public static Quaternion UnityQuaternionFromFoxCoordinates(float x, float y, float z, float w)
        {
            var angle = 0.0f;
            var axis = Vector3.zero;
            var unityQuaternion = new Quaternion(x, y, z, w);
            unityQuaternion.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;

            var newQuat = Quaternion.AngleAxis(-angle, axis);

            return new Quaternion(newQuat.x, newQuat.y, newQuat.z, newQuat.w);
        }
        public static Quaternion UnityQuaternionFromFoxCoordinates(Quaternion v)
        {
            var angle = 0.0f;
            var axis = Vector3.zero;
            v.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;

            var newQuat = Quaternion.AngleAxis(-angle, axis);

            return new Quaternion(newQuat.x, newQuat.y, newQuat.z, newQuat.w);
        }
    }
}
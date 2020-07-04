namespace FoxKit
{
    using UnityEngine;
    public static class FoxUtils
    {
        public static Vector4 UnityVectorFromFoxCoordinates(float x, float y, float z, float w)
        {
            return new Vector4(-x, y, z, w);
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
    }
}
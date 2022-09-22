namespace Fox.Kernel
{
    using UnityEngine;
    public static class Math
    {
        private static Matrix4x4 HandednessMatrix = new Matrix4x4
        (
            new Vector4(-1, 0, 0, 0),
            new Vector4( 0, 1, 0, 0),
            new Vector4( 0, 0, 1, 0),
            new Vector4( 0, 0, 0, 1)
        );

        public static Vector3 FoxToUnityVector3(Vector3 v)
        {
            return new Vector3(-v.x, v.y, v.z);
        }
        public static Vector4 FoxToUnityVector4(Vector4 v)
        {
            return new Vector4(-v.x, v.y, v.z, v.w);
        }
        public static Quaternion FoxToUnityQuaternion(Quaternion v)
        {
            float angle;
            Vector3 axis;
            v.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;

            return Quaternion.AngleAxis(-angle, axis);
        }
        public static Matrix4x4 FoxToUnityMatrix(Matrix4x4 m)
        {
            return HandednessMatrix * m;
        }

        public static Vector3 UnityToFoxVector3(Vector3 v)
        {
            return new Vector3(-v.x, v.y, v.z);
        }
        public static Vector4 UnityToFoxVector4(Vector4 v)
        {
            return new Vector4(-v.x, v.y, v.z, v.w);
        }
        public static Quaternion UnityToFoxQuaternion(Quaternion v)
        {
            float angle;
            Vector3 axis;
            v.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;

            return Quaternion.AngleAxis(-angle, axis);
        }
        public static Matrix4x4 UnityToFoxMatrix(Matrix4x4 m)
        {
            return HandednessMatrix * m;
        }
    }
}
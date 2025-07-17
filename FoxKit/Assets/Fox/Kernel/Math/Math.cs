using UnityEngine;

namespace Fox
{
    public static class Math
    {
        // ================================
        // Conversion Utilities
        // ================================

        private static Matrix4x4 HandednessMatrix = new(
            new Vector4(-1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );

        public static Vector3 FoxToUnityVector3(Vector3 v) => new(-v.x, v.y, v.z);
        public static Vector4 FoxToUnityVector4(Vector4 v) => new(-v.x, v.y, v.z, v.w);
        public static (float x, float y, float z) FoxToUnityVectorComponents(Vector3 v) => (-v.x, v.y, v.z);
        public static Quaternion FoxToUnityQuaternion(Quaternion v)
        {
            v.ToAngleAxis(out float angle, out Vector3 axis);
            axis.x = -axis.x;

            return Quaternion.AngleAxis(-angle, axis);
        }
        public static Matrix4x4 FoxToUnityMatrix(Matrix4x4 m) => HandednessMatrix * m;

        public static Vector3 UnityToFoxVector3(Vector3 v) => new(-v.x, v.y, v.z);
        public static Vector4 UnityToFoxVector4(Vector4 v) => new(-v.x, v.y, v.z, v.w);
        public static (float x, float y, float z) UnityToFoxVectorComponents(Vector3 v) => (-v.x, v.y, v.z);
        public static Quaternion UnityToFoxQuaternion(Quaternion v)
        {
            v.ToAngleAxis(out float angle, out Vector3 axis);
            axis.x = -axis.x;

            return Quaternion.AngleAxis(-angle, axis);
        }
        public static Matrix4x4 UnityToFoxMatrix(Matrix4x4 m) => HandednessMatrix * m;

        // ================================
        // General
        // ================================

        /*
         * Tom Duff, James Burgess, Per Christensen, Christophe Hery, Andrew Kensler, Max Liani, and
         * Ryusuke Villemin, Building an Orthonormal Basis, Revisited, Journal of Computer Graphics
         * Techniques (JCGT), vol. 6, no. 1, 1–8, 2017
         * http://jcgt.org/published/0006/01/01/
         */
        public static (Vector3 vecA, Vector3 vecB) GetOrthonormalBasisVectors(Vector3 n)
        {
            float sign = Mathf.Sign(n.z);
            float a = -1.0f / (sign + n.z);
            float b = n.x * n.y * a;
            Vector3 vecA = new (1.0f + sign * n.x * n.x * a, sign * b, -sign * n.x);
            Vector3 vecB = new(b, sign + n.y * n.y * a, -n.y);

            return (vecA, vecB);
        }

        public static Matrix4x4 GetOrthonormalBasisMatrix(Vector3 n)
        {
            float sign = Mathf.Sign(n.z);
            float a = -1.0f / (sign + n.z);
            float b = n.x * n.y * a;
            Vector3 vecA = new (1.0f + sign * n.x * n.x * a, sign * b, -sign * n.x);
            Vector3 vecB = new(b, sign + n.y * n.y * a, -n.y);

            Matrix4x4 result = Matrix4x4.identity;
            result.SetColumn(0, new Vector4(vecA.x, vecA.y, vecA.z, 0));
            result.SetColumn(1, new Vector4(vecB.x, vecB.y, vecB.z, 0));
            result.SetColumn(2, new Vector4(n.x, n.y, n.z, 0));

            return result;
        }
    }
}
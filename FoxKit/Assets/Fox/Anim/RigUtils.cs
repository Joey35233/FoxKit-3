using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public static class RigUtils
    {
        public static Quaternion GetLocalRotation(Quaternion childAbsolute, Quaternion? parentAbsolute)
        {
            if (parentAbsolute is not Quaternion resolvedParentAbsolute)
                return childAbsolute;
            else
                return Quaternion.Inverse(resolvedParentAbsolute) * childAbsolute;
        }

        public static void WriteLocalPos(ReadWriteTransformHandle target, AnimationStream stream,
            Quaternion targetParentRotation,
            Vector3 targetParentPosition, Vector3 localPos)
        {
            target.SetPosition(stream, (targetParentRotation * localPos) + targetParentPosition);
        }

        public static void WriteLocalRotAndPos(ReadWriteTransformHandle target, AnimationStream stream, Quaternion targetParentRotation,
            Vector3 targetParentPosition, Quaternion localRot, Vector3 localPos)
        {
            target.SetRotation(stream, targetParentRotation * localRot);
            target.SetPosition(stream, (targetParentRotation * localPos) + targetParentPosition);
        }

        public static Quaternion RotateX(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(Mathf.Sin(angle), 0, 0, Mathf.Cos(angle));
        }

        public static Quaternion RotateY(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(0, Mathf.Sin(angle), 0, Mathf.Cos(angle));
        }

        public static Quaternion RotateZ(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(0, 0, Mathf.Sin(angle), Mathf.Cos(angle));
        }

        public static Quaternion EulerToQuat(float a, float b, float c, bool invertOrder)
        {
            float cosA = Mathf.Cos(a * 0.5f);
            float cosB = Mathf.Cos(b * 0.5f);
            float cosC = Mathf.Cos(c * 0.5f);
            float sinA = Mathf.Sin(a * 0.5f);
            float sinB = Mathf.Sin(b * 0.5f);
            float sinC = Mathf.Sin(c * 0.5f);
            float sinBcosA = sinB * cosA;
            float sinAcosB = sinA * cosB;
            float sinBsinAcosC = sinB * sinA * cosC;
            float sinBsinAsinC = sinB * sinA * sinC;

            Quaternion result;

            if (invertOrder)
            {
                /* ZYX */
                result.y = sinBcosA * cosC - sinAcosB * sinC;
                result.x = sinBcosA * sinC + sinAcosB * cosC;
                result.z = cosB * cosA * sinC + sinBsinAcosC;
                result.w = cosB * cosA * cosC - sinBsinAsinC;
            }
            else {
                /* XYZ */
                result.z = cosB * cosA * sinC - sinBsinAcosC;
                result.y = sinAcosB * sinC + sinBcosA * cosC;
                result.x = sinAcosB * cosC - sinBcosA * sinC;
                result.w = sinBsinAsinC + cosB * cosA * cosC;
            }

            return result;
        }
    }
}
using Fox.Kernel;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Experimental.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Animx
{
    public enum DriverUnitAction : short
    {
        Invalid = -1,
        Type1 = 1,
        WeightedCopyRotation = 2,
        Type3 = 3,
        Type4 = 4,
        Type5 = 5,
        Type6 = 6,
        Type7 = 7,
        Type8 = 8,
        Type9 = 9,
        Type10 = 10,
        Type11 = 11,
        Type12 = 12,
        Type13 = 13,
        Type14 = 14,
        Type15 = 15,
        Type16 = 16,
        Type17 = 17,
        Type18 = 18,
        Type19 = 19,
        Type20 = 20,
        Type21 = 21,
        Type22 = 22,
        Type23 = 23,
    };

    public enum DriverLimitAxis : uint
    {
        X = 0,
        Y = 1,
        Z = 2,
    };

    public enum DriverRotationMode : uint
    {
        Type0 = 0,
        Type1 = 1,
    }

    public enum DriverRotationOrder : uint
    {
        XYZ = 0,
        XZY = 1,
        YXZ = 2,
        YZX = 3,
        ZXY = 4,
        ZYX = 5,
    };

    [Unity.Burst.BurstCompile]
    public struct RigDriverJob : IWeightedAnimationJob
    {
        public DriverUnitAction Type;

        public ReadWriteTransformHandle Target;
        public Vector3 TargetLocalBindPosition;
        public ReadOnlyTransformHandle TargetParent;

        public ReadOnlyTransformHandle Source;
        public ReadOnlyTransformHandle SourceParent;

        public ReadOnlyTransformHandle Source2;
        public ReadOnlyTransformHandle Source2Parent;

        public float Weight;
        public float Offset;
        public float LimitMin;
        public float LimitMax;

        public DriverLimitAxis Axis;
        public float WeightB;
        public float OffsetB;
        public float LimitMinB;
        public float LimitMaxB;
        public DriverLimitAxis AxisB;
        public DriverRotationMode RotationMode;
        public DriverRotationOrder RotationOrder;

        public Vector3 VectorA;
        public Vector3 VectorB;
        public Vector3 VectorC;
        public Vector3 VectorD;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream) { }

        public void ProcessAnimation(AnimationStream stream)
        {
            switch (Type)
            {
                case DriverUnitAction.Type1:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    float source_lr_cosHalfTheta = Mathf.Min(Mathf.Abs(source_lr.w), 1);

                    float source_lr_halfTheta = Mathf.Acos(source_lr_cosHalfTheta);
                    float source_lr_theta = source_lr_halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(source_lr_theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, target_lp);
                    Target.SetRotation(stream, targetParent_r);

                    break;
                }
                case DriverUnitAction.WeightedCopyRotation:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, source_lr, Weight));

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type3:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    float source_lr_cosHalfTheta = Mathf.Min(Mathf.Abs(source_lr.w), 1);

                    float source_lr_halfTheta = Mathf.Acos(source_lr_cosHalfTheta);
                    float source_lr_theta = source_lr_halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(source_lr_theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type7:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, -Weight));
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, Weight));
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type8:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion lerpA_lr;
                    if (Weight < 0)
                    {
                        lerpA_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, vecA_dr, -Weight));
                        lerpA_lr = Quaternion.Inverse(lerpA_lr);
                    }
                    else
                    {
                        lerpA_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, vecA_dr, Weight));
                    }

                    Quaternion lerpB_lr;
                    if (WeightB < 0)
                    {
                        lerpB_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, -WeightB));
                        lerpB_lr = Quaternion.Inverse(lerpB_lr);
                    }
                    else
                    {
                        lerpB_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, WeightB));
                    }

                    Quaternion target_lr = lerpA_lr * lerpB_lr;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type9:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);
                    Quaternion source2_lr = GetLocalRotation(Source2.GetRotation(stream), Source2Parent.IsValid(stream) ? Source2Parent.GetRotation(stream) : null);

                    Vector3 vecA_l2v = source2_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_l2v));
                    Quaternion toVecASpace_r = vecA_dr * source2_lr;

                    Quaternion lerp_lr;
                    if (WeightB < 0)
                    {
                        lerp_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, -WeightB));
                        lerp_lr = Quaternion.Inverse(lerp_lr);
                    }
                    else
                    {
                        lerp_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, WeightB));
                    }

                    Quaternion weightedSource_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, source_lr, Weight));

                    Quaternion target_lr = weightedSource_lr * lerp_lr;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, lerp_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type10:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    float axisValue = Mathf.Clamp(cosTheta * Weight, LimitMin, LimitMax);
                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, target_lp);
                    Target.SetRotation(stream, targetParent_r);

                    break;
                }
                case DriverUnitAction.Type11:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);
                    float sinTheta = Vector3.Dot(Vector3.Cross(VectorB, VectorA), vecA_lv);

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    float scaledThetaFromAtan = (cosTheta < 0 ? -thetaFromAtan : thetaFromAtan) / Mathf.PI * 2;

                    float doubleLen2 = 2 * Vector4.Dot(new Vector4(VectorA.x, VectorA.y, VectorA.z, 1.0f), new Vector4(vecA_lv.x, vecA_lv.y, vecA_lv.z, 1.0f));
                    float newCosTheta = Mathf.Clamp(Mathf.Sqrt(Mathf.Max(doubleLen2, 0)) * 0.5f, -1, 1);

                    float theta = scaledThetaFromAtan * Weight * Mathf.Acos(newCosTheta) * 2;
                    theta = Mathf.Clamp(theta, LimitMin * Mathf.Deg2Rad, LimitMax * Mathf.Deg2Rad);

                    Quaternion target_lr = GetAxisRotation(Axis, theta);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type12:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    float axisValue = Mathf.Clamp(cosTheta * WeightB, LimitMinB, LimitMaxB);
                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)AxisB] = axisValue * 0.1f;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, -Weight));
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, Weight));
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type13:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    float axisValue = Mathf.Clamp(cosTheta * WeightB, LimitMinB, LimitMaxB);
                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)AxisB] = axisValue * 0.1f;

                    float sinTheta = Vector3.Dot(Vector3.Cross(VectorB, VectorA), vecA_lv);

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    // Deviation - compare with 11
                    float scaledThetaFromAtan = sinTheta < 0 ? (thetaFromAtan / Mathf.PI * 2.0f) - 1.0f : 1.0f - (thetaFromAtan / Mathf.PI * 2.0f);
                    //

                    float doubleLen2 = 2 * Vector4.Dot(new Vector4(VectorA.x, VectorA.y, VectorA.z, 1.0f), new Vector4(vecA_lv.x, vecA_lv.y, vecA_lv.z, 1.0f));
                    float newCosTheta = Mathf.Clamp(Mathf.Sqrt(Mathf.Max(doubleLen2, 0)) * 0.5f, -1, 1);

                    float theta = scaledThetaFromAtan * Weight * Mathf.Acos(newCosTheta) * 2;
                    theta = Mathf.Clamp(theta, LimitMin * Mathf.Deg2Rad, LimitMax * Mathf.Deg2Rad);

                    Quaternion target_lr = GetAxisRotation(Axis, theta);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type14:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 aXb = Vector3.Cross(VectorA, VectorB);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    Vector3 target_lp = TargetLocalBindPosition;

                    float sinTheta = Vector3.Dot(-aXb, vecA_lv);

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    float scaledThetaFromAtan = thetaFromAtan / Mathf.PI * 2.0f;
                    //float scaledThetaFromAtan = sinTheta < 0 ? (thetaFromAtan / Mathf.PI * 2.0f) - 1.0f : 1.0f - (thetaFromAtan / Mathf.PI * 2.0f);

                    float doubleLen2 = 2 * Vector4.Dot(new Vector4(VectorA.x, VectorA.y, VectorA.z, 1.0f), new Vector4(vecA_lv.x, vecA_lv.y, vecA_lv.z, 1.0f));
                    float newCosTheta = Mathf.Clamp(Mathf.Sqrt(Mathf.Max(doubleLen2, 0)) * 0.5f, -1, 1);

                    float theta = Mathf.Acos(newCosTheta);

                    float clampedScaledThetaFromAtanA = sinTheta < 0 ? scaledThetaFromAtan - 1.0f : 1.0f - scaledThetaFromAtan;
                    float thetaA = clampedScaledThetaFromAtanA * Weight * theta * 2;
                    float clampedThetaA = Mathf.Clamp(theta, LimitMin, LimitMax);

                    float clampedScaledThetaFromAtanB = cosTheta < 0 ? -scaledThetaFromAtan : scaledThetaFromAtan;
                    float thetaB = clampedScaledThetaFromAtanB * WeightB * theta * 2;
                    float clampedThetaB = Mathf.Clamp(theta, LimitMinB, LimitMaxB);

                    Quaternion target_lr = new Quaternion(0, 0, 0, 0);
                    switch (RotationMode)
                    {
                        case DriverRotationMode.Type0:
                        {
                            float a = 0.0f;
                            float b = 0.0f;
                            float c = Mathf.Abs(clampedThetaA) + Mathf.Abs(clampedThetaB);

                            if (1e-10 <= c)
                            {
                                float d = Mathf.Sin(c);
                                float e = Mathf.Sin((1.0f / c) * clampedThetaB * Mathf.PI / 2.0f);
                                b = e * d;
                                float f = Mathf.Sin((1.0f / c) * clampedThetaA * (-Mathf.PI / 2.0f));
                                a = f * d;
                            }

                            float g = Mathf.Clamp01(1.0f - b * b - a * a);
                            if (Mathf.PI / 2.0f <= c)
                                g = -g;

                            Vector3 projectedVector = (g * VectorA) + (b * VectorB) + (a * aXb);

                            target_lr = Quaternion.FromToRotation(VectorA, projectedVector);

                            break;
                        }
                        case DriverRotationMode.Type1:
                        {
                            Vector3 euler = Vector3.zero;
                            euler[(int)Axis] = clampedThetaA;
                            euler[(int)AxisB] = clampedThetaB;

                            target_lr = RotationOrder switch
                            {
                                DriverRotationOrder.XYZ => EulerToQuat(euler.x, euler.y, euler.z, false),
                                DriverRotationOrder.XZY => EulerToQuat(euler.x, euler.y, euler.z, true),
                                DriverRotationOrder.YXZ => EulerToQuat(euler.x, euler.y, euler.z, true),
                                DriverRotationOrder.YZX => EulerToQuat(euler.x, euler.y, euler.z, false),
                                DriverRotationOrder.ZXY => EulerToQuat(euler.x, euler.y, euler.z, false),
                                DriverRotationOrder.ZYX => EulerToQuat(euler.x, euler.y, euler.z, true),
                            };

                            break;
                        }
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Type15:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, TargetLocalBindPosition);

                    // TODO (VectorA, VectorB, VectorC, VectorD)

                    break;
                }
                case DriverUnitAction.Type16:
                {
                    // Does not directly modify the RigPose.

                    break;
                }
                case DriverUnitAction.Type17:
                case DriverUnitAction.Type18:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, -Weight));
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = Quaternion.Normalize(Quaternion.SlerpUnclamped(Quaternion.identity, toVecASpace_r, Weight));
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    /*
                     * float toVecASpace_r_cosHalfTheta = Mathf.Clamp(toVecASpace_r.w, -1, 1);
                     * float outTheta = Mathf.Abs(Mathf.Acos(Mathf.Abs(toVecASpace_r_cosHalfTheta)) / Mathf.PI * 2.0f);
                     * Vector3 returnValue = VectorB * outTheta + 1.0f;
                     */

                    break;
                }
                case DriverUnitAction.Type22:
                {
                    Quaternion source_lr = GetLocalRotation(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion target_lr = new Quaternion(-source_lr.x, source_lr.y, source_lr.z, -source_lr.w);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
            }
        }

        private static Quaternion GetLocalRotation(Quaternion childAbsolute, Quaternion? parentAbsolute)
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

        private static void WriteLocalRotAndPos(ReadWriteTransformHandle target, AnimationStream stream, Quaternion targetParentRotation,
            Vector3 targetParentPosition, Quaternion localRot, Vector3 localPos)
        {
            target.SetRotation(stream, targetParentRotation * localRot);
            target.SetPosition(stream, (targetParentRotation * localPos) + targetParentPosition);
        }

        private static Quaternion GetAxisRotation(DriverLimitAxis axis, float radians)
        {
            switch (axis)
            {
                case DriverLimitAxis.X:
                    return RotateX(radians);
                case DriverLimitAxis.Y:
                    return RotateX(radians);
                case DriverLimitAxis.Z:
                    return RotateX(radians);
            }
        }

        private static Quaternion RotateX(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(Mathf.Sin(angle), 0, 0, Mathf.Cos(angle));
        }

        private static Quaternion RotateY(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(0, Mathf.Sin(angle), 0, Mathf.Cos(angle));
        }

        private static Quaternion RotateZ(float radians)
        {
            float angle = radians * 0.5f;
            return new Quaternion(0, 0, Mathf.Sin(angle), Mathf.Cos(angle));
        }

        private static Quaternion EulerToQuat(float a, float b, float c, bool invertOrder)
        {
            float cosA = Mathf.Cos(a * 0.5);
            float cosB = Mathf.Cos(b * 0.5);
            float cosC = Mathf.Cos(c * 0.5);
            float sinA = Mathf.Sin(a * 0.5);
            float sinB = Mathf.Sin(b * 0.5);
            float sinC = Mathf.Sin(c * 0.5);
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

    [System.Serializable]
    public struct RigDriverData : IAnimationJobData
    {
        public DriverUnitAction Type;

        public Transform Target;
        public Transform TargetParent;

        public Transform Source;
        public Transform SourceParent;

        public Transform Source2;
        public Transform Source2Parent;

        public float Weight;
        public float Offset;
        public float LimitMin;
        public float LimitMax;

        public DriverLimitAxis Axis;
        public float WeightB;
        public float OffsetB;
        public float LimitMinB;
        public float LimitMaxB;
        public DriverLimitAxis AxisB;
        public bool Type14Bool;
        public DriverType14Enum Type14Enum;

        public String MaterialNameA;

        public String MaterialNameC;
        public String MaterialParameterC;
        public String MaterialNameB;
        public String MaterialParameterA;
        public String MaterialParameterB;

        public Vector3 VectorA;
        public Vector3 VectorB;
        public Vector3 VectorC;
        public Vector3 VectorD;

        public bool IsValid() => Type != DriverUnitAction.Invalid;

        public void SetDefaultValues()
        {
            return;
        }
    }

    public class RigDriverJobBinder : AnimationJobBinder<RigDriverJob, RigDriverData>
    {
        public override RigDriverJob Create(Animator animator, ref RigDriverData data, Component component)
        {
            var job = new RigDriverJob();

            job.Type = data.Type;

            if (data.Target != null)
            {
                job.Target = ReadWriteTransformHandle.Bind(animator, data.Target);
                job.TargetLocalBindPosition = data.Target.localPosition;
            }
            if (data.TargetParent!= null)
            {
                job.TargetParent = ReadOnlyTransformHandle.Bind(animator, data.TargetParent);
            }
            if (data.Source != null)
            {
                job.Source = ReadOnlyTransformHandle.Bind(animator, data.Source);
            }
            if (data.SourceParent != null)
            {
                job.SourceParent = ReadOnlyTransformHandle.Bind(animator, data.SourceParent);
            }
            if (data.Source2 != null)
            {
                job.Source2 = ReadOnlyTransformHandle.Bind(animator, data.Source2);
            }
            if (data.Source2Parent != null)
            {
                job.Source2Parent = ReadOnlyTransformHandle.Bind(animator, data.Source2Parent);
            }

            job.Weight = data.Weight;

            job.Offset = data.Offset;
            job.LimitMin = data.LimitMin;
            job.LimitMax = data.LimitMax;
            job.Axis = data.Axis;
            job.WeightB = data.WeightB;
            job.OffsetB = data.OffsetB;
            job.LimitMinB = data.LimitMinB;
            job.LimitMaxB = data.LimitMaxB;
            job.AxisB = data.AxisB;
            job.Type14Bool = data.Type14Bool;
            job.Type14Enum = data.Type14Enum;
            job.VectorA = data.VectorA;
            job.VectorB = data.VectorB;
            job.VectorC = data.VectorC;
            job.VectorD = data.VectorD;

            return job;
        }

        public override void Destroy(RigDriverJob job) {}
    }

    public class RigDriver : RigConstraint<RigDriverJob, RigDriverData, RigDriverJobBinder>
    {
    }
}
using Fox;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using static Fox.Anim.RigUtils;

namespace Fox.Animx
{
    public enum DriverUnitAction : short
    {
        Invalid = -1,
        RotATrn = 1,
        Rot = 2,
        RotATurnRot = 3,
        BendATrn = 4,
        Bend = 5,
        BendATrnBend = 6,
        Roll = 7,
        BendRoll = 8,
        RotRoll = 9,
        PitchL = 10,
        PitchA = 11,
        RollPitchL = 12,
        YawAPitchL = 13,
        YawAPitchA = 14,
        Dircns = 15,
        Swell = 16,
        SwellRot = 17,
        SwellRot_Copy = 18, // Identical to 17
        PitchASwitchLinear = 19,
        ParamSwitchAbs = 20,
        PitchACycle = 21,
        Mirror = 22,
        PitchALinearParam = 23,
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
                case DriverUnitAction.RotATrn:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    float cosHalfTheta = Mathf.Min(Mathf.Abs(source_lr.w), 1);

                    float halfTheta = Mathf.Acos(cosHalfTheta);
                    float theta = halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f; // TODO: Handedness?

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, target_lp);
                    Target.SetRotation(stream, targetParent_r);

                    break;
                }
                case DriverUnitAction.Rot:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion target_lr = SlerpWithNormalize(Weight, Quaternion.identity, source_lr);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.RotATurnRot:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    float cosHalfTheta = Mathf.Min(Mathf.Abs(source_lr.w), 1);

                    float halfTheta = Mathf.Acos(cosHalfTheta);
                    float theta = halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f; // TODO: Handedness?

                    Quaternion target_lr = SlerpWithNormalize(WeightB, Quaternion.identity, source_lr);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.BendATrn:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;
                    Quaternion vecA_dr = Quaternion.FromToRotation(VectorA, vecA_lv);

                    float cosHalfTheta = Mathf.Min(Mathf.Abs(vecA_dr.w), 1);

                    float halfTheta = Mathf.Acos(cosHalfTheta);
                    float theta = halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = axisValue * 0.1f; // TODO: Handedness?

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, target_lp);
                    Target.SetRotation(stream, targetParent_r);

                    break;
                }
                case DriverUnitAction.Bend:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.FromToRotation(VectorA, vecA_lv);

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = SlerpWithNormalize(-Weight, Quaternion.identity, vecA_dr);
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = SlerpWithNormalize(Weight, Quaternion.identity, vecA_dr);
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.BendATrnBend:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;
                    Quaternion vecA_dr = Quaternion.FromToRotation(VectorA, vecA_lv);

                    float cosHalfTheta = Mathf.Min(Mathf.Abs(vecA_dr.w), 1);

                    float halfTheta = Mathf.Acos(cosHalfTheta);
                    float theta = halfTheta * 2 * Mathf.Rad2Deg;
                    float axisValue = Mathf.Clamp(theta * Weight, LimitMin, LimitMax);

                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)Axis] = (axisValue + Offset) * 0.1f; // TODO: Handedness?

                    Quaternion target_lr;
                    if (WeightB < 0)
                    {
                        target_lr = SlerpWithNormalize(-WeightB, Quaternion.identity, vecA_dr);
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = SlerpWithNormalize(WeightB, Quaternion.identity, vecA_dr);
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Roll:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;  

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = SlerpWithNormalize(-Weight, Quaternion.identity, toVecASpace_r);
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = SlerpWithNormalize(Weight, Quaternion.identity, toVecASpace_r);
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.BendRoll:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr; // Verified that this is the correct order

                    Quaternion lerpA_lr;
                    if (Weight < 0)
                    {
                        lerpA_lr = SlerpWithNormalize(-Weight, Quaternion.identity, vecA_dr);
                        lerpA_lr = Quaternion.Inverse(lerpA_lr);
                    }
                    else
                    {
                        lerpA_lr = SlerpWithNormalize(Weight, Quaternion.identity, vecA_dr);
                    }

                    Quaternion lerpB_lr;
                    if (WeightB < 0)
                    {
                        lerpB_lr = SlerpWithNormalize(-WeightB, Quaternion.identity, toVecASpace_r);
                        lerpB_lr = Quaternion.Inverse(lerpB_lr);
                    }
                    else
                    {
                        lerpB_lr = SlerpWithNormalize(WeightB, Quaternion.identity, toVecASpace_r);
                    }

                    Quaternion target_lr = lerpA_lr * lerpB_lr;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.RotRoll:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);
                    Quaternion source2_lr = GetLocalRot(Source2.GetRotation(stream), Source2Parent.IsValid(stream) ? Source2Parent.GetRotation(stream) : null);

                    Vector3 vecA_l2v = source2_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_l2v));
                    Quaternion toVecASpace_r = vecA_dr * source2_lr;

                    Quaternion lerp_lr;
                    if (WeightB < 0)
                    {
                        lerp_lr = SlerpWithNormalize(-WeightB, Quaternion.identity, toVecASpace_r);
                        lerp_lr = Quaternion.Inverse(lerp_lr);
                    }
                    else
                    {
                        lerp_lr = SlerpWithNormalize(WeightB, Quaternion.identity, toVecASpace_r);
                    }

                    Quaternion weightedSource_lr = SlerpWithNormalize(Weight, Quaternion.identity, source_lr);

                    Quaternion target_lr = weightedSource_lr * lerp_lr;

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.PitchL:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

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
                case DriverUnitAction.PitchA:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);
                    float sinTheta = Vector3.Dot(-Fox.Math.FoxCross(VectorA, VectorB), vecA_lv); // TODO: Validate handedness

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    float scaledThetaFromAtan = thetaFromAtan / math.PIHALF;
                    scaledThetaFromAtan = cosTheta < 0 ? -scaledThetaFromAtan : scaledThetaFromAtan;

                    // TODO: Clean up. This calculates angle between two vectors
                    // Finds quaternion rotation from vec0 -> vec1 then extracts w component = cos(theta/2)
                    float cosHalfAngleX2 = Mathf.Sqrt(Mathf.Max(2.0f * (1.0f + Vector3.Dot(VectorA, vecA_lv)), 0));
                    float cosHalfAngle = Mathf.Clamp(cosHalfAngleX2 * 0.5f, -1.0f, 1.0f);
                    float angle = Mathf.Acos(cosHalfAngle) * 2.0f;
                        
                    float theta = scaledThetaFromAtan * Weight * angle;
                    theta = Mathf.Clamp(theta, LimitMin * Mathf.Deg2Rad, LimitMax * Mathf.Deg2Rad); // TODO: Ensure weight and min/max limits are proper deg/rad

                    Quaternion target_lr = SetRot(Axis, theta);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.RollPitchL:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    float axisValue = Mathf.Clamp(cosTheta * WeightB, LimitMinB, LimitMaxB); // Don't convert to degrees for this one
                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)AxisB] = axisValue * 0.1f;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = SlerpWithNormalize(-Weight, Quaternion.identity, toVecASpace_r);
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = SlerpWithNormalize(Weight, Quaternion.identity, toVecASpace_r);
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.YawAPitchL:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    float axisValue = Mathf.Clamp(cosTheta * WeightB, LimitMinB, LimitMaxB);
                    Vector3 target_lp = TargetLocalBindPosition;
                    target_lp[(int)AxisB] = axisValue * 0.1f;

                    float sinTheta = Vector3.Dot(-Fox.Math.FoxCross(VectorA, VectorB), vecA_lv);

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    float scaledThetaFromAtan = thetaFromAtan / math.PIHALF;
                    scaledThetaFromAtan = sinTheta < 0 ? scaledThetaFromAtan - 1.0f : 1.0f - scaledThetaFromAtan;

                    // TODO: Clean up. This calculates angle between two vectors
                    // Finds quaternion rotation from vec0 -> vec1 then extracts w component = cos(theta/2)
                    float cosHalfAngleX2 = Mathf.Sqrt(Mathf.Max(2.0f * (1.0f + Vector3.Dot(VectorA, vecA_lv)), 0));
                    float cosHalfAngle = Mathf.Clamp(cosHalfAngleX2 * 0.5f, -1.0f, 1.0f);
                    float angle = Mathf.Acos(cosHalfAngle) * 2.0f;

                    float theta = scaledThetaFromAtan * Weight * angle;
                    theta = Mathf.Clamp(theta, LimitMin * Mathf.Deg2Rad, LimitMax * Mathf.Deg2Rad); // TODO: Ensure weight and min/max limits are proper deg/rad

                    Quaternion target_lr = SetRot(Axis, theta);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.YawAPitchA:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 aXb = Math.FoxCross(VectorA, VectorB);

                    Vector3 vecA_lv = source_lr * VectorA;

                    float cosTheta = Vector3.Dot(vecA_lv, VectorB);

                    Vector3 target_lp = TargetLocalBindPosition;

                    float sinTheta = Vector3.Dot(-aXb, vecA_lv);

                    float thetaFromAtan = Mathf.Atan2(Mathf.Abs(cosTheta), Mathf.Abs(sinTheta) + 1e-10f);
                    float scaledThetaFromAtan = thetaFromAtan / math.PIHALF;

                    // TODO: Clean up. This calculates angle between two vectors
                    // Finds quaternion rotation from vec0 -> vec1 then extracts w component = cos(theta/2)
                    float cosHalfAngleX2 = Mathf.Sqrt(Mathf.Max(2.0f * (1.0f + Vector3.Dot(VectorA, vecA_lv)), 0));
                    float cosHalfAngle = Mathf.Clamp(cosHalfAngleX2 * 0.5f, -1.0f, 1.0f);
                    float angle = Mathf.Acos(cosHalfAngle) * 2.0f;

                    float clampedScaledThetaFromAtanA = sinTheta < 0 ? scaledThetaFromAtan - 1.0f : 1.0f - scaledThetaFromAtan;
                    float thetaA = clampedScaledThetaFromAtanA * Weight * angle;
                    float clampedThetaA = Mathf.Clamp(thetaA, LimitMin, LimitMax);

                    float clampedScaledThetaFromAtanB = cosTheta < 0 ? -scaledThetaFromAtan : scaledThetaFromAtan;
                    float thetaB = clampedScaledThetaFromAtanB * WeightB * angle;
                    float clampedThetaB = Mathf.Clamp(thetaB, LimitMinB, LimitMaxB);

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
                                float e = Mathf.Sin((1.0f / c) * clampedThetaB * math.PIHALF);
                                b = e * d;
                                float f = Mathf.Sin((1.0f / c) * clampedThetaA * -math.PIHALF);
                                a = f * d;
                            }

                            float g = Mathf.Clamp01(1.0f - b * b - a * a);
                            g = Mathf.Sqrt(g);
                            if (math.PIHALF <= c)
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
                                DriverRotationOrder.XZY => EulerToQuat(euler.x, euler.z, euler.y, true),
                                DriverRotationOrder.YXZ => EulerToQuat(euler.y, euler.x, euler.z, true),
                                DriverRotationOrder.YZX => EulerToQuat(euler.y, euler.z, euler.x, false),
                                DriverRotationOrder.ZXY => EulerToQuat(euler.z, euler.x, euler.y, false),
                                DriverRotationOrder.ZYX => EulerToQuat(euler.z, euler.y, euler.x, true),
                                _ => throw new System.NotImplementedException(),
                            };

                            break;
                        }
                    }

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
                case DriverUnitAction.Dircns:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalPos(Target, stream, targetParent_r, targetParent_p, TargetLocalBindPosition);

                    // TODO (VectorA, VectorB, VectorC, VectorD)

                    break;
                }
                case DriverUnitAction.Swell:
                {
                    // Does not directly modify the RigPose.

                    break;
                }
                case DriverUnitAction.SwellRot:
                case DriverUnitAction.SwellRot_Copy:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 vecA_lv = source_lr * VectorA;

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion vecA_dr = Quaternion.Inverse(Quaternion.FromToRotation(VectorA, vecA_lv));
                    Quaternion toVecASpace_r = vecA_dr * source_lr;

                    Quaternion target_lr;
                    if (Weight < 0)
                    {
                        target_lr = SlerpWithNormalize(-Weight, Quaternion.identity, toVecASpace_r);
                        target_lr = Quaternion.Inverse(target_lr);
                    }
                    else
                    {
                        target_lr = SlerpWithNormalize(Weight, Quaternion.identity, toVecASpace_r);
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
                case DriverUnitAction.Mirror:
                {
                    Quaternion source_lr = GetLocalRot(Source.GetRotation(stream), SourceParent.IsValid(stream) ? SourceParent.GetRotation(stream) : null);

                    Vector3 target_lp = TargetLocalBindPosition;

                    Quaternion target_lr = new Quaternion(-source_lr.x, source_lr.y, source_lr.z, -source_lr.w);

                    TargetParent.GetGlobalTR(stream, out Vector3 targetParent_p, out Quaternion targetParent_r);
                    WriteLocalRotAndPos(Target, stream, targetParent_r, targetParent_p, target_lr, target_lp);

                    break;
                }
            }
        }

        private static Quaternion SetRot(DriverLimitAxis axis, float radians)
        {
            switch (axis)
            {
                case DriverLimitAxis.X:
                    return SetRotX(radians);
                case DriverLimitAxis.Y:
                    return SetRotY(radians);
                case DriverLimitAxis.Z:
                    return SetRotZ(radians);
            }

            return Quaternion.identity;
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
        public DriverRotationMode RotationMode;
        public DriverRotationOrder RotationOrder;

        public string MaterialNameA;

        public string MaterialNameC;
        public string MaterialParameterC;
        public string MaterialNameB;
        public string MaterialParameterA;
        public string MaterialParameterB;

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
            job.RotationMode = data.RotationMode;
            job.RotationOrder = data.RotationOrder;
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
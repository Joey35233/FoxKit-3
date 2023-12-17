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
        Type2 = 2,
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

    public enum DriverType14Enum : uint
    {
        Type0 = 0,
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4,
        Type5 = 5,
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
        public bool Type14Bool;
        public DriverType14Enum Type14Enum;

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
            if (Type == DriverUnitAction.Type1)
            {
                Quaternion source_lr = Source.GetLocalRotation(stream);

                float cosTheta = Mathf.Min(Mathf.Abs(source_lr.w), 1);

                float theta = Mathf.Acos(cosTheta);
                theta *= Weight;
                float axisValue = Mathf.Clamp(theta, LimitMin, LimitMax);

                Vector3 target_lbp = TargetLocalBindPosition;
                target_lbp[(int)Axis] = axisValue * 0.1f;

                Target.SetLocalPosition(stream, target_lbp);
                Target.SetRotation(stream, TargetParent.GetRotation(stream));
            }
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

            if (data.Type == DriverUnitAction.Type1)
                job.Weight = data.Weight * 360 / Mathf.PI;
            else
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
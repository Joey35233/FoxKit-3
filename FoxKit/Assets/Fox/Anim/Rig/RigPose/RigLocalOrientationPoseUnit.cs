using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigLocalOrientationPoseUnitJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle Target;
        public ReadOnlyTransformHandle Source;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream) { }

        public void ProcessAnimation(AnimationStream stream)
        {
            Quaternion source_rlr = Source.GetRotation(stream);
            
            Target.SetLocalRotation(stream, source_rlr);
        }
    }

    [System.Serializable]
    public struct RigLocalOrientationPoseUnitData : IAnimationJobData
    {
        public Transform Target;
        public Transform Source;

        public bool IsValid() => Target != null && Source != null;

        public void SetDefaultValues()
        {
            return;
        }
    }

    public class RigLocalOrientationPoseUnitJobBinder : AnimationJobBinder<RigLocalOrientationPoseUnitJob, RigLocalOrientationPoseUnitData>
    {
        public override RigLocalOrientationPoseUnitJob Create(Animator animator, ref RigLocalOrientationPoseUnitData data, Component component)
        {
            var job = new RigLocalOrientationPoseUnitJob();

            job.Target = ReadWriteTransformHandle.Bind(animator, data.Target);
            job.Source = ReadOnlyTransformHandle.Bind(animator, data.Source);

            return job;
        }

        public override void Destroy(RigLocalOrientationPoseUnitJob job) {}
    }

    public class RigLocalOrientationPoseUnit : RigConstraint<RigLocalOrientationPoseUnitJob, RigLocalOrientationPoseUnitData, RigLocalOrientationPoseUnitJobBinder>
    {
    }
}
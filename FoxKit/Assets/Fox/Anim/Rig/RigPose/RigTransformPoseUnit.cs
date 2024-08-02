using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigTransformPoseUnitJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle Target;
        
        public ReadOnlyTransformHandle RotationSource;
        public ReadOnlyTransformHandle PositionSource;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream) { }

        public void ProcessAnimation(AnimationStream stream)
        {
            Quaternion source_rgr = RotationSource.GetRotation(stream);
            Vector3 source_rgp = PositionSource.GetPosition(stream);
            
            Target.SetGlobalTR(stream, source_rgp, source_rgr);
        }
    }

    [System.Serializable]
    public struct RigTransformPoseUnitData : IAnimationJobData
    {
        public Transform Target;
        public Transform RotationSource;
        public Transform PositionSource;

        public bool IsValid() => Target != null && RotationSource != null && PositionSource != null;

        public void SetDefaultValues()
        {
            return;
        }
    }

    public class RigTransformPoseUnitJobBinder : AnimationJobBinder<RigTransformPoseUnitJob, RigTransformPoseUnitData>
    {
        public override RigTransformPoseUnitJob Create(Animator animator, ref RigTransformPoseUnitData data, Component component)
        {
            var job = new RigTransformPoseUnitJob();

            job.Target = ReadWriteTransformHandle.Bind(animator, data.Target);
            job.RotationSource = ReadOnlyTransformHandle.Bind(animator, data.RotationSource);
            job.PositionSource = ReadOnlyTransformHandle.Bind(animator, data.PositionSource);

            return job;
        }

        public override void Destroy(RigTransformPoseUnitJob job) {}
    }

    public class RigTransformPoseUnit : RigConstraint<RigTransformPoseUnitJob, RigTransformPoseUnitData, RigTransformPoseUnitJobBinder>
    {
    }
}
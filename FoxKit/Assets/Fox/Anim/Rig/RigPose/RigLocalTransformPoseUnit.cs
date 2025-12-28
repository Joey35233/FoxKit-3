using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigLocalTransformPoseUnitJob : IWeightedAnimationJob
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
            Quaternion source_rlr = RotationSource.GetLocalRotation(stream);
            Vector3 source_rlp = PositionSource.GetLocalPosition(stream);
            
            Target.SetLocalTRS(stream, source_rlp, source_rlr, Vector3.one);
        }
    }

    [System.Serializable]
    public struct RigLocalTransformPoseUnitData : IAnimationJobData
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

    public class RigLocalTransformPoseUnitJobBinder : AnimationJobBinder<RigLocalTransformPoseUnitJob, RigLocalTransformPoseUnitData>
    {
        public override RigLocalTransformPoseUnitJob Create(Animator animator, ref RigLocalTransformPoseUnitData data, Component component)
        {
            var job = new RigLocalTransformPoseUnitJob();

            job.Target = ReadWriteTransformHandle.Bind(animator, data.Target);
            job.RotationSource = ReadOnlyTransformHandle.Bind(animator, data.RotationSource);
            job.PositionSource = ReadOnlyTransformHandle.Bind(animator, data.PositionSource);

            return job;
        }

        public override void Destroy(RigLocalTransformPoseUnitJob job) {}
    }

    public class RigLocalTransformPoseUnit : RigConstraint<RigLocalTransformPoseUnitJob, RigLocalTransformPoseUnitData, RigLocalTransformPoseUnitJobBinder>
    {
    }
}
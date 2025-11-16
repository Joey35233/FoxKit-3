using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigOrientationPoseUnitJob : IWeightedAnimationJob
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
            Quaternion source_rgr = Source.GetRotation(stream);
            
            Target.SetRotation(stream, source_rgr);
        }
    }

    [System.Serializable]
    public struct RigOrientationPoseUnitData : IAnimationJobData
    {
        public Transform Target;
        public Transform Source;

        public bool IsValid() => Target != null && Source != null;

        public void SetDefaultValues()
        {
            return;
        }
    }

    public class RigOrientationPoseUnitJobBinder : AnimationJobBinder<RigOrientationPoseUnitJob, RigOrientationPoseUnitData>
    {
        public override RigOrientationPoseUnitJob Create(Animator animator, ref RigOrientationPoseUnitData data, Component component)
        {
            var job = new RigOrientationPoseUnitJob();
            
            job.Target = ReadWriteTransformHandle.Bind(animator, data.Target);
            job.Source = ReadOnlyTransformHandle.Bind(animator, data.Source);

            return job;
        }

        public override void Destroy(RigOrientationPoseUnitJob job) {}
    }

    public class RigOrientationPoseUnit : RigConstraint<RigOrientationPoseUnitJob, RigOrientationPoseUnitData, RigOrientationPoseUnitJobBinder>
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Vector3.zero, 0.15f * Vector3.one);
        }
    }
}
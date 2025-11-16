using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigMultiLocalOrientationPoseUnitJob : IWeightedAnimationJob
    {
        public NativeArray<ReadWriteTransformHandle> Targets;
        public NativeArray<ReadOnlyTransformHandle> Sources;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream) { }

        public void ProcessAnimation(AnimationStream stream)
        {
            for (int i = 0; i < Sources.Length; i++)
            {
                ReadOnlyTransformHandle source = Sources[i];
                Quaternion source_rlr = source.GetRotation(stream);
                
                ReadWriteTransformHandle target = Targets[i];
                target.SetLocalRotation(stream, source_rlr);
            }
        }
    }

    [System.Serializable]
    public struct RigMultiLocalOrientationPoseUnitData : IAnimationJobData
    {
        public Transform[] Targets;
        public Transform[] Sources;

        public bool IsValid()
        {
            if (Targets == null || Sources == null || Targets.Length != Sources.Length)
                return false;
            
            foreach (var target in Targets)
                if (target == null)
                    return false;
            
            foreach (var source in Sources)
                if (source == null)
                    return false;
            
            return true;
        }

        public void SetDefaultValues()
        {
            Targets = new Transform[1];
            Sources = new Transform[1];
            
            return;
        }
    }

    public class RigMultiLocalOrientationPoseUnitJobBinder : AnimationJobBinder<RigMultiLocalOrientationPoseUnitJob, RigMultiLocalOrientationPoseUnitData>
    {
        public override RigMultiLocalOrientationPoseUnitJob Create(Animator animator, ref RigMultiLocalOrientationPoseUnitData data, Component component)
        {
            var job = new RigMultiLocalOrientationPoseUnitJob();
            
            job.Targets = new NativeArray<ReadWriteTransformHandle>(data.Targets.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            job.Sources = new NativeArray<ReadOnlyTransformHandle>(data.Targets.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

            for (int i = 0; i < data.Targets.Length; i++)
                job.Targets[i] = ReadWriteTransformHandle.Bind(animator, data.Targets[i]);
            
            for (int i = 0; i < data.Targets.Length; i++)
                job.Sources[i] = ReadOnlyTransformHandle.Bind(animator, data.Sources[i]);

            return job;
        }

        public override void Destroy(RigMultiLocalOrientationPoseUnitJob job)
        {
            job.Targets.Dispose();
            job.Sources.Dispose();
        }
    }

    public class RigMultiLocalOrientationPoseUnit : RigConstraint<RigMultiLocalOrientationPoseUnitJob, RigMultiLocalOrientationPoseUnitData, RigMultiLocalOrientationPoseUnitJobBinder>
    {
    }
}
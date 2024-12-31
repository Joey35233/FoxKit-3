using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigTwoBonePoseUnitJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle UpperTarget;
        
        public Vector3Property ChainPlaneNormal;
        public ReadOnlyTransformHandle PoleRotationSource;

        public ReadWriteTransformHandle MidTarget;
        
        public ReadWriteTransformHandle EffectorTarget;
        public ReadOnlyTransformHandle EffectorPositionSource;

        private float3x3 InverseRootRotation;
        private float3 InverseRootPosition;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream)
        {
            InverseRootRotation = new float3x3(math.inverse(stream.rootMotionRotation));

            InverseRootPosition = -stream.rootMotionPosition;
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            // Apply inverse root correction
            float3 effector_rgp = EffectorPositionSource.GetPosition(stream);
            effector_rgp = math.mul(InverseRootRotation, effector_rgp + InverseRootPosition);

            float3 upper_rgp = UpperTarget.GetPosition(stream);
            
            quaternion chainRot = PoleRotationSource.GetRotation(stream);
            float3 upper2eff_rlv = effector_rgp - upper_rgp;
            float3 chain_uv = math.normalize(math.rotate(chainRot, upper_rgp));
            
            float3 mid_blp = MidTarget.GetLocalPosition(stream);
            float3 effector_blp = EffectorTarget.GetLocalPosition(stream);
            
            float3 chainPlaneNormal = ChainPlaneNormal.Get(stream);
            
            RigPoseUnitUtils.SolveTwoBoneIK(out quaternion upper_rgr, out quaternion mid_rgr, mid_blp, effector_blp, chainPlaneNormal, upper_rgp, effector_rgp, chain_uv);

            MidTarget.SetPosition(stream, math.rotate(upper_rgr, mid_blp) + upper_rgp);
            UpperTarget.SetPosition(stream, upper_rgp);
        }
    }

    [System.Serializable]
    public struct RigTwoBonePoseUnitData : IAnimationJobData
    {
        public Transform UpperTarget;
        
        public Vector3 ChainPlaneNormal;
        public Transform PoleRotationSource;

        public Transform MidTarget;
        
        public Transform EffectorTarget;
        public Transform EffectorPositionSource;
        
        public bool IsValid() => UpperTarget != null && PoleRotationSource != null && MidTarget != null && EffectorTarget != null && EffectorPositionSource != null;

        public void SetDefaultValues()
        {
            return;
        }
    }

    public class RigTwoBonePoseUnitJobBinder : AnimationJobBinder<RigTwoBonePoseUnitJob, RigTwoBonePoseUnitData>
    {
        public override RigTwoBonePoseUnitJob Create(Animator animator, ref RigTwoBonePoseUnitData data, Component component)
        {
            RigTwoBonePoseUnitJob job = new RigTwoBonePoseUnitJob
            {
                UpperTarget = ReadWriteTransformHandle.Bind(animator, data.UpperTarget),
                
                ChainPlaneNormal = Vector3Property.Bind(animator, component, ConstraintsUtils.ConstructConstraintDataPropertyName("ChainPlaneNormal")),
                PoleRotationSource = ReadOnlyTransformHandle.Bind(animator, data.PoleRotationSource),
                
                MidTarget = ReadWriteTransformHandle.Bind(animator, data.MidTarget),
                
                EffectorTarget = ReadWriteTransformHandle.Bind(animator, data.EffectorTarget),
                EffectorPositionSource = ReadOnlyTransformHandle.Bind(animator, data.EffectorPositionSource)
            };

            return job;
        }

        public override void Destroy(RigTwoBonePoseUnitJob job) {}
    }

    public class RigTwoBonePoseUnit : RigConstraint<RigTwoBonePoseUnitJob, RigTwoBonePoseUnitData, RigTwoBonePoseUnitJobBinder>
    {
    }
}
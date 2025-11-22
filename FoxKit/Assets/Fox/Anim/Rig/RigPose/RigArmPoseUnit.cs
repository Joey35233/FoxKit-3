using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigArmPoseUnitJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle ShoulderTarget;
        public ReadOnlyTransformHandle ShoulderRotationSource;

        public ReadWriteTransformHandle UpperArmTarget;
        
        public Vector3Property ChainPlaneNormal;
        public ReadOnlyTransformHandle PoleRotationSource;

        public ReadWriteTransformHandle LowerArmTarget;
        
        public ReadWriteTransformHandle EffectorTarget;
        public ReadOnlyTransformHandle EffectorPositionSource;

        public bool DEBUG;
        public ReadWriteTransformHandle DEBUG_ShoulderTarget;
        public ReadWriteTransformHandle DEBUG_UpperTarget;
        public ReadWriteTransformHandle DEBUG_PoleTarget;
        public ReadWriteTransformHandle DEBUG_LowerTarget;
        public ReadWriteTransformHandle DEBUG_EffectorTarget;

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

        private void ComputeSkel0AndSkel1(AnimationStream stream, out float3 out_shoulder_rgp, out quaternion out_shoulder_rgr, out float3 out_upperArm_rgp)
        {
            out_shoulder_rgp = ShoulderTarget.GetPosition(stream);
            
            out_shoulder_rgr = ShoulderRotationSource.GetRotation(stream);
            
            float3 upperArm_blp = UpperArmTarget.GetLocalPosition(stream);
            out_upperArm_rgp = math.rotate(out_shoulder_rgr, upperArm_blp) + out_shoulder_rgp;
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            // Apply inverse root correction
            float3 effector_rgp = EffectorPositionSource.GetPosition(stream);
            effector_rgp = math.mul(InverseRootRotation, effector_rgp + InverseRootPosition);
            
            ComputeSkel0AndSkel1(stream, out float3 shoulder_rgp, out quaternion shoulder_rgr, out float3 upperArm_rgp);
            
            quaternion chainRot = PoleRotationSource.GetRotation(stream);
            float3 uarm2eff_rlv = effector_rgp - upperArm_rgp;
            float3 chain_uv = math.normalize(math.rotate(chainRot, uarm2eff_rlv));
            
            float3 lowerArm_blp = LowerArmTarget.GetLocalPosition(stream);
            float3 effector_blp = EffectorTarget.GetLocalPosition(stream);
            
            float3 chainPlaneNormal = ChainPlaneNormal.Get(stream);
            
            RigPoseUnitUtils.SolveTwoBoneIK(out quaternion upperArm_rgr, out quaternion lowerArm_rgr, lowerArm_blp, effector_blp, chainPlaneNormal, upperArm_rgp, effector_rgp, chain_uv);

            float3 lowerArm_rgp = math.rotate(upperArm_rgr, lowerArm_blp) + upperArm_rgp;
            
            float3 trueEffector_rgp = math.rotate(lowerArm_rgr, effector_blp) + lowerArm_rgp;
            
            ShoulderTarget.SetGlobalTR(stream, shoulder_rgp, shoulder_rgr);
            UpperArmTarget.SetGlobalTR(stream, upperArm_rgp, upperArm_rgr);
            LowerArmTarget.SetGlobalTR(stream, lowerArm_rgp, lowerArm_rgr);
            EffectorTarget.SetPosition(stream, trueEffector_rgp);
            
            // LowerArmTarget.SetPosition(stream, lowerArm_rgp);
            // UpperArmTarget.SetPosition(stream, upperArm_rgp);
            // ShoulderTarget.SetPosition(stream, shoulder_rgp);
            
            // lowerArm_blp     = new float3(0.284000f, 0.000000f, 0.000000f); 
            // effector_blp     = new float3(0.255000f, 0.000000f, 0.000000f); 
            // chainPlaneNormal = new float3(0.000000f, -1.000000f, 0.000000f); 
            // upperArm_rgp     = new float3(0.042653f, 0.936965f, 0.261952f); 
            // effector_rgp     = new float3(-0.178393f, 0.639487f, 0.489623f); 
            // chain_uv         = new float3(0.860965f, -0.418754f, 0.288762f); 
            // RigPoseUnitUtils.SolveTwoBoneIK(out Quaternion testA, out Quaternion testB, lowerArm_blp, effector_blp, chainPlaneNormal, upperArm_rgp, effector_rgp, chain_uv);

            
            if (DEBUG)
            {
                DEBUG_ShoulderTarget.SetGlobalTR(stream, shoulder_rgp, shoulder_rgr);
                DEBUG_UpperTarget.SetGlobalTR(stream, upperArm_rgp, upperArm_rgr);
                DEBUG_PoleTarget.SetPosition(stream, upperArm_rgp + 0.5f * uarm2eff_rlv + chain_uv);
                DEBUG_LowerTarget.SetGlobalTR(stream, lowerArm_rgp, lowerArm_rgr);
                DEBUG_EffectorTarget.SetGlobalTR(stream, effector_rgp, Quaternion.identity);
            }
        }
    }

    [System.Serializable]
    public struct RigArmPoseUnitData : IAnimationJobData
    {
        public Transform ShoulderTarget;
        public Transform ShoulderRotationSource;

        public Transform UpperArmTarget;
        
        public Vector3 ChainPlaneNormal;
        public Transform PoleRotationSource;

        public Transform LowerArmTarget;
        
        public Transform EffectorTarget;
        public Transform EffectorPositionSource;
        
        public bool DEBUG;
        public Transform DEBUG_ShoulderTarget;
        public Transform DEBUG_UpperTarget;
        public Transform DEBUG_PoleTarget;
        public Transform DEBUG_LowerTarget;
        public Transform DEBUG_EffectorTarget;
        
        public bool IsValid() => ShoulderTarget != null && ShoulderRotationSource != null && UpperArmTarget != null && LowerArmTarget != null && EffectorTarget != null && EffectorPositionSource != null && PoleRotationSource != null;

        public void SetDefaultValues()
        {
            ShoulderTarget = null;
            ShoulderRotationSource = null;

            UpperArmTarget = null;

            ChainPlaneNormal = Vector3.zero;
            PoleRotationSource = null;

            LowerArmTarget = null;

            EffectorTarget = null;
            EffectorPositionSource = null;
        }
    }

    public class RigArmPoseUnitJobBinder : AnimationJobBinder<RigArmPoseUnitJob, RigArmPoseUnitData>
    {
        public override RigArmPoseUnitJob Create(Animator animator, ref RigArmPoseUnitData data, Component component)
        {
            RigArmPoseUnitJob job = new RigArmPoseUnitJob
            {
                ShoulderTarget = ReadWriteTransformHandle.Bind(animator, data.ShoulderTarget),
                ShoulderRotationSource = ReadOnlyTransformHandle.Bind(animator, data.ShoulderRotationSource),
                
                UpperArmTarget = ReadWriteTransformHandle.Bind(animator, data.UpperArmTarget),
                
                ChainPlaneNormal = Vector3Property.Bind(animator, component, ConstraintsUtils.ConstructConstraintDataPropertyName("ChainPlaneNormal")),
                PoleRotationSource = ReadOnlyTransformHandle.Bind(animator, data.PoleRotationSource),
                
                LowerArmTarget = ReadWriteTransformHandle.Bind(animator, data.LowerArmTarget),
                
                EffectorTarget = ReadWriteTransformHandle.Bind(animator, data.EffectorTarget),
                EffectorPositionSource = ReadOnlyTransformHandle.Bind(animator, data.EffectorPositionSource)
            };

            if (data.DEBUG)
            {
                job.DEBUG = true;
                job.DEBUG_ShoulderTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_ShoulderTarget);
                job.DEBUG_UpperTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_UpperTarget);
                job.DEBUG_PoleTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_PoleTarget);
                job.DEBUG_LowerTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_LowerTarget);
                job.DEBUG_EffectorTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_EffectorTarget);
            }

            return job;
        }

        public override void Destroy(RigArmPoseUnitJob job) {}
    }

    public class RigArmPoseUnit : RigConstraint<RigArmPoseUnitJob, RigArmPoseUnitData, RigArmPoseUnitJobBinder>
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Vector3 effectorPosition = transform.InverseTransformPoint(data.EffectorPositionSource.position);
            
            Gizmos.DrawWireSphere(effectorPosition, 0.02f);
            
            // Gizmos.DrawLine(data.ShoulderTarget.position, data.EffectorTarget.position);
            // Gizmos.DrawLine(data.UpperArmTarget.position, data.EffectorTarget.position);

            if (data.DEBUG)
            {

                Vector3 uarm2eff_rv = data.DEBUG_EffectorTarget.position - data.DEBUG_UpperTarget.position;
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(data.DEBUG_UpperTarget.position, data.DEBUG_EffectorTarget.position);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(data.DEBUG_UpperTarget.position + 0.5f * uarm2eff_rv, data.DEBUG_PoleTarget.position);
                
                Gizmos.color = Color.blue;
                
                Gizmos.DrawLine(data.DEBUG_ShoulderTarget.position, data.DEBUG_UpperTarget.position);
                Gizmos.DrawLine(data.DEBUG_UpperTarget.position, data.DEBUG_LowerTarget.position);
                Gizmos.DrawLine(data.DEBUG_LowerTarget.position, data.DEBUG_EffectorTarget.position);
                
                // Shoulder -> Upper arm
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_ShoulderTarget.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.UpperArmTarget.localPosition);
                Gizmos.DrawWireCube(data.UpperArmTarget.localPosition, 0.02f * Vector3.one);
                
                // Upper arm -> Lower arm
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_UpperTarget.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.LowerArmTarget.localPosition);
                Gizmos.DrawWireCube(data.LowerArmTarget.localPosition, 0.02f * Vector3.one);
                
                // Lower arm -> Effector
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_LowerTarget.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.EffectorTarget.localPosition);
                Gizmos.matrix = data.DEBUG_EffectorTarget.localToWorldMatrix;
                Gizmos.DrawWireCube(Vector3.zero, 0.02f * Vector3.one);
            }
        }
    }
}
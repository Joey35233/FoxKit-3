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
        public ReadOnlyTransformHandle ShoulderRotationSource;
        public ReadOnlyTransformHandle EffectorPositionSource;
        public ReadOnlyTransformHandle PoleRotationSource;
        public Vector3 ChainPlaneNormal;
        
        public ReadWriteTransformHandle Skel0Target;
        public ReadWriteTransformHandle Skel1Target;
        public ReadWriteTransformHandle Skel2Target;
        public ReadWriteTransformHandle Skel3Target;

        public bool DEBUG;
        public ReadWriteTransformHandle DEBUG_Skel0Target;
        public ReadWriteTransformHandle DEBUG_Skel1Target;
        public ReadWriteTransformHandle DEBUG_PoleTarget;
        public ReadWriteTransformHandle DEBUG_Skel2Target;
        public ReadWriteTransformHandle DEBUG_EffectorTarget;

        private quaternion InverseRootRotation;
        private float3 InverseRootPosition;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream)
        {
            InverseRootRotation = math.inverse(stream.rootMotionRotation);
            InverseRootPosition = -stream.rootMotionPosition;
        }

        private void ComputeSkel0AndSkel1(AnimationStream stream, out float3 out_skel0_rgp, out quaternion out_skel0_rgr, out float3 out_skel1_rgp)
        {
            out_skel0_rgp = Skel0Target.GetPosition(stream);
            
            out_skel0_rgr = ShoulderRotationSource.GetRotation(stream);
            
            float3 skel1_blp = Skel1Target.GetLocalPosition(stream);
            out_skel1_rgp = math.rotate(out_skel0_rgr, skel1_blp) + out_skel0_rgp;
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            float3 effector_rgp = EffectorPositionSource.GetPosition(stream);
            effector_rgp = math.mul(InverseRootRotation, effector_rgp + InverseRootPosition);

            quaternion pole_rgr = PoleRotationSource.GetRotation(stream);
            
            ComputeSkel0AndSkel1(stream, out float3 skel0_rgp, out quaternion skel0_rgr, out float3 skel1_rgp);
            
            float3 skel1toEff_rv = effector_rgp - skel1_rgp;
            
            // float3x3 pole_rgr_mat = new float3x3(pole_rgr);
            // float3 pole_rotation_x = pole_rgr_mat.c0;
            // pole_rotation_x = pole_rotation_x * -1;
            // float4 q = pole_rgr;
            // float3 pole_rotation_x = new float3(
            //     1.0f - 2.0f * (q.y * q.y + q.z * q.z),
            //     2.0f * (q.z * q.w + q.x * q.y),
            //     2.0f * (q.x * q.z - q.y * q.w)
            // );
            float3 pole_rotation_x = math.rotate(pole_rgr, new float3(-1.0f, 0.0f, 0.0f));
            float3 pole_prex_v = math.cross(skel1toEff_rv, pole_rotation_x);
            float3 pole_v = math.cross(pole_prex_v, skel1toEff_rv);
            float3 pole_uv = math.normalize(pole_v);
            
            float3 skel2_blp = Skel2Target.GetLocalPosition(stream);
            float3 skel3_blp = Skel3Target.GetLocalPosition(stream);
            
            float3 chainPlaneNormal = ChainPlaneNormal;
            
            RigPoseUnitUtils.SolveTwoBoneIK(out quaternion skel1_rgr, out quaternion skel2_rgr, skel2_blp, skel3_blp, chainPlaneNormal, skel1_rgp, effector_rgp, pole_uv);

            float3 skel2_rgp = math.rotate(skel1_rgr, skel2_blp) + skel1_rgp;
            float3 skel3_rgp = math.rotate(skel2_rgr, skel3_blp) + skel2_rgp;
            
            Skel0Target.SetGlobalTR(stream, skel0_rgp, skel0_rgr);
            Skel1Target.SetGlobalTR(stream, skel1_rgp, skel1_rgr);
            Skel2Target.SetGlobalTR(stream, skel2_rgp, skel2_rgr);
            Skel3Target.SetPosition(stream, skel3_rgp);
            
            if (DEBUG)
            {
                DEBUG_Skel0Target.SetGlobalTR(stream, skel0_rgp, skel0_rgr);
                DEBUG_Skel1Target.SetGlobalTR(stream, skel1_rgp, skel1_rgr);
                DEBUG_PoleTarget.SetPosition(stream, skel1_rgp + 0.5f * skel1toEff_rv + pole_rotation_x);
                DEBUG_Skel2Target.SetGlobalTR(stream, skel2_rgp, skel2_rgr);
                DEBUG_EffectorTarget.SetGlobalTR(stream, effector_rgp, Quaternion.identity);
            }
        }
    }

    [System.Serializable]
    public struct RigArmPoseUnitData : IAnimationJobData
    {
        public Transform ShoulderRotationSource;
        public Transform EffectorPositionSource;
        public Transform PoleRotationSource;
        public Vector3 ChainPlaneNormal;
        
        public Transform Skel0Target;
        public Transform Skel1Target;
        public Transform Skel2Target;
        public Transform Skel3Target;
        
        public bool DEBUG;
        public Transform DEBUG_Skel0Target;
        public Transform DEBUG_Skel1Target;
        public Transform DEBUG_PoleTarget;
        public Transform DEBUG_Skel2Target;
        public Transform DEBUG_EffectorTarget;
        
        public bool IsValid() => Skel0Target != null && ShoulderRotationSource != null && Skel1Target != null && Skel2Target != null && Skel3Target != null && EffectorPositionSource != null && PoleRotationSource != null;

        public void SetDefaultValues()
        {
            ShoulderRotationSource = null;
            EffectorPositionSource = null;
            PoleRotationSource = null;
            ChainPlaneNormal = new Vector3(0, 1, 0);
            
            Skel0Target = null;
            Skel1Target = null;
            Skel2Target = null;
            Skel3Target = null;
        }
    }

    public class RigArmPoseUnitJobBinder : AnimationJobBinder<RigArmPoseUnitJob, RigArmPoseUnitData>
    {
        public override RigArmPoseUnitJob Create(Animator animator, ref RigArmPoseUnitData data, Component component)
        {
            RigArmPoseUnitJob job = new RigArmPoseUnitJob
            {
                ShoulderRotationSource = ReadOnlyTransformHandle.Bind(animator, data.ShoulderRotationSource),
                EffectorPositionSource = ReadOnlyTransformHandle.Bind(animator, data.EffectorPositionSource),
                PoleRotationSource = ReadOnlyTransformHandle.Bind(animator, data.PoleRotationSource),
                ChainPlaneNormal = data.ChainPlaneNormal,
                
                Skel0Target = ReadWriteTransformHandle.Bind(animator, data.Skel0Target),
                Skel1Target = ReadWriteTransformHandle.Bind(animator, data.Skel1Target),
                Skel2Target = ReadWriteTransformHandle.Bind(animator, data.Skel2Target),
                Skel3Target = ReadWriteTransformHandle.Bind(animator, data.Skel3Target),
            };

            if (data.DEBUG)
            {
                job.DEBUG = true;
                job.DEBUG_Skel0Target = ReadWriteTransformHandle.Bind(animator, data.DEBUG_Skel0Target);
                job.DEBUG_Skel1Target = ReadWriteTransformHandle.Bind(animator, data.DEBUG_Skel1Target);
                job.DEBUG_PoleTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_PoleTarget);
                job.DEBUG_Skel2Target = ReadWriteTransformHandle.Bind(animator, data.DEBUG_Skel2Target);
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

            if (data.DEBUG)
            {
                Vector3 skel1toEff_rv = data.DEBUG_EffectorTarget.position - data.DEBUG_Skel1Target.position;
                
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(data.DEBUG_Skel1Target.position, data.DEBUG_EffectorTarget.position);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(data.DEBUG_Skel1Target.position + 0.5f * skel1toEff_rv, data.DEBUG_PoleTarget.position);
                
                Gizmos.color = Color.blue;
                
                Gizmos.DrawLine(data.DEBUG_Skel0Target.position, data.DEBUG_Skel1Target.position);
                Gizmos.DrawLine(data.DEBUG_Skel1Target.position, data.DEBUG_Skel2Target.position);
                Gizmos.DrawLine(data.DEBUG_Skel2Target.position, data.DEBUG_EffectorTarget.position);
                
                // Skel0 -> Skel1
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_Skel0Target.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.Skel1Target.localPosition);
                Gizmos.DrawWireCube(data.Skel1Target.localPosition, 0.02f * Vector3.one);
                
                // Skel1 arm -> Skel2
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_Skel1Target.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.Skel2Target.localPosition);
                Gizmos.DrawWireCube(data.Skel2Target.localPosition, 0.02f * Vector3.one);
                
                // Skel2 -> Effector
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_Skel2Target.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.Skel3Target.localPosition);
                
                Gizmos.matrix = data.DEBUG_EffectorTarget.localToWorldMatrix;
                Gizmos.DrawWireCube(Vector3.zero, 0.02f * Vector3.one);
            }
        }
    }
}
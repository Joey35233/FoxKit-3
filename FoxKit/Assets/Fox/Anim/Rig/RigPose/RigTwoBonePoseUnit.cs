using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct RigTwoBonePoseUnitJob : IWeightedAnimationJob
    {
        public ReadOnlyTransformHandle EffectorPositionSource;
        public ReadOnlyTransformHandle PoleRotationSource;
        public Vector3 ChainPlaneNormal;
        
        public ReadWriteTransformHandle Skel0Target;
        public ReadWriteTransformHandle Skel1Target;
        public ReadWriteTransformHandle EffectorTarget;

        public bool DEBUG;
        public ReadWriteTransformHandle DEBUG_Skel0Target;
        public ReadWriteTransformHandle DEBUG_PoleTarget;
        public ReadWriteTransformHandle DEBUG_Skel1Target;
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

        public void ProcessAnimation(AnimationStream stream)
        {
            // Apply inverse root correction
            float3 effector_rgp = EffectorPositionSource.GetPosition(stream);
            effector_rgp = math.mul(InverseRootRotation, effector_rgp + InverseRootPosition);

            quaternion pole_rgr = PoleRotationSource.GetRotation(stream);

            float3 skel0_rgp = Skel0Target.GetPosition(stream);
            
            float3 skel0toEff_rv = effector_rgp - skel0_rgp;

            // float3x3 pole_rgr_mat = new float3x3(pole_rgr);
            // float3 pole_rotation_x = pole_rgr_mat.c0;
            // float4 q = pole_rgr;
            // float3 pole_rotation_x = new float3(
            //     1.0f - 2.0f * (q.y * q.y + q.z * q.z),
            //     2.0f * (q.z * q.w + q.x * q.y),
            //     2.0f * (q.x * q.z - q.y * q.w)
            // );
            // pole_rotation_x = pole_rotation_x * -1;
            float3 pole_rotation_x = math.rotate(pole_rgr, new float3(-1.0f, 0.0f, 0.0f));
            float3 pole_prex_v = math.cross(skel0toEff_rv, pole_rotation_x);
            float3 pole_v = math.cross(pole_prex_v, skel0toEff_rv);
            float3 pole_uv = math.normalize(pole_v);
            
            float3 skel1_blp = Skel1Target.GetLocalPosition(stream);
            float3 effector_blp = EffectorTarget.GetLocalPosition(stream);
            
            float3 cpn_uv = ChainPlaneNormal;
            
            RigPoseUnitUtils.SolveTwoBoneIK(out quaternion skel0_rgr, out quaternion skel1_rgr, skel1_blp, effector_blp, cpn_uv, skel0_rgp, effector_rgp, pole_uv);

            float3 skel1_rgp = math.rotate(skel0_rgr, skel1_blp) + skel0_rgp;

            float3 skel2_rgp = math.rotate(skel1_rgr, effector_blp) + skel1_rgp;
            
            Skel0Target.SetGlobalTR(stream, skel0_rgp, skel0_rgr);
            Skel1Target.SetGlobalTR(stream, skel1_rgp, skel1_rgr);
            EffectorTarget.SetPosition(stream, skel2_rgp);
            
            if (DEBUG)
            {
                DEBUG_Skel0Target.SetGlobalTR(stream, skel0_rgp, skel0_rgr);
                DEBUG_PoleTarget.SetPosition(stream, skel0_rgp + 0.5f * skel0toEff_rv + pole_rotation_x);
                DEBUG_Skel1Target.SetGlobalTR(stream, skel1_rgp, skel1_rgr);
                DEBUG_EffectorTarget.SetGlobalTR(stream, effector_rgp, Quaternion.identity);
            }
        }
    }

    [System.Serializable]
    public struct RigTwoBonePoseUnitData : IAnimationJobData
    {
        public Transform EffectorPositionSource;
        public Transform PoleRotationSource;
        public Vector3 ChainPlaneNormal;
        
        public Transform Skel0Target;
        public Transform Skel1Target;
        public Transform EffectorTarget;
        
        public bool DEBUG;
        public Transform DEBUG_Skel0Target;
        public Transform DEBUG_PoleTarget;
        public Transform DEBUG_Skel1Target;
        public Transform DEBUG_EffectorTarget;
        
        public bool IsValid() => Skel0Target != null && PoleRotationSource != null && Skel1Target != null && EffectorTarget != null && EffectorPositionSource != null;

        public void SetDefaultValues()
        {
            EffectorPositionSource = null;
            PoleRotationSource = null;
            ChainPlaneNormal = new Vector3(0, 1, 0);
            
            Skel0Target = null;
            Skel1Target = null;
            EffectorTarget = null;
        }
    }

    public class RigTwoBonePoseUnitJobBinder : AnimationJobBinder<RigTwoBonePoseUnitJob, RigTwoBonePoseUnitData>
    {
        public override RigTwoBonePoseUnitJob Create(Animator animator, ref RigTwoBonePoseUnitData data, Component component)
        {
            RigTwoBonePoseUnitJob job = new RigTwoBonePoseUnitJob
            {
                EffectorPositionSource = ReadOnlyTransformHandle.Bind(animator, data.EffectorPositionSource),
                PoleRotationSource = ReadOnlyTransformHandle.Bind(animator, data.PoleRotationSource),
                ChainPlaneNormal = data.ChainPlaneNormal,
                
                Skel0Target = ReadWriteTransformHandle.Bind(animator, data.Skel0Target),
                Skel1Target = ReadWriteTransformHandle.Bind(animator, data.Skel1Target),
                EffectorTarget = ReadWriteTransformHandle.Bind(animator, data.EffectorTarget),
            };

            if (data.DEBUG)
            {
                job.DEBUG = true;
                job.DEBUG_Skel0Target = ReadWriteTransformHandle.Bind(animator, data.DEBUG_Skel0Target);
                job.DEBUG_PoleTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_PoleTarget);
                job.DEBUG_Skel1Target = ReadWriteTransformHandle.Bind(animator, data.DEBUG_Skel1Target);
                job.DEBUG_EffectorTarget = ReadWriteTransformHandle.Bind(animator, data.DEBUG_EffectorTarget);
            }

            return job;
        }

        public override void Destroy(RigTwoBonePoseUnitJob job) {}
    }

    public class RigTwoBonePoseUnit : RigConstraint<RigTwoBonePoseUnitJob, RigTwoBonePoseUnitData, RigTwoBonePoseUnitJobBinder>
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Vector3 effectorPosition = transform.InverseTransformPoint(data.EffectorPositionSource.position);
            Gizmos.DrawWireSphere(effectorPosition, 0.02f);

            if (data.DEBUG)
            {
                Vector3 skel0toEff_rv = data.DEBUG_EffectorTarget.position - data.DEBUG_Skel0Target.position;
                
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(data.DEBUG_Skel0Target.position, data.DEBUG_EffectorTarget.position);
                
                Gizmos.color = Color.white;
                Gizmos.DrawLine(data.DEBUG_Skel0Target.position + 0.5f * skel0toEff_rv, data.DEBUG_PoleTarget.position);
                
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(data.DEBUG_Skel0Target.position, data.DEBUG_Skel1Target.position);
                Gizmos.DrawLine(data.DEBUG_Skel1Target.position, data.DEBUG_EffectorTarget.position);
                
                // Skel0 -> Skel1
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_Skel0Target.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.Skel1Target.localPosition);
                Gizmos.DrawWireCube(data.Skel1Target.localPosition, 0.02f * Vector3.one);
                
                // Skel1 -> Effector
                Gizmos.color = Color.yellow;
                Gizmos.matrix = data.DEBUG_Skel1Target.localToWorldMatrix;
                Gizmos.DrawLine(Vector3.zero, data.EffectorTarget.localPosition);
                
                Gizmos.matrix = data.DEBUG_EffectorTarget.localToWorldMatrix;
                Gizmos.DrawWireCube(Vector3.zero, 0.02f * Vector3.one);
            }
        }
    }
}
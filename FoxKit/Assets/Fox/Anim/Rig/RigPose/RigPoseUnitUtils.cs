using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    public static class RigPoseUnitUtils
    {
        internal static void SolveTwoBoneIK(out quaternion out_upperArm_gr, out quaternion out_lowerArm_gr, float3 lowerArm_blp, float3 effector_blp, float3 chainPlaneNormal, float3 upperArm_rgp, float3 effector_rgp, float3 chain_uv)
        {
            float3 uarm2eff_rv = effector_rgp - upperArm_rgp;
            
            // Normalized vectors
            float3 lowerArm_buv = math.normalize(lowerArm_blp);
            float3 effector_buv = math.normalize(effector_blp);
            float3 uarm2eff_ruv = math.normalize(uarm2eff_rv);

            // Lengths
            float lowerArm_blp_len2 = math.dot(lowerArm_blp, lowerArm_blp);
            float effector_blp_len2 = math.dot(effector_blp, effector_blp);
            float uarm2eff_rv_len2 = math.dot(uarm2eff_rv, uarm2eff_rv);

            float lowerArm_blp_len = math.sqrt(lowerArm_blp_len2);
            float effector_blp_len = math.sqrt(effector_blp_len2);
            float uarm2eff_rv_len = math.sqrt(uarm2eff_rv_len2);

            // UpperArm
            float3 basisA_uv = math.cross(chain_uv, uarm2eff_ruv);

            float weirdLen = ((lowerArm_blp_len2 - effector_blp_len2) + uarm2eff_rv_len2) * 0.5f / uarm2eff_rv_len;
            weirdLen = math.max(weirdLen, 0);

            float maskedWeirdLen = (uarm2eff_rv_len < effector_blp_len + lowerArm_blp_len) ? weirdLen : lowerArm_blp_len;
            float maskedWeirdLen2 = maskedWeirdLen * maskedWeirdLen;
            float maskedWeirdDist2 = lowerArm_blp_len2 - maskedWeirdLen2;
            float clampedMaskedWeirdDist2 = Mathf.Max(maskedWeirdDist2, 0);
            float packedWeirdDist = math.sqrt(clampedMaskedWeirdDist2);

            float3 upperArm_basisB_v = maskedWeirdLen * uarm2eff_ruv + packedWeirdDist * chain_uv;
            float3 upperArm_basisB_uv = math.normalize(upperArm_basisB_v);

            float3 basisC_uv = math.cross(upperArm_basisB_uv, basisA_uv);

            float3 lowerArmCrossNormal = math.cross(lowerArm_buv, chainPlaneNormal);

            float3x3 upperArmMatrixPre = new float3x3(chainPlaneNormal, lowerArm_buv, lowerArmCrossNormal);
            float3x3 upperArmMatrixPost = new float3x3(basisA_uv, upperArm_basisB_uv, basisC_uv);
            float3x3 upperArmMatrix = math.mul(upperArmMatrixPre, math.transpose(upperArmMatrixPost));
            out_upperArm_gr = ToRotation(upperArmMatrix);

            // LowerArm
            float3 lowerArm_basisB_v = uarm2eff_rv - upperArm_basisB_v;
            float3 lowerArm_basisB_uv = math.normalize(lowerArm_basisB_v);

            basisC_uv = math.cross(lowerArm_basisB_uv, basisA_uv);

            float3 effectorCrossNormal = math.cross(effector_buv, chainPlaneNormal);
            
            float3x3 lowerArmMatrixPre = new float3x3(chainPlaneNormal, effector_buv, effectorCrossNormal);
            float3x3 lowerArmMatrixPost = new float3x3(basisA_uv, lowerArm_basisB_uv, basisC_uv);
            float3x3 lowerArmMatrix = math.mul(lowerArmMatrixPre, math.transpose(lowerArmMatrixPost));
            out_lowerArm_gr = ToRotation(lowerArmMatrix);
        }

        private static quaternion ToRotation(float3x3 mat)
        {
            //mat = math.transpose(mat);
            float m00 = mat[0][0];
            float m01 = mat[0][1];
            float m02 = mat[0][2];
            float m10 = mat[1][0];
            float m11 = mat[1][1];
            float m12 = mat[1][2];
            float m20 = mat[2][0];
            float m21 = mat[2][1];
            float m22 = mat[2][2];

            float tr = m00 + m11 + m22;
            
            float qw = 1f;
            float qx = 0f;
            float qy = 0f;
            float qz = 0f;

            if (tr > 0) { 
                float S = math.sqrt(tr+1.0f) * 2; // S=4*qw 
                qw = 0.25f * S;
                qx = (m21 - m12) / S;
                qy = (m02 - m20) / S; 
                qz = (m10 - m01) / S; 
            } else if ((m00 > m11)&(m00 > m22)) { 
                float S = math.sqrt(1.0f + m00 - m11 - m22) * 2; // S=4*qx 
                qw = (m21 - m12) / S;
                qx = 0.25f * S;
                qy = (m01 + m10) / S; 
                qz = (m02 + m20) / S; 
            } else if (m11 > m22) { 
                float S = math.sqrt(1.0f + m11 - m00 - m22) * 2; // S=4*qy
                qw = (m02 - m20) / S;
                qx = (m01 + m10) / S; 
                qy = 0.25f * S;
                qz = (m12 + m21) / S; 
            } else { 
                float S = math.sqrt(1.0f + m22 - m00 - m11) * 2; // S=4*qz
                qw = (m10 - m01) / S;
                qx = (m02 + m20) / S;
                qy = (m12 + m21) / S;
                qz = 0.25f * S;
            }

            return new quaternion(qx, qy, qz, qw);
        }
    }
}
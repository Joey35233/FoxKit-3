using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace Fox.Anim
{
    public static class RigPoseUnitUtils
    {
        public static void SolveTwoBoneIK(out quaternion out_skel0_rgr, out quaternion out_skel1_rgr, float3 skel1_blp, float3 skel2_blp, float3 cpn_uv, float3 skel0_rgp, float3 effector_rgp, float3 pole_uv)
        {
            float3 skel0ToEff_rv = effector_rgp - skel0_rgp;
            
            // Normalized vectors
            float3 skel1_bluv = math.normalize(skel1_blp);
            float3 skel2_bluv = math.normalize(skel2_blp);
            float3 skel0ToEff_ruv = math.normalize(skel0ToEff_rv);

            // Lengths
            float skel1_blp_len2 = math.dot(skel1_blp, skel1_blp);
            float skel2_blp_len2 = math.dot(skel2_blp, skel2_blp);
            float skel0ToEff_rv_len2 = math.dot(skel0ToEff_rv, skel0ToEff_rv);

            float skel1_blp_len = math.sqrt(skel1_blp_len2);
            float skel2_blp_len = math.sqrt(skel2_blp_len2);
            float skel0ToEff_rv_len = math.sqrt(skel0ToEff_rv_len2);
            
            float3 basisA_uv = FoxCross(pole_uv, skel0ToEff_ruv);

            // Law of Cosines
            float triX_len = (skel1_blp_len2 - skel2_blp_len2 + skel0ToEff_rv_len2) / (2 * skel0ToEff_rv_len);
            triX_len = math.max(triX_len, 0);

            triX_len = (skel0ToEff_rv_len < skel2_blp_len + skel1_blp_len) ? triX_len : skel1_blp_len;
            float triY_len2 = skel1_blp_len2 - triX_len * triX_len;
            triY_len2 = math.max(triY_len2, 0);
            float triY_len = math.sqrt(triY_len2);
            
            // Skel0
            float3 skel0BasisB_v = triX_len * skel0ToEff_ruv + triY_len * pole_uv;
            float3 skel0BasisB_uv = math.normalize(skel0BasisB_v);
            
            float3x3 skel0_bindBasis = new float3x3(cpn_uv, skel1_bluv, FoxCross(cpn_uv, skel1_bluv));
            float3x3 skel0_rigBasis = new float3x3(basisA_uv, skel0BasisB_uv, FoxCross(basisA_uv, skel0BasisB_uv));
            float3x3 skel0Mat = math.mul(skel0_bindBasis, math.transpose(skel0_rigBasis));
            out_skel0_rgr = ToRotation(skel0Mat);

            // Skel1
            float3 skel1BasisB_uv = math.normalize(skel0ToEff_rv - skel0BasisB_v);
            
            float3x3 skel1_bindBasis = new float3x3(cpn_uv, skel2_bluv, FoxCross(cpn_uv, skel2_bluv));
            float3x3 skel1_rigBasis = new float3x3(basisA_uv, skel1BasisB_uv, FoxCross(basisA_uv, skel1BasisB_uv));
            float3x3 skel1Mat = math.mul(skel1_bindBasis, math.transpose(skel1_rigBasis));
            out_skel1_rgr = ToRotation(skel1Mat);
        }

        private static float3 FoxCross(float3 a, float3 b)
        {
            return math.cross(b, a);
        }

        private static quaternion ToRotation(float3x3 mat)
        {
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

            float4 q;

            if (tr > 0) { 
                float S = math.sqrt(tr+1.0f) * 2; // S=4*qw 
                q.x = (m21 - m12) / S;
                q.y = (m02 - m20) / S; 
                q.z = (m10 - m01) / S; 
                q.w = 0.25f * S;
            } else if ((m00 > m11)&(m00 > m22)) { 
                float S = math.sqrt(1.0f + m00 - m11 - m22) * 2; // S=4*qx 
                q.x = 0.25f * S;
                q.y = (m01 + m10) / S; 
                q.z = (m02 + m20) / S; 
                q.w = (m21 - m12) / S;
            } else if (m11 > m22) { 
                float S = math.sqrt(1.0f + m11 - m00 - m22) * 2; // S=4*qy
                q.x = (m01 + m10) / S; 
                q.y = 0.25f * S;
                q.z = (m12 + m21) / S; 
                q.w = (m02 - m20) / S;
            } else { 
                float S = math.sqrt(1.0f + m22 - m00 - m11) * 2; // S=4*qz
                q.x = (m02 + m20) / S;
                q.y = (m12 + m21) / S;
                q.z = 0.25f * S;
                q.w = (m10 - m01) / S;
            }

            return new quaternion(q);
        }
    }
}
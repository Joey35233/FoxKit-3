using Unity.Mathematics;
using UnityEngine;

[ExecuteAlways]
public class TestDriver : MonoBehaviour
{
    public Transform Skel0;
    //public Transform Skel1;
    public Transform Effector;

    public Transform Pole;

    void OnDrawGizmos()
    {
        float3 skel0_rgp = Skel0.position;
        float3 effector_rgp = Effector.position;
        float3 skel1_blp     = new float3(0.284000f, 0.000000f, 0.000000f); 
        float3 effector_blp     = new float3(0.255000f, 0.000000f, 0.000000f); 
        float3 chainPlaneNormal = new float3(0.000000f, 1.000000f, 0.000000f);
        
        float3 skel0toEff_rlv = effector_rgp - skel0_rgp;
        float3 skel0toEff_rulv = math.normalize(skel0toEff_rlv);
        
        float3 pole_rgp = Pole.position;
        
        float3 chain_uvA = skel0_rgp + (math.dot(pole_rgp - skel0_rgp, skel0toEff_rulv) * skel0toEff_rulv);
        float3 chain_uv = pole_rgp - chain_uvA;
        chain_uv = math.normalize(chain_uv);
        
        Fox.Anim.RigPoseUnitUtils.SolveTwoBoneIK(out quaternion skel0_rgr, out quaternion skel1_rgr, skel1_blp, effector_blp, chainPlaneNormal, skel0_rgp, effector_rgp, chain_uv);
        
        float3 skel1_rgp = math.rotate(skel0_rgr, skel1_blp) + skel0_rgp;
        float3 trueEffector_rgp = math.rotate(skel1_rgr, effector_blp) + skel1_rgp;
        
        Gizmos.matrix = Matrix4x4.identity;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(chain_uvA, chain_uvA + chain_uv);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(effector_rgp, 0.02f);
        Gizmos.DrawLine(skel0_rgp, skel0_rgp + skel0toEff_rlv);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(skel0_rgp, new float3(0.02));
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(skel0_rgp, skel1_rgp);
        Gizmos.DrawWireCube(skel1_rgp, new float3(0.02));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(skel1_rgp, trueEffector_rgp);
        Gizmos.DrawWireCube(trueEffector_rgp, new float3(0.02));
    }
}

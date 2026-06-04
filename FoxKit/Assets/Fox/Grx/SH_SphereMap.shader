Shader "Fox/SH_SphereMap"
{
    Properties
    {
    }

    SubShader
    {
        ZTest Always

        Pass
        {
            Name "MAIN"

            HLSLPROGRAM

            #pragma target 5.0 
            #pragma enable_d3d11_debug_symbols
            // -------------------------------------

#define UNITYPATCH_WORK_TYPE_SPHEREMAP

            #include "../UnityPatch/PreHLSL.hlsl"

////////////////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "SH_SphereMap_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "SH_SphereMap_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

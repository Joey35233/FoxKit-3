Shader "Fox/SSLighting2_SH_SkyLight_Encode"
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

#define UNITYPATCH_WORK_TYPE_SHLIGHT

            #include "../UnityPatch/PreHLSL.hlsl"

///////////////////////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "SSLighting2_SH_SkyLight_Encode_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "SSLighting2_SH_SkyLight_Encode_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

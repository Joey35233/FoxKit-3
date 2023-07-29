Shader "Fox/DownSampleDepth"
{
    Properties
    {
    }

    SubShader
    {
        ColorMask 0
        ZTest Always

        Pass
        {
            Name "MAIN"

            HLSLPROGRAM

            #pragma target 5.0 
            #pragma enable_d3d11_debug_symbols
            // -------------------------------------

            #include "../UnityPatch/PreHLSL.hlsl"

////////////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "DownSampleDepth_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "DownSampleDepth_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

Shader "Fox/VolFog_TppVolFog"
{
    Properties
    {
    }

    SubShader
    {
        Cull Off
        ZWrite Off

        Pass
        {
            Name "MAIN"

            HLSLPROGRAM

            #pragma target 5.0 
            #pragma enable_d3d11_debug_symbols
            // -------------------------------------

            #include "../UnityPatch/PreHLSL.hlsl"

///////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "VolFog_TppVolFog_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "VolFog_TppVolFog_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

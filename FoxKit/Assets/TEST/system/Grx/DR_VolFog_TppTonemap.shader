Shader "Fox/DR_VolFog_TppTonemap"
{
    Properties
    {
        inLightSpecular("inLightSpecular", 2D) = "black" {}
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

            #include "../UnityPatch/PreHLSL.hlsl"

////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "DR_VolFog_TppTonemap_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "DR_VolFog_TppTonemap_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

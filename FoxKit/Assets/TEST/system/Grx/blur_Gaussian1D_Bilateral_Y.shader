Shader "Fox/blur_Gaussian1D_Bilateral_Y"
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

            #include "../UnityPatch/PreHLSL.hlsl"

////////////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "blur_Gaussian1D_Bilateral_Y_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "blur_Gaussian1D_Bilateral_Y_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

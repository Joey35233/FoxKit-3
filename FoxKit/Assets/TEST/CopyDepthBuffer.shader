Shader "Fox/CopyDepthBuffer"
{
    Properties
    {
        g_sMaterial_m_materials_0("g_ssMaterial_m_materials_0", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_1("g_ssMaterial_m_materials_1", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_2("g_ssMaterial_m_materials_2", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_3("g_ssMaterial_m_materials_3", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_4("g_ssMaterial_m_materials_4", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_5("g_ssMaterial_m_materials_5", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_6("g_ssMaterial_m_materials_6", Vector) = (0, 0, 0, 0)
        g_sMaterial_m_materials_7("g_ssMaterial_m_materials_7", Vector) = (0, 0, 0, 0)
    }

    SubShader
    {
        ColorMask 0
        Cull Off

        Pass
        {
            Name "MAIN"

            HLSLPROGRAM

            #pragma target 5.0 
            #pragma enable_d3d11_debug_symbols
            // -------------------------------------

            #include "UnityPatch_PreHLSL.hlsl"

////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "CopyDepthBuffer_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "CopyDepthBuffer_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}
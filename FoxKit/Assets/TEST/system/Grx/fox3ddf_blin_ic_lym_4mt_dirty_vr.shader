Shader"Fox/fox3DDF_Blin_Incidence_LayerMul_4MT_Dirty_LNM_VR"
{
    Properties
    {
        g_tex_diffuse("Base_Tex_SRGB", 2D) = "white" {}
        g_tex_normal("NormalMap_Tex_NRM", 2D) = "bump" {}
        [Gamma] g_tex_srm("SpecularMap_Tex_LIN", 2D) = "white" {}
        [Gamma] g_tex_materialmap("MatParamMap_Tex_LIN", 2D) = "black" {}
        g_tex_layer("Layer_Tex_SRGB", 2D) = "white" {}
        [Gamma] g_tex_layerMask("LayerMask_Tex_LIN", 2D) = "black" {}
        [Gamma] g_tex_Dirty("Dirty_Tex_LIN", 2D) = "black" {}

        /*[HideInInspector]*/ g_sMaterial_m_materials_0("g_ssMaterial_m_materials_0", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_1("g_ssMaterial_m_materials_1", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_2("g_ssMaterial_m_materials_2", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_3("g_ssMaterial_m_materials_3", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_4("g_ssMaterial_m_materials_4", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_5("g_ssMaterial_m_materials_5", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_6("g_ssMaterial_m_materials_6", Vector) = (0, 0, 0, 0)
        /*[HideInInspector]*/ g_sMaterial_m_materials_7("g_ssMaterial_m_materials_7", Vector) = (0, 0, 0, 0)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            Name "MAIN"
            Tags { "LightMode" = "MAIN" }

            HLSLPROGRAM

            #pragma target 5.0
            #pragma enable_d3d11_debug_symbols
            // -------------------------------------

            #include "../UnityPatch/PreHLSL.hlsl"

            #define g_sampler_diffuse sampler_g_tex_diffuse
            #define g_sampler_normal sampler_g_tex_normal
            #define g_sampler_srm sampler_g_tex_srm
            #define g_sampler_materialmap sampler_g_tex_materialmap
            #define g_sampler_layer sampler_g_tex_layer
            #define g_sampler_layerMask sampler_g_tex_layerMask
            #define g_sampler_Dirty sampler_g_tex_Dirty

            #include "../Gr/Dg/shader/fox3ddf_blin_ic_lym_4mt_dirty_vr.shdr"

            /////////////////////////////////////
            #pragma vertex vs_main
#if defined(SHADER_STAGE_VERTEX)
            #include "fox3ddf_blin_ic_lym_4mt_dirty_vr_vs.hlsl"
#endif

            #pragma fragment ps_main
#if defined(SHADER_STAGE_FRAGMENT)
            #include "fox3ddf_blin_ic_lym_4mt_dirty_vr_ps.hlsl"
#endif

            ENDHLSL
        }
    }
}

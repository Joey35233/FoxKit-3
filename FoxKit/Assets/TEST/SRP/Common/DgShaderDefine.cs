using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public static class DgShaderDefine
    {
        private static int[] ShaderIdMap = new int[]
        {
            Shader.PropertyToID("UnityPatch_g_sSystem_m_param"),
            Shader.PropertyToID("UnityPatch_g_sSystem_m_renderInfo"),
            Shader.PropertyToID("UnityPatch_g_sSystem_m_renderBuffer"),
            Shader.PropertyToID("UnityPatch_g_sSystem_m_dominantLightDir"),

            Shader.PropertyToID("UnityPatch_g_sScene_m_projectionView"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_projection"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_view"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_shadowProjection"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_shadowProjection2"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_eyepos"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_projectionParam"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_viewportSize"), 
            Shader.PropertyToID("UnityPatch_g_sScene_m_exposure"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_fogParam_0"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_fogParam_1"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_fogParam_2"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_fogColor"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_cameraCenterOffset"),
            Shader.PropertyToID("UnityPatch_g_sScene_m_shadowMapResolutions"),

            ////Shader.PropertyToID("UnityPatch_g_sRenderBuffer_m_size"), 

            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_0"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_1"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_2"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_3"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_4"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_5"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_6"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_7"),
            Shader.PropertyToID("UnityPatch_g_sLights_m_lightParams_8"),

            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_0"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_1"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_2"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_3"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_4"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_5"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_6"),
            Shader.PropertyToID("UnityPatch_g_sMaterial_m_materials_7"),

            //Shader.PropertyToID("UnityPatch_g_sObject_m_viewWorld"),
            //Shader.PropertyToID("UnityPatch_g_sObject_m_world"),
            Shader.PropertyToID("UnityPatch_g_sObject_m_useWeightCount"),
            Shader.PropertyToID("UnityPatch_g_sObject_m_localParam_0"),
            Shader.PropertyToID("UnityPatch_g_sObject_m_localParam_1"),
            Shader.PropertyToID("UnityPatch_g_sObject_m_localParam_2"),
            Shader.PropertyToID("UnityPatch_g_sObject_m_localParam_3"),

            //Shader.PropertyToID("UnityPatch_g_sBone_m_boneMatrices"), 
            //Shader.PropertyToID("UnityPatch_g_sBone_m_prevBoneMatrices"),
            
            Shader.PropertyToID("UnityPatch_g_sWork_m_viewInverse"),
            Shader.PropertyToID("UnityPatch_g_sWork_m_matrix"),
        };

        // Commented-out values are automatically propagated in the shaders by Unity-supplied values or currently unsupported (bones). V_RENDERBUFFER_SIZE was already deprecated by Fox.
        public enum ConstantId
        {
            // システムパラメータ
            V_SYSTEMPARAM,
            V_RENDERINFO,
            V_RENDERBUFFER_SIZE,
            V_DOMINANTLIGHT_DIR,
            // シーン固有パラメータ
            M_PROJECTIONVIEW,
            M_PROJECTION,
            M_VIEW,
            M_SHADOWPROJECTION,
            M_SHADOWPROJECTION2,
            V_EYEPOS,
            V_PROJECTIONPARAM,
            V_VIEWPORTSIZE,
            V_EXPOSURE,
            V_FOGPARAM0,
            V_FOGPARAM1,
            V_FOGPARAM2,
            V_FOGCOLOR,
            V_CAMERACENTEROFFSET,
            V_SHADOWMAPRESOLUTIONS,
            // レンダーバッファ固有パラメータ
            ////V_RENDERBUFFER_SIZE		= (SHADER_CONST_RENDERBUFFER_SIZE),
            // ライトパラメータ
            V_LIGHTPARAM0,
            V_LIGHTPARAM1,
            V_LIGHTPARAM2,
            V_LIGHTPARAM3,
            V_LIGHTPARAM4,
            V_LIGHTPARAM5,
            V_LIGHTPARAM6,
            V_LIGHTPARAM7,
            V_LIGHTPARAM8,
            // マテリアルパラメータ
            V_MATERIAL0,
            V_MATERIAL1,
            V_MATERIAL2,
            V_MATERIAL3,
            V_MATERIAL4,
            V_MATERIAL5,
            V_MATERIAL6,
            V_MATERIAL7,
            // オブジェクト固有パラメータ
            //M_VIEWWORLD,
            //M_WORLD,
            V_USEWEIGHTCOUNT,
            V_LOCALPARAM0,
            V_LOCALPARAM1,
            V_LOCALPARAM2,
            V_LOCALPARAM3,
            // ボーンマトリクス配列
            //M_BLENDMATRIX0,
            //M_PREV_BLENDMATRIX0,
            // ワーク
            M_VIEWINVERSE,
            M_WORKMATRIX0,
        }

        private static int GetShaderIdFromConstantId(ConstantId id) => ShaderIdMap[(int)id];

        public static void SetVector(Material material, ConstantId id, Vector4 value)
        {
            Debug.Assert(id != ConstantId.M_SHADOWPROJECTION && id != ConstantId.M_SHADOWPROJECTION2 && id != ConstantId.M_WORKMATRIX0);

            material.SetVector(GetShaderIdFromConstantId(id), value);
        }
        public static void SetGlobalVector(CommandBuffer buffer, ConstantId id, Vector4 value)
        {
            Debug.Assert(id != ConstantId.M_SHADOWPROJECTION && id != ConstantId.M_SHADOWPROJECTION2 && id != ConstantId.M_WORKMATRIX0);

            buffer.SetGlobalVector(GetShaderIdFromConstantId(id), value);
        }

        public static void SetMatrix(Material material, ConstantId id, Matrix4x4 value)
        {
            Debug.Assert(id == ConstantId.M_SHADOWPROJECTION || id == ConstantId.M_SHADOWPROJECTION2);

            material.SetMatrix(GetShaderIdFromConstantId(id), value);
        }
        public static void SetGlobalMatrix(CommandBuffer buffer, ConstantId id, Matrix4x4 value)
        {
            Debug.Assert(id == ConstantId.M_PROJECTIONVIEW || id == ConstantId.M_PROJECTION || id == ConstantId.M_VIEW || id == ConstantId.M_SHADOWPROJECTION || id == ConstantId.M_SHADOWPROJECTION2);

            buffer.SetGlobalMatrix(GetShaderIdFromConstantId(id), value.transpose);
        }

        public static void SetMatrixArray(Material material, ConstantId id, Matrix4x4[] value)
        {
            Debug.Assert(id == ConstantId.M_WORKMATRIX0);
            Debug.Assert(value.Length == 8);

            material.SetMatrixArray(GetShaderIdFromConstantId(id), value);
        }
    }
}
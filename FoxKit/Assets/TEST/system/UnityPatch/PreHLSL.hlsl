#define DG_SHADER_GEN_DX11
#define F_TARGET_WIN32

#define BLENDWEIGHT BLENDWEIGHTS

#define g_samplerPoint_Wrap samplerPoint_Repeat
#define g_samplerPoint_Clamp samplerPoint_Clamp
#define g_samplerLinear_Wrap samplerLinear_Repeat
#define g_samplerLinear_Clamp samplerLinear_Clamp
#define g_samplerAnisotropic_Wrap samplerAnisotropic_Repeat
#define g_samplerAnisotropic_Clamp samplerAnisotropic_Clamp
#define g_samplerComparisonLess_Point_Clmap samplerComparisonLess_Point_Clamp
#define g_samplerComparisonLess_Linear_Clmap samplerComparisonLess_Linear_Clamp

// Intentionally cramming everything into UnityPerDraw to meet SRP Batcher requirements.
cbuffer UnityPerDraw
{
    float4x4 unity_ObjectToWorld;
    float4x4 unity_WorldToObject;
    float4 unity_LODFade; // x is the fade value ranging within [0,1]. y is x quantized into 16 levels
//};

//cbuffer UnityLighting
//{
//#ifdef USING_DIRECTIONAL_LIGHT
//    half4 _WorldSpaceLightPos0;
//#else
    //float4 _WorldSpaceLightPos0;
//#endif

    //float4 _LightPositionRange; // xyz = pos, w = 1/range
    //float4 _LightProjectionParams; // for point light projection: x = zfar / (znear - zfar), y = (znear * zfar) / (znear - zfar), z=shadow bias, w=shadow scale bias

    //float4 unity_4LightPosX0;
    //float4 unity_4LightPosY0;
    //float4 unity_4LightPosZ0;
    //half4 unity_4LightAtten0;

    //half4 unity_LightColor[8];


    //float4 unity_LightPosition[8]; // view-space vertex light positions (position,1), or (-direction,0) for directional lights.
    //// x = cos(spotAngle/2) or -1 for non-spot
    //// y = 1/cos(spotAngle/4) or 1 for non-spot
    //// z = quadratic attenuation
    //// w = range*range
    //half4 unity_LightAtten[8];
    //float4 unity_SpotDirection[8]; // view-space spot light directions, or (0,0,1,0) for non-spot

    //// SH lighting environment
    //half4 unity_SHAr;
    //half4 unity_SHAg;
    //half4 unity_SHAb;
    //half4 unity_SHBr;
    //half4 unity_SHBg;
    //half4 unity_SHBb;
    //half4 unity_SHC;

    //// part of Light because it can be used outside of shadow distance
    //fixed4 unity_OcclusionMaskSelector;
    //fixed4 unity_ProbesOcclusion;
//};

//cbuffer UnityPerCamera
//{
    //// Time (t = time since current level load) values from Unity
    //float4 _Time; // (t/20, t, t*2, t*3)
    //float4 _SinTime; // sin(t/8), sin(t/4), sin(t/2), sin(t)
    //float4 _CosTime; // cos(t/8), cos(t/4), cos(t/2), cos(t)
    //float4 unity_DeltaTime; // dt, 1/dt, smoothdt, 1/smoothdt

//#if !defined(USING_STEREO_MATRICES)
    //float3 _WorldSpaceCameraPos;
//#endif

    // x = 1 or -1 (-1 if projection is flipped)
    // y = near plane
    // z = far plane
    // w = 1/far plane
    //float4 _ProjectionParams;

    // x = width
    // y = height
    // z = 1 + 1.0/width
    // w = 1 + 1.0/height
    //float4 _ScreenParams;

    // Values used to linearize the Z buffer (http://www.humus.name/temp/Linearize%20depth.txt)
    // x = 1-far/near

    // y = far/near
    // z = x/far
    // w = y/far
    // or in case of a reversed depth buffer (UNITY_REVERSED_Z is 1)
    // x = -1+far/near
    // y = 1
    // z = x/far
    // w = 1/far
    //float4 _ZBufferParams;
//};

//cbuffer UnityPerFrame
//{
    //float4x4 glstate_matrix_projection;
    //float4x4 unity_MatrixV;
    //float4x4 unity_MatrixInvV;
    //float4x4 unity_MatrixVP;
};

// --------------------------------
// UnityPatch
// --------------------------------

// SYSTEM 0
cbuffer UnityPatch_SSystem
{
    float4 UnityPatch_g_sSystem_m_param; ///< wにアルファテストの閾値入れて使っている箇所があったので残しておきます
    float4 UnityPatch_g_sSystem_m_renderInfo; ///< 現在のビューポートサイズが入る（VPOS/WPOS変換のため）
    float4 UnityPatch_g_sSystem_m_renderBuffer; ///< (xy:現在レンダリング中バッファのサイズ,zw:サイズの逆数)
    float4 UnityPatch_g_sSystem_m_dominantLightDir; ///< 支配的な光源方向（Viewspece）
};

// SCENE 2
cbuffer UnityPatch_SScene
{
    float4x4 UnityPatch_g_sScene_m_projectionView; ///< ( 投影 x ビュー )マトリクス
    float4x4 UnityPatch_g_sScene_m_projection; ///< 投影マトリクス
    float4x4 UnityPatch_g_sScene_m_view; ///< ビューマトリクス
    float4x4 UnityPatch_g_sScene_m_shadowProjection; ///< 影投影マトリクス
    float4x4 UnityPatch_g_sScene_m_shadowProjection2; ///< 影投影マトリクス2
    float4 UnityPatch_g_sScene_m_eyepos; ///< 視点座標
    float4 UnityPatch_g_sScene_m_projectionParam; ///< 投影パラメータ( Z => W 変換等用 )
    float4 UnityPatch_g_sScene_m_viewportSize; ///< ビューポートサイズ
    float4 UnityPatch_g_sScene_m_exposure; ///< 露出関連パラメータ
    float4 UnityPatch_g_sScene_m_fogParam_0; ///< フォグパラメータ
    float4 UnityPatch_g_sScene_m_fogParam_1;
    float4 UnityPatch_g_sScene_m_fogParam_2;
    float4 UnityPatch_g_sScene_m_fogColor; ///< フォグカラー
    float4 UnityPatch_g_sScene_m_cameraCenterOffset; ///< ワールド座標上でのカメラセンター
    float4 UnityPatch_g_sScene_m_shadowMapResolutions; ///< シャドウマップサイズ変更用のパラメータ対応
};

// RENDERBUFFER 1
//cbuffer UnityPatch_SRenderBuffer
//{
//    float4 UnityPatch_g_sRenderBuffer_m_size; ///< xy = サイズ, zw = サイズの逆数
//};

// LIGHTS 3
cbuffer UnityPatch_SLights
{
    float4 UnityPatch_g_sLights_m_lightParams_0;
    float4 UnityPatch_g_sLights_m_lightParams_1;
    float4 UnityPatch_g_sLights_m_lightParams_2;
    float4 UnityPatch_g_sLights_m_lightParams_3;
    float4 UnityPatch_g_sLights_m_lightParams_4;
    float4 UnityPatch_g_sLights_m_lightParams_5;
    float4 UnityPatch_g_sLights_m_lightParams_6;
    float4 UnityPatch_g_sLights_m_lightParams_7;
    float4 UnityPatch_g_sLights_m_lightParams_8;
    float4 UnityPatch_g_sLights_m_lightParams_9;
    float4 UnityPatch_g_sLights_m_lightParams_10;
};

// MATERIAL 4
cbuffer UnityPerMaterial
{
    float4 UnityPatch_g_sMaterial_m_materials_0;
    float4 UnityPatch_g_sMaterial_m_materials_1;
    float4 UnityPatch_g_sMaterial_m_materials_2;
    float4 UnityPatch_g_sMaterial_m_materials_3;
    float4 UnityPatch_g_sMaterial_m_materials_4;
    float4 UnityPatch_g_sMaterial_m_materials_5;
    float4 UnityPatch_g_sMaterial_m_materials_6;
    float4 UnityPatch_g_sMaterial_m_materials_7;
};

// OBJECT 5
cbuffer UnityPatch_SObject
{
    //float4x4 m_viewWorld; ///< ( ビュー x ワールド )マトリクス
    //float4x4 m_world; ///< ワールドマトリクス
    float4 UnityPatch_g_sObject_m_useWeightCount; ///< スキニングの使用ウェイト数
    float4 UnityPatch_g_sObject_m_localParam_0; ///< ローカルパラメータ(各レンダリングフェーズのローカル処理で利用)
    float4 UnityPatch_g_sObject_m_localParam_1;
    float4 UnityPatch_g_sObject_m_localParam_2;
    float4 UnityPatch_g_sObject_m_localParam_3;
};

// BONE 6
//cbuffer UnityPatch_SBone
//{
//    TMatrix4x3 UnityPatch_g_sBone_m_boneMatrices[32]; ///< ブレンドマトリクス(3x32)
//	//TMatrix4x3 UnityPatch_g_sBone_m_prevBoneMatrices[32]; ///< ブレンドマトリクス(3x32)
//};

// WORK 7
cbuffer UnityPatch_SWork
{
    float4x4 m_viewInverse; ///< viewInverse (シェーディングでよく使いまわせる）
    float4x4 UnityPatch_g_sWork_m_matrix[8]; ///< workMatrix[0]
};

// Make this the same size as the vertex version, but we will use it to upload a bunch of vector data
cbuffer UnityPatch_PSWork
{
    float4 UnityPatch_g_sWork_m_vectors[36];
};
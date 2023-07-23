


// #line 312 "..\Gr\Dg\shader\GBuffersBase.shdr.hlsl"
inline void NFetchAlbedoMap(float2 inTexcoord, out half4 outColor)
{
// #line 317 "..\Gr\Dg\shader\GBuffersBase.shdr.hlsl"

    outColor = TFetch2DH(g_tex_diffuse, g_sampler_diffuse, inTexcoord);
}



// #line 523 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NFetchSRMap(float2 inTexcoord, float2 inUnparallaxedTexcoord, half3 inNormal, half3 inViewDir, half inMaterialIndex, out half4 outColor)
{
// #line 532 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor = TFetch2DH(g_tex_srm, g_sampler_srm, inTexcoord);
}



// #line 545 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NFetchAnistropicSpecular(float2 inTexcoord, half3 inVsView, half4 inVsMainLight, half inAnistropic_Roughness, half inAnistropic_Diffusion, HTANGENT2VIEW inTan2View, half inSpecularMap, out half outColor)
{
// #line 556 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor = inSpecularMap;
}



// #line 612 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NAdjustSpecular(half inColor, half3 inNormal, half3 inView, out half outColor)
{
// #line 619 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor = inColor;
}



// #line 629 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NAdjustAlpha(half inAlpha, half3 inNormal, half3 inViewDir, float2 inUV, out half outAlpha)
{
// #line 637 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outAlpha = inAlpha;
}



// #line 679 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NAddReflection(half3 inColor, half3 inNormal, half3 inView, half inSpecularMap, float inMaterialId, half inRoughness, half inCalcedReflectionTh, out half3 outColor)
{
// #line 690 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

#ifdef USE_1003_OPTIMIZE
	float index = inMaterialId;

	half4 sampler1 = TFetch2DLodH(g_MaterialTexture, SamplerPoint, float4 (index, 0.25, 0, 0));
	half4 sampler0 = TFetch2DLodH(g_MaterialTexture, SamplerPoint, float4 (index, 0.75, 0, 0));
#else
	float index = inMaterialId * 255.0 / 256.0 + (0.5 / 256.0);
	//上下逆なので注意
	half4 sampler1 = (half4) tex2D(g_MaterialTexture, float2 (index, 0.25), 1.0f / 512.0H, 1.0f / 512.0H);
	half4 sampler0 = (half4) tex2D(g_MaterialTexture, float2 (index, 0.75), 1.0f / 512.0H, 1.0f / 512.0H);
#endif


	half r = inCalcedReflectionTh;

#ifdef CALC_REFLECTION_FULL
	r = (half) ((saturate(sampler0.y - inRoughness) / max(0.001, sampler0.y)));
#endif

	inView.xyz = (half3) - normalize(inView);
	half3 ref_vec;

	half3 cube = GetReflectionWithRoughness(ref_vec, g_ReflectionTexture, inView.xyz, inNormal.xyz, r, transpose(g_psScene.m_view));


	r = (half) lerp(r, 1.0H, sampler0.z);


#ifdef USE_REFLECTION_FRESNEL
	half3 halfDir = (half3) normalize(ref_vec.xyz - inView.xyz);
	half ref_fresnel = (half) saturate(GetFresnelSpecularFactor(halfDir, ref_vec, sampler0.x)) * r;
#else
	half ref_fresnel = r * sampler0.x;
#endif

	half3 ref_color = cube;


	half2 metalRate = r.xx * sampler0.zz * half2 (inSpecularMap.x, lerp(inSpecularMap.x, 1.0H, sampler0.z));



	inColor.xyz = (half3) GammaDecode(inColor.xyz);
	outColor = inColor * (1 - metalRate.yyy) + ref_color.xyz * metalRate.xxx * ref_fresnel * sampler1.xyz;

	outColor.xyz = GammaCorrection(outColor);
}



// #line 747 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NAdjustTan2View(HTANGENT2VIEW inTangentToView, half3 inAdjustNormal, half2 inUV, out HTANGENT2VIEW outTangentToView)
{
// #line 754 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outTangentToView = inTangentToView;
}



// #line 767 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NFetchNormalMapBlend(float2 inTexcoordNormal, float2 inTexcoordMask, float2 inTexcoordSubNormal, HTANGENT2VIEW inAxisTransform, half inFace, out half3 outNormal)
{
// #line 776 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	half3		normal;
	inAxisTransform[2].xyz *= inFace;
	normal.xyz = GetNormalFromTextureWithSampler(g_tex_normal, g_sampler_normal, inTexcoordNormal);

	normal.xyz = (half3)(
		normalize(inAxisTransform[0].xyz) * normal.xxx +
		normalize(inAxisTransform[1].xyz) * normal.yyy +
		normalize(inAxisTransform[2].xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);
}



// #line 832 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NAlphaTest2(float inAlpha, float inVertexAlpha, float2 inVPos, float2 inUV, out half outAlpha)
{
// #line 843 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

#ifndef MESH_SIZE
#define MESH_SIZE (8.0)
#endif

	half   threshold = (half)g_psSystem.m_param.w;

	half2 pixelSize = half2(1.0H / MESH_SIZE, 1.0H / MESH_SIZE);
	half2 uv = (half2)inVPos.xy * pixelSize;
	half4 mask = TFetch2DH(g_tex_mesh, SamplerPoint, uv);
	mask.w *= threshold;
#ifdef USE_1002_OPTIMIZE
	clip(half2(inAlpha, inVertexAlpha) - mask.wx);
#else
    clip(inAlpha - mask.w); // マスク抜き判定
    clip(inVertexAlpha - mask.x); // オブジェクトのメッシュアルファ判定
#endif

#ifdef USE_DECAL
	outAlpha = (half)inAlpha;
#else	// USE_DECAL
	outAlpha = 1.0H;
#endif	// USE_DECAL
}



// #line 870 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NPostAlphaTest(half inAlpha, half inAlphaOrg, float2 inVPos, float2 inUV, out half outAlpha)
{
// #line 878 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outAlpha = inAlpha;
}



// #line 889 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NEncodeGBufferNormal2(half3 inViewSpaceNormal, half inAlpha, out half4 outColor)
{
// #line 895 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor.xyzw = EncodeViewSpaceNormal(inViewSpaceNormal.xyz);
#ifdef USE_DECAL
	outColor.w = inAlpha;
#endif	// USE_DECAL
}



// #line 932 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NGetParallaxUV(float2 inTexcoord, float3 inParallaxVec, float3 inViewTS, out float2 outUV)
{
// #line 939 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outUV = inTexcoord;
}



// #line 952 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NGetEyeBlend(float2 inTexcoord, float3 inParallaxVec, float3 inViewTS, half3 inColor, out half3 outColor)
{
// #line 960 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor.xyz = inColor.xyz;
}



// #line 975 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NFetchInnternalReflectionBlend(half3 inColor, half3 inView, float2 inTexcoordNormal, HTANGENT2VIEW inAxisTransform, half inFace, out half3 outColor)
{
// #line 984 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


	outColor.xyz = inColor.xyz;

}



// #line 998 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NGetFaceSign(vface inFace, out half outFace)
{
// #line 1003 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

#ifdef USE_FACE
#ifdef F_TARGET_XBOX360
	//-1or1ではなく符号付の数値の可能性があるが、どうせあとでNormalizeするので気にしない
	outFace = (half) - getFaceSign(inFace);
#else
	//@todo ps3調査
	outFace = (half)getFaceSign(inFace);
#endif
#else
	outFace = (half)getFaceSign(inFace);
#endif
}



// #line 1018 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NNormalGBufferOut(half3 Albedo, half Translucency, half3 Normal, half Roughness, half SpecularRate, half CalcedReflectionTh, half MaterialID, half2 Velocity, half Alpha, out half4 outColor0, out half4 outColor1, out half4 outColor2)
{
// #line 1039 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


#ifndef USE_3RTGBUFFER_PROFILE
	// Color0 RGBA AlbedMap+モデル全体の透過
	// Color1 RGBA NormalMap
	// Color2 R SpecularMap（Gray)、Decal時は一切上書せず、下地になったモデルのオクルージョン焼きこみ情報をいかす（仮）
	// Color2 G マテリアルIndex、上書のみでブレンド不可
	// Color2 BA VelocityMap
	// Color3 R RoughnessMap
	// Color3 G 高速化用～(RoughnessTh - Rooughness / RoughnessTh)
	// Color3 B SSS兼Translucent
#ifdef USE_DECAL
	half otherAlpha = Alpha;
#else
	half otherAlpha = 1;
#endif

	outColor0 = half4(Albedo, Alpha);
	outColor1 = half4(Normal, otherAlpha);
	outColor2 = half4(SpecularRate, MaterialID, Velocity);
	outColor3 = half4(Roughness, CalcedReflectionTh, Translucency, otherAlpha);
#else
	outColor0 = half4(Albedo, Alpha);
#ifdef USE_DECAL
	outColor1 = half4(Normal, Alpha);
	outColor2 = half4(Roughness, SpecularRate, CalcedReflectionTh, Alpha);
#else
	outColor1 = half4(Normal, CalcedReflectionTh);
	outColor2 = half4(Roughness, SpecularRate, MaterialID, Translucency);
#endif
#endif

}



// #line 1077 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NCalcTranslucency(half2 inTranslucentUV, out half outTranslucency)
{
// #line 1083 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outTranslucency = 0;
}



// #line 1106 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
inline void NPostAlbedoMap(half4 inColor, float2 inTexcoord, float2 inTexcoordAdditional, out half4 outColor)
{
// #line 1113 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"

	outColor = inColor;
}



// #line 18 "..\Gr\Dg\shader\fox3ddf_blin_4mt.shdr.hlsl"
inline void NFetchMaterialIndex(float2 inTexcoord, out half outIndex)
{
// #line 23 "..\Gr\Dg\shader\fox3ddf_blin_4mt.shdr.hlsl"

	outIndex = (half)g_psMaterial.m_materials[0].x;
	half MaterialTh = TFetch2DH(g_tex_materialmap, SamplerPoint, inTexcoord.xy).x;

	outIndex = (half) ((1 - step(0.25H, MaterialTh)) * outIndex + step(0.25H, MaterialTh) * (half)g_psMaterial.m_materials[0].y);
	outIndex = (half) ((1 - step(0.5H, MaterialTh)) * outIndex + step(0.5H, MaterialTh) * (half)g_psMaterial.m_materials[0].z);
	outIndex = (half) ((1 - step(0.75H, MaterialTh)) * outIndex + step(0.75H, MaterialTh) * (half)g_psMaterial.m_materials[0].w);

#ifdef USE_1002_OPTIMIZE
#else	
	outIndex = outIndex / 255.0H;
#endif
}



// #line 53 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"
inline void NBlendLayer(float2 inTexcoord, float2 inTexcoordLayer, float2 inTexcordNorm, float2 inTexcordMask, half3 inColor, out half3 outColor)
{
// #line 62 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"

	outColor.xyz = MulLayerTextureWithSampler(g_tex_layer, g_sampler_layer, inTexcoordLayer, g_tex_layerMask, g_sampler_layerMask, inTexcordMask, inColor);
}



// #line 78 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"
inline void NBlendDirty(float2 inTexcoord, half3 inColor, half inRoughness, half3 inMask, out half3 outColor, out half outRoughness)
{
// #line 87 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"

	outColor = BlendDirtyColorWithSampler(outRoughness, g_tex_Dirty, g_sampler_Dirty, inTexcoord, inColor, inRoughness, inMask);
}



// #line 22 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"
inline void NAdjustIncidence(half3 inColor, half3 inNormal, half3 inView, half inSpecularMap, out half3 outColor)
{
// #line 30 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"

	outColor.xyz = (half3)lerp(inColor.xyz, (half3)g_psMaterial.m_materials[3].xyz, g_psMaterial.m_materials[3].w * inSpecularMap
		* pow(saturate(1.0H - dot(inNormal.xyz, normalize(inView).xyz)), (half)g_psMaterial.m_materials[2].x).x);

}







// #line 1122 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
void ps_main(

	in	float4	inVPos	: VPOS,
	in	float4	inColor : COLOR0,
	in	float2	inBaseUV : TEXCOORD0,
	in	float2	inSubUV : TEXCOORD1,
	in	float3	inViewDir : TEXCOORD4,
	in	HTANGENT2VIEW	inTangentToView : TEXCOORD5,
	out	half4	outColor0 : OUT_COLOR0,
	out	half4	outColor1 : OUT_COLOR1,
	out	half4	outColor2 : OUT_COLOR2
)
{
	#include "UnityPatch_PreEntryPoint.hlsl"
	
	inVPos = ToVPos4(inVPos);
	float2	NGetParallaxUV_getParallaxUV_inTexcoord;
	float3	NGetParallaxUV_getParallaxUV_inParallaxVec;
	float3	NGetParallaxUV_getParallaxUV_inViewTS;
	float2 NGetParallaxUV_getParallaxUV_outUV;
// #line 1246 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetParallaxUV_getParallaxUV_inTexcoord = inBaseUV.xy;
// #line 1250 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetParallaxUV_getParallaxUV_inParallaxVec = 0;
// #line 1252 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetParallaxUV_getParallaxUV_inViewTS = 0;
	NGetParallaxUV(NGetParallaxUV_getParallaxUV_inTexcoord, NGetParallaxUV_getParallaxUV_inParallaxVec, NGetParallaxUV_getParallaxUV_inViewTS, NGetParallaxUV_getParallaxUV_outUV);


	float2	NFetchMaterialIndex_fetchMaterialIndex_inTexcoord;
	half NFetchMaterialIndex_fetchMaterialIndex_outIndex;
// #line 1379 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchMaterialIndex_fetchMaterialIndex_inTexcoord = NGetParallaxUV_getParallaxUV_outUV.xy;
	NFetchMaterialIndex(NFetchMaterialIndex_fetchMaterialIndex_inTexcoord, NFetchMaterialIndex_fetchMaterialIndex_outIndex);


	vface	NGetFaceSign_getFaceSign_inFace;
	half NGetFaceSign_getFaceSign_outFace;
// #line 1341 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetFaceSign_getFaceSign_inFace = 1;
	NGetFaceSign(NGetFaceSign_getFaceSign_inFace, NGetFaceSign_getFaceSign_outFace);


	HTANGENT2VIEW	NAdjustTan2View_adjustTan2View_inTangentToView;
	half3	NAdjustTan2View_adjustTan2View_inAdjustNormal;
	half2	NAdjustTan2View_adjustTan2View_inUV;
	HTANGENT2VIEW NAdjustTan2View_adjustTan2View_outTangentToView;
// #line 1299 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustTan2View_adjustTan2View_inTangentToView = inTangentToView;
// #line 1304 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustTan2View_adjustTan2View_inAdjustNormal = inTangentToView[2];
// #line 1305 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustTan2View_adjustTan2View_inUV = (half2) inBaseUV.xy;
	NAdjustTan2View(NAdjustTan2View_adjustTan2View_inTangentToView, NAdjustTan2View_adjustTan2View_inAdjustNormal, NAdjustTan2View_adjustTan2View_inUV, NAdjustTan2View_adjustTan2View_outTangentToView);


	float2	NFetchNormalMapBlend_fetchNormalMap_inTexcoordNormal;
	float2	NFetchNormalMapBlend_fetchNormalMap_inTexcoordMask;
	float2	NFetchNormalMapBlend_fetchNormalMap_inTexcoordSubNormal;
	HTANGENT2VIEW	NFetchNormalMapBlend_fetchNormalMap_inAxisTransform;
	half	NFetchNormalMapBlend_fetchNormalMap_inFace;
	half3 NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1321 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchNormalMapBlend_fetchNormalMap_inTexcoordNormal.xy = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1315 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchNormalMapBlend_fetchNormalMap_inTexcoordMask.xy = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1326 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchNormalMapBlend_fetchNormalMap_inTexcoordSubNormal.xy = inSubUV.xy;
// #line 1337 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchNormalMapBlend_fetchNormalMap_inAxisTransform = NAdjustTan2View_adjustTan2View_outTangentToView;
// #line 1343 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchNormalMapBlend_fetchNormalMap_inFace = (half)NGetFaceSign_getFaceSign_outFace;
	NFetchNormalMapBlend(NFetchNormalMapBlend_fetchNormalMap_inTexcoordNormal, NFetchNormalMapBlend_fetchNormalMap_inTexcoordMask, NFetchNormalMapBlend_fetchNormalMap_inTexcoordSubNormal, NFetchNormalMapBlend_fetchNormalMap_inAxisTransform, NFetchNormalMapBlend_fetchNormalMap_inFace, NFetchNormalMapBlend_fetchNormalMap_outNormal);


	float2	NFetchSRMap_fetchSRMap_inTexcoord;
	float2	NFetchSRMap_fetchSRMap_inUnparallaxedTexcoord;
	half3	NFetchSRMap_fetchSRMap_inNormal;
	half3	NFetchSRMap_fetchSRMap_inViewDir;
	half	NFetchSRMap_fetchSRMap_inMaterialIndex;
	half4 NFetchSRMap_fetchSRMap_outColor;
// #line 1382 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchSRMap_fetchSRMap_inTexcoord = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1383 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchSRMap_fetchSRMap_inUnparallaxedTexcoord = inBaseUV.xy;
// #line 1384 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchSRMap_fetchSRMap_inNormal = NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1389 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchSRMap_fetchSRMap_inViewDir = (half3)inViewDir.xyz;
// #line 1386 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchSRMap_fetchSRMap_inMaterialIndex = NFetchMaterialIndex_fetchMaterialIndex_outIndex;
	NFetchSRMap(NFetchSRMap_fetchSRMap_inTexcoord, NFetchSRMap_fetchSRMap_inUnparallaxedTexcoord, NFetchSRMap_fetchSRMap_inNormal, NFetchSRMap_fetchSRMap_inViewDir, NFetchSRMap_fetchSRMap_inMaterialIndex, NFetchSRMap_fetchSRMap_outColor);


	float2	NFetchAnistropicSpecular_fetchAnistropicSpecular_inTexcoord;
	half3	NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsView;
	half4	NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsMainLight;
	half	NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Roughness;
	half	NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Diffusion;
	HTANGENT2VIEW	NFetchAnistropicSpecular_fetchAnistropicSpecular_inTan2View;
	half	NFetchAnistropicSpecular_fetchAnistropicSpecular_inSpecularMap;
	half NFetchAnistropicSpecular_fetchAnistropicSpecular_outColor;
// #line 1438 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inTexcoord = 0;
// #line 1439 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsView = 0;
// #line 1440 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsMainLight = 0;
// #line 1442 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Roughness = 0;
// #line 1441 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Diffusion = 0;
// #line 1443 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inTan2View = NAdjustTan2View_adjustTan2View_outTangentToView;
// #line 1444 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAnistropicSpecular_fetchAnistropicSpecular_inSpecularMap = NFetchSRMap_fetchSRMap_outColor.x;
	NFetchAnistropicSpecular(NFetchAnistropicSpecular_fetchAnistropicSpecular_inTexcoord, NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsView, NFetchAnistropicSpecular_fetchAnistropicSpecular_inVsMainLight, NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Roughness, NFetchAnistropicSpecular_fetchAnistropicSpecular_inAnistropic_Diffusion, NFetchAnistropicSpecular_fetchAnistropicSpecular_inTan2View, NFetchAnistropicSpecular_fetchAnistropicSpecular_inSpecularMap, NFetchAnistropicSpecular_fetchAnistropicSpecular_outColor);


	half	NAdjustSpecular_adjustSpecular_inColor;
	half3	NAdjustSpecular_adjustSpecular_inNormal;
	half3	NAdjustSpecular_adjustSpecular_inView;
	half NAdjustSpecular_adjustSpecular_outColor;
// #line 1447 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustSpecular_adjustSpecular_inColor = NFetchAnistropicSpecular_fetchAnistropicSpecular_outColor.x;
// #line 1448 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustSpecular_adjustSpecular_inNormal = NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1450 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustSpecular_adjustSpecular_inView = (half3)inViewDir.xyz;
	NAdjustSpecular(NAdjustSpecular_adjustSpecular_inColor, NAdjustSpecular_adjustSpecular_inNormal, NAdjustSpecular_adjustSpecular_inView, NAdjustSpecular_adjustSpecular_outColor);


	float2	NFetchAlbedoMap_fetchAlbedoMap_inTexcoord;
	half4 NFetchAlbedoMap_fetchAlbedoMap_outColor;
// #line 1256 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchAlbedoMap_fetchAlbedoMap_inTexcoord.xy = NGetParallaxUV_getParallaxUV_outUV.xy;
	NFetchAlbedoMap(NFetchAlbedoMap_fetchAlbedoMap_inTexcoord, NFetchAlbedoMap_fetchAlbedoMap_outColor);


	float2	NGetEyeBlend_getEyeBlend_inTexcoord;
	float3	NGetEyeBlend_getEyeBlend_inParallaxVec;
	float3	NGetEyeBlend_getEyeBlend_inViewTS;
	half3	NGetEyeBlend_getEyeBlend_inColor;
	half3 NGetEyeBlend_getEyeBlend_outColor;
// #line 1272 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetEyeBlend_getEyeBlend_inTexcoord = inBaseUV.xy;
// #line 1277 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetEyeBlend_getEyeBlend_inParallaxVec = 0;
// #line 1278 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetEyeBlend_getEyeBlend_inViewTS = 0;
// #line 1271 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NGetEyeBlend_getEyeBlend_inColor = NFetchAlbedoMap_fetchAlbedoMap_outColor.xyz;
	NGetEyeBlend(NGetEyeBlend_getEyeBlend_inTexcoord, NGetEyeBlend_getEyeBlend_inParallaxVec, NGetEyeBlend_getEyeBlend_inViewTS, NGetEyeBlend_getEyeBlend_inColor, NGetEyeBlend_getEyeBlend_outColor);


	half3	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inColor;
	half3	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inView;
	float2	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inTexcoordNormal;
	HTANGENT2VIEW	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inAxisTransform;
	half	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inFace;
	half3 NFetchInnternalReflectionBlend_getInnternalReflectionBlend_outColor;
// #line 1357 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inColor = NGetEyeBlend_getEyeBlend_outColor.xyz;
// #line 1362 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inView = (half3) inViewDir;
// #line 1358 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inTexcoordNormal = inBaseUV.xy;
// #line 1359 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inAxisTransform = NAdjustTan2View_adjustTan2View_outTangentToView;
// #line 1360 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inFace = (half)NGetFaceSign_getFaceSign_outFace;
	NFetchInnternalReflectionBlend(NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inColor, NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inView, NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inTexcoordNormal, NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inAxisTransform, NFetchInnternalReflectionBlend_getInnternalReflectionBlend_inFace, NFetchInnternalReflectionBlend_getInnternalReflectionBlend_outColor);


	float2	NBlendLayer_blendLayer_inTexcoord;
	float2	NBlendLayer_blendLayer_inTexcoordLayer;
	float2	NBlendLayer_blendLayer_inTexcordNorm;
	float2	NBlendLayer_blendLayer_inTexcordMask;
	half3	NBlendLayer_blendLayer_inColor;
	half3 NBlendLayer_blendLayer_outColor;
// #line 1324 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendLayer_blendLayer_inTexcoord.xy = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1327 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendLayer_blendLayer_inTexcoordLayer.xy = inSubUV.xy;
// #line 1322 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendLayer_blendLayer_inTexcordNorm.xy = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1375 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendLayer_blendLayer_inTexcordMask = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1377 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendLayer_blendLayer_inColor = NFetchInnternalReflectionBlend_getInnternalReflectionBlend_outColor.xyz;
	NBlendLayer(NBlendLayer_blendLayer_inTexcoord, NBlendLayer_blendLayer_inTexcoordLayer, NBlendLayer_blendLayer_inTexcordNorm, NBlendLayer_blendLayer_inTexcordMask, NBlendLayer_blendLayer_inColor, NBlendLayer_blendLayer_outColor);


	half3	NAdjustIncidence_adjustIncidence_inColor;
	half3	NAdjustIncidence_adjustIncidence_inNormal;
	half3	NAdjustIncidence_adjustIncidence_inView;
	half	NAdjustIncidence_adjustIncidence_inSpecularMap;
	half3 NAdjustIncidence_adjustIncidence_outColor;
// #line 1464 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustIncidence_adjustIncidence_inColor = NBlendLayer_blendLayer_outColor;
// #line 1466 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustIncidence_adjustIncidence_inNormal = NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1468 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustIncidence_adjustIncidence_inView = (half3)inViewDir.xyz;
// #line 1473 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustIncidence_adjustIncidence_inSpecularMap = NFetchAnistropicSpecular_fetchAnistropicSpecular_outColor.x;
	NAdjustIncidence(NAdjustIncidence_adjustIncidence_inColor, NAdjustIncidence_adjustIncidence_inNormal, NAdjustIncidence_adjustIncidence_inView, NAdjustIncidence_adjustIncidence_inSpecularMap, NAdjustIncidence_adjustIncidence_outColor);


	half3	NAddReflection_addReflection_inColor;
	half3	NAddReflection_addReflection_inNormal;
	half3	NAddReflection_addReflection_inView;
	half	NAddReflection_addReflection_inSpecularMap;
	float	NAddReflection_addReflection_inMaterialId;
	half	NAddReflection_addReflection_inRoughness;
	half	NAddReflection_addReflection_inCalcedReflectionTh;
	half3 NAddReflection_addReflection_outColor;
// #line 1475 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inColor = NAdjustIncidence_adjustIncidence_outColor;
// #line 1476 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inNormal = NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1478 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inView = (half3)inViewDir.xyz;
// #line 1482 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inSpecularMap = NAdjustSpecular_adjustSpecular_outColor.x;
// #line 1483 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inMaterialId = NFetchMaterialIndex_fetchMaterialIndex_outIndex;
// #line 1484 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inRoughness = NFetchSRMap_fetchSRMap_outColor.y;
// #line 1485 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAddReflection_addReflection_inCalcedReflectionTh = NFetchSRMap_fetchSRMap_outColor.z;
	NAddReflection(NAddReflection_addReflection_inColor, NAddReflection_addReflection_inNormal, NAddReflection_addReflection_inView, NAddReflection_addReflection_inSpecularMap, NAddReflection_addReflection_inMaterialId, NAddReflection_addReflection_inRoughness, NAddReflection_addReflection_inCalcedReflectionTh, NAddReflection_addReflection_outColor);


	float2	NBlendDirty_fetchDirty_inTexcoord;
	half3	NBlendDirty_fetchDirty_inColor;
	half	NBlendDirty_fetchDirty_inRoughness;
	half3	NBlendDirty_fetchDirty_inMask;
	half3 NBlendDirty_fetchDirty_outColor;
	half NBlendDirty_fetchDirty_outRoughness;
// #line 1336 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendDirty_fetchDirty_inTexcoord = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1492 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendDirty_fetchDirty_inColor = NAddReflection_addReflection_outColor.xyz;
// #line 1496 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendDirty_fetchDirty_inRoughness = NFetchSRMap_fetchSRMap_outColor.y;
// #line 1498 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NBlendDirty_fetchDirty_inMask = (half3)inColor.xyz;
	NBlendDirty(NBlendDirty_fetchDirty_inTexcoord, NBlendDirty_fetchDirty_inColor, NBlendDirty_fetchDirty_inRoughness, NBlendDirty_fetchDirty_inMask, NBlendDirty_fetchDirty_outColor, NBlendDirty_fetchDirty_outRoughness);


	half2	NCalcTranslucency_getTralslucency_inTranslucentUV;
	half NCalcTranslucency_getTralslucency_outTranslucency;
// #line 1540 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NCalcTranslucency_getTralslucency_inTranslucentUV = (half2)NGetParallaxUV_getParallaxUV_outUV.xy;
	NCalcTranslucency(NCalcTranslucency_getTralslucency_inTranslucentUV, NCalcTranslucency_getTralslucency_outTranslucency);


	half	NAdjustAlpha_adjustAlpha_inAlpha;
	half3	NAdjustAlpha_adjustAlpha_inNormal;
	half3	NAdjustAlpha_adjustAlpha_inViewDir;
	float2	NAdjustAlpha_adjustAlpha_inUV;
	half NAdjustAlpha_adjustAlpha_outAlpha;
// #line 1282 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustAlpha_adjustAlpha_inAlpha = NFetchAlbedoMap_fetchAlbedoMap_outColor.a;
// #line 1283 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustAlpha_adjustAlpha_inNormal = inTangentToView[2].xyz;
// #line 1286 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustAlpha_adjustAlpha_inViewDir = (half3) inViewDir;
// #line 1284 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAdjustAlpha_adjustAlpha_inUV = inBaseUV.xy;
	NAdjustAlpha(NAdjustAlpha_adjustAlpha_inAlpha, NAdjustAlpha_adjustAlpha_inNormal, NAdjustAlpha_adjustAlpha_inViewDir, NAdjustAlpha_adjustAlpha_inUV, NAdjustAlpha_adjustAlpha_outAlpha);


	half4	NPostAlbedoMap_postAlbedoMap_inColor;
	float2	NPostAlbedoMap_postAlbedoMap_inTexcoord;
	float2	NPostAlbedoMap_postAlbedoMap_inTexcoordAdditional;
	half4 NPostAlbedoMap_postAlbedoMap_outColor;
// #line 1508 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlbedoMap_postAlbedoMap_inColor.xyz = NBlendDirty_fetchDirty_outColor;
// #line 1518 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlbedoMap_postAlbedoMap_inColor.w = NAdjustAlpha_adjustAlpha_outAlpha;
// #line 1519 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlbedoMap_postAlbedoMap_inTexcoord = NGetParallaxUV_getParallaxUV_outUV.xy;
// #line 1527 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlbedoMap_postAlbedoMap_inTexcoordAdditional.xy = inBaseUV.xy;
	NPostAlbedoMap(NPostAlbedoMap_postAlbedoMap_inColor, NPostAlbedoMap_postAlbedoMap_inTexcoord, NPostAlbedoMap_postAlbedoMap_inTexcoordAdditional, NPostAlbedoMap_postAlbedoMap_outColor);


	float	NAlphaTest2_alphaTest_inAlpha;
	float	NAlphaTest2_alphaTest_inVertexAlpha;
	float2	NAlphaTest2_alphaTest_inVPos;
	float2	NAlphaTest2_alphaTest_inUV;
	half NAlphaTest2_alphaTest_outAlpha;
// #line 1291 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAlphaTest2_alphaTest_inAlpha = NAdjustAlpha_adjustAlpha_outAlpha;
// #line 1293 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAlphaTest2_alphaTest_inVertexAlpha = inColor.w;
// #line 1294 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAlphaTest2_alphaTest_inVPos = inVPos.xy;
// #line 1292 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NAlphaTest2_alphaTest_inUV = inBaseUV.xy;
	NAlphaTest2(NAlphaTest2_alphaTest_inAlpha, NAlphaTest2_alphaTest_inVertexAlpha, NAlphaTest2_alphaTest_inVPos, NAlphaTest2_alphaTest_inUV, NAlphaTest2_alphaTest_outAlpha);


	half	NPostAlphaTest_postAlphaTest_inAlpha;
	half	NPostAlphaTest_postAlphaTest_inAlphaOrg;
	float2	NPostAlphaTest_postAlphaTest_inVPos;
	float2	NPostAlphaTest_postAlphaTest_inUV;
	half NPostAlphaTest_postAlphaTest_outAlpha;
// #line 1531 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlphaTest_postAlphaTest_inAlpha = NAlphaTest2_alphaTest_outAlpha;
// #line 1532 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlphaTest_postAlphaTest_inAlphaOrg = NPostAlbedoMap_postAlbedoMap_outColor.w;
// #line 1534 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlphaTest_postAlphaTest_inVPos = inVPos.xy;
// #line 1533 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NPostAlphaTest_postAlphaTest_inUV = inBaseUV.xy;
	NPostAlphaTest(NPostAlphaTest_postAlphaTest_inAlpha, NPostAlphaTest_postAlphaTest_inAlphaOrg, NPostAlphaTest_postAlphaTest_inVPos, NPostAlphaTest_postAlphaTest_inUV, NPostAlphaTest_postAlphaTest_outAlpha);


	half3	NEncodeGBufferNormal2_encodeNormal_inViewSpaceNormal;
	half	NEncodeGBufferNormal2_encodeNormal_inAlpha;
	half4 NEncodeGBufferNormal2_encodeNormal_outColor;
// #line 1344 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NEncodeGBufferNormal2_encodeNormal_inViewSpaceNormal.xyz = NFetchNormalMapBlend_fetchNormalMap_outNormal;
// #line 1345 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NEncodeGBufferNormal2_encodeNormal_inAlpha = NAdjustAlpha_adjustAlpha_outAlpha;
	NEncodeGBufferNormal2(NEncodeGBufferNormal2_encodeNormal_inViewSpaceNormal, NEncodeGBufferNormal2_encodeNormal_inAlpha, NEncodeGBufferNormal2_encodeNormal_outColor);


	half3	NNormalGBufferOut_ourGBuffer_Albedo;
	half	NNormalGBufferOut_ourGBuffer_Translucency;
	half3	NNormalGBufferOut_ourGBuffer_Normal;
	half	NNormalGBufferOut_ourGBuffer_Roughness;
	half	NNormalGBufferOut_ourGBuffer_SpecularRate;
	half	NNormalGBufferOut_ourGBuffer_CalcedReflectionTh;
	half	NNormalGBufferOut_ourGBuffer_MaterialID;
	half2	NNormalGBufferOut_ourGBuffer_Velocity;
	half	NNormalGBufferOut_ourGBuffer_Alpha;
	half4 NNormalGBufferOut_ourGBuffer_outColor0;
	half4 NNormalGBufferOut_ourGBuffer_outColor1;
	half4 NNormalGBufferOut_ourGBuffer_outColor2;
// #line 1529 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Albedo.xyz = NPostAlbedoMap_postAlbedoMap_outColor.xyz;
// #line 1542 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Translucency = NCalcTranslucency_getTralslucency_outTranslucency;
// #line 1346 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Normal.xyz = NEncodeGBufferNormal2_encodeNormal_outColor.xyz;
// #line 1544 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Roughness = NBlendDirty_fetchDirty_outRoughness;
// #line 1456 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_SpecularRate = NAdjustSpecular_adjustSpecular_outColor.x;
// #line 1546 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_CalcedReflectionTh = NFetchSRMap_fetchSRMap_outColor.z;
// #line 1458 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_MaterialID = NFetchMaterialIndex_fetchMaterialIndex_outIndex;
// #line 1423 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Velocity = 0.5h;
// #line 1537 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	NNormalGBufferOut_ourGBuffer_Alpha = (half)NPostAlphaTest_postAlphaTest_outAlpha;
	NNormalGBufferOut(NNormalGBufferOut_ourGBuffer_Albedo, NNormalGBufferOut_ourGBuffer_Translucency, NNormalGBufferOut_ourGBuffer_Normal, NNormalGBufferOut_ourGBuffer_Roughness, NNormalGBufferOut_ourGBuffer_SpecularRate, NNormalGBufferOut_ourGBuffer_CalcedReflectionTh, NNormalGBufferOut_ourGBuffer_MaterialID, NNormalGBufferOut_ourGBuffer_Velocity, NNormalGBufferOut_ourGBuffer_Alpha, NNormalGBufferOut_ourGBuffer_outColor0, NNormalGBufferOut_ourGBuffer_outColor1, NNormalGBufferOut_ourGBuffer_outColor2);


// #line 1549 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	outColor0 = NNormalGBufferOut_ourGBuffer_outColor0;

// #line 1550 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	outColor1 = NNormalGBufferOut_ourGBuffer_outColor1;

// #line 1551 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"
	outColor2 = NNormalGBufferOut_ourGBuffer_outColor2;



	#include "UnityPatch_PostEntryPoint.hlsl"
}


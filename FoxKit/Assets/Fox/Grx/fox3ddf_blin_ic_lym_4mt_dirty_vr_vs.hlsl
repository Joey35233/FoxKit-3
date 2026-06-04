


// #line 49 "..\Gr\Dg\shader\GBuffersBase.shdr"
inline void NTransformInput(float4 inPosition, float3 inNormal, float4 inTangent, float4 inBlendWeights, uint4 inBlendIndices, float2 inWeight, out float4 outWorldPosition, out float4 outScreenPos, out float4 outPrevScreenPos, out float4 outProjectionPosition, out float3 outNormal, out float3 outTangent, out float3 outBinormal, out TANGENT2WORLD outTanToWorld, out float3 outViewPosition, out float3 outViewDir, out float3 outNormalOnView, out float3 outTangentOnView, out float3 outBinormalOnView, out TANGENT2VIEW outTangentToView)
{
// #line 72 "..\Gr\Dg\shader\GBuffersBase.shdr"

#define WORLD_MATRIX_OLD       (g_vsScene.m_shadowProjection)
#define PROJVIEW_MATRIX_OLD    (g_vsScene.m_shadowProjection2)      


	float4		pos = inPosition;
	float4      prevPos = pos;

	CORRECT_TANGNET_VALUE(inTangent);


	if (g_vsObject.m_useWeightCount.x != 0.0) {
#ifndef DISABLE_SHADER_SKINNING
		CalculateSkinning(g_vsBone,
			pos, inBlendWeights, (int4)inBlendIndices,
			inNormal.xyz, inTangent.xyz);
#ifdef ENABLE_PREVBONE_REGISTERS
		CalculateSkinningPos(g_vsPrevBone, prevPos, inBlendWeights, inBlendIndices);
#endif
#else
		prevPos.xyz = pos.xyz + inBlendWeights.xyz;
		prevPos.w = 1.0;
#endif
	}


	outWorldPosition = TransformPosition(g_vsScene, g_vsObject, pos, outProjectionPosition, outViewPosition);
	prevPos = ApplyMatrixT(WORLD_MATRIX_OLD, prevPos);
	outPrevScreenPos = ApplyMatrixT(PROJVIEW_MATRIX_OLD, prevPos);
	outScreenPos = outProjectionPosition;
	outViewDir = normalize(outViewPosition);


	outNormal.xyz = normalize(ApplyMatrixT(g_vsObject.m_world, inNormal.xyz));
	outTangent.xyz = normalize(ApplyMatrixT(g_vsObject.m_world, inTangent.xyz));
	outBinormal.xyz = normalize(cross(outNormal, outTangent)) * inTangent.w;
	outTanToWorld[0] = outTangent;
	outTanToWorld[1] = outBinormal;
	outTanToWorld[2] = outNormal;


	outNormalOnView.xyz = normalize(ApplyMatrixT(g_vsObject.m_viewWorld, inNormal.xyz));
	outTangentOnView.xyz = normalize(ApplyMatrixT(g_vsObject.m_viewWorld, inTangent.xyz));
	outBinormalOnView.xyz = normalize(cross(outNormalOnView, outTangentOnView)) * inTangent.w;
	outTangentToView[0] = outTangentOnView;
	outTangentToView[1] = outBinormalOnView;
	outTangentToView[2] = outNormalOnView;
}



// #line 166 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
inline void NAdjustUVBase(float2 inUV, out float2 outUV)
{
// #line 171 "..\Gr\Dg\shader\fox3ddf_blin.shdr"

	outUV = inUV;
}



// #line 29 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr"
inline void NAdjustUVSub(float2 inUV0, float2 inUV1, out float2 outUV)
{
// #line 35 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr"

	outUV = (inUV1 + g_vsMaterial.m_materials[1].zw) * g_vsMaterial.m_materials[1].xy;
}







// #line 245 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
void vs_main(

	in	float4	inPosition	: POSITION,
	in	float4	inNormal : NORMAL,
	in	float4	inColor : COLOR,
	in	float4	inTangent : TANGENT,
	in	uint4	inBlendIndices : BLENDINDICES,
	in	float4	inBlendWeights : BLENDWEIGHT,
	in	float2	inTexcoord0 : TEXCOORD0,
	in	float2	inTexcoord1 : TEXCOORD1,
	in	float2	inTexcoord2 : TEXCOORD2,
	in	float2	inTexcoord3 : TEXCOORD3,
	out	float4	outPosition : OUT_POSITION,
	out	float4	outColor : COLOR0,
	out	float2	outBaseUV : TEXCOORD0,
	out	float2	outSubUV : TEXCOORD1,
	out	float3	outViewDir : TEXCOORD4,
	out	TANGENT2VIEW	outTangentToView : TEXCOORD5
)
{
	#include "../UnityPatch/PreEntryPoint.hlsl"
	
	inColor = ResolveEndian(inColor);
	float4	NTransformInput_transform_inPosition;
	float3	NTransformInput_transform_inNormal;
	float4	NTransformInput_transform_inTangent;
	float4	NTransformInput_transform_inBlendWeights;
	uint4	NTransformInput_transform_inBlendIndices;
	float2	NTransformInput_transform_inWeight;
	float4 NTransformInput_transform_outWorldPosition;
	float4 NTransformInput_transform_outScreenPos;
	float4 NTransformInput_transform_outPrevScreenPos;
	float4 NTransformInput_transform_outProjectionPosition;
	float3 NTransformInput_transform_outNormal;
	float3 NTransformInput_transform_outTangent;
	float3 NTransformInput_transform_outBinormal;
	TANGENT2WORLD NTransformInput_transform_outTanToWorld;
	float3 NTransformInput_transform_outViewPosition;
	float3 NTransformInput_transform_outViewDir;
	float3 NTransformInput_transform_outNormalOnView;
	float3 NTransformInput_transform_outTangentOnView;
	float3 NTransformInput_transform_outBinormalOnView;
	TANGENT2VIEW NTransformInput_transform_outTangentToView;
// #line 375 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inPosition = inPosition;
// #line 376 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inNormal.xyz = inNormal.xyz;
// #line 377 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inTangent.xyzw = inTangent.xyzw;
// #line 379 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inBlendWeights = inBlendWeights;
// #line 378 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inBlendIndices = inBlendIndices;
// #line 381 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NTransformInput_transform_inWeight = inColor.xx;
	NTransformInput(NTransformInput_transform_inPosition, NTransformInput_transform_inNormal, NTransformInput_transform_inTangent, NTransformInput_transform_inBlendWeights, NTransformInput_transform_inBlendIndices, NTransformInput_transform_inWeight, NTransformInput_transform_outWorldPosition, NTransformInput_transform_outScreenPos, NTransformInput_transform_outPrevScreenPos, NTransformInput_transform_outProjectionPosition, NTransformInput_transform_outNormal, NTransformInput_transform_outTangent, NTransformInput_transform_outBinormal, NTransformInput_transform_outTanToWorld, NTransformInput_transform_outViewPosition, NTransformInput_transform_outViewDir, NTransformInput_transform_outNormalOnView, NTransformInput_transform_outTangentOnView, NTransformInput_transform_outBinormalOnView, NTransformInput_transform_outTangentToView);


	float2	NAdjustUVSub_adjustUVSub_inUV0;
	float2	NAdjustUVSub_adjustUVSub_inUV1;
	float2 NAdjustUVSub_adjustUVSub_outUV;
// #line 431 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NAdjustUVSub_adjustUVSub_inUV0 = inTexcoord0.xy;
// #line 432 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NAdjustUVSub_adjustUVSub_inUV1 = inTexcoord1.xy;
	NAdjustUVSub(NAdjustUVSub_adjustUVSub_inUV0, NAdjustUVSub_adjustUVSub_inUV1, NAdjustUVSub_adjustUVSub_outUV);


	float2	NAdjustUVBase_adjustUVBase_inUV;
	float2 NAdjustUVBase_adjustUVBase_outUV;
// #line 428 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	NAdjustUVBase_adjustUVBase_inUV = inTexcoord0.xy;
	NAdjustUVBase(NAdjustUVBase_adjustUVBase_inUV, NAdjustUVBase_adjustUVBase_outUV);


// #line 408 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outPosition = NTransformInput_transform_outProjectionPosition;

// #line 429 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outBaseUV.xy = NAdjustUVBase_adjustUVBase_outUV;

// #line 433 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outSubUV.xy = NAdjustUVSub_adjustUVSub_outUV;

// #line 473 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outViewDir = -NTransformInput_transform_outViewDir;

// #line 481 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outTangentToView = NTransformInput_transform_outTangentToView;

// #line 459 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outColor.xyz = inColor.xyz;

// #line 467 "..\Gr\Dg\shader\fox3ddf_blin.shdr"
	outColor.w = g_vsObject.m_useWeightCount.w;



	#include "../UnityPatch/PostEntryPoint.hlsl"
}


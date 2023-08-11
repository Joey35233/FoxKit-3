
#line 6 "shader\DR_VolFog_TppTonemap.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 1 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"




#line 1 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 2 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"













#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"



#define _DG_SHADER_DEF_H_


#line 60 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"




#line 230 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"





#define REGISTER_C(_var)	register(c##_var)
#define REGISTER_B(_var)	register(b##_var)
#define REGISTER_I(_var)	register(i##_var)
#define REGISTER_T(_var)	register(t##_var)
#define REGISTER_S(_var)	register(s##_var)


typedef float4x4			Matrix4x4;
typedef float4x4			TMatrix4x4;
typedef float4x3			TMatrix4x3;


typedef float3			TANGENT2VIEW[3];
typedef half3			HTANGENT2VIEW[3];
typedef float3			TANGENT2WORLD[3];
typedef half3			HTANGENT2WORLD[3];



#line 320 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define TEXUNIT0		register(t0)
#define TEXUNIT1		register(t1)
#define TEXUNIT2		register(t2)
#define TEXUNIT3		register(t3)
#define TEXUNIT4		register(t4)
#define TEXUNIT5		register(t5)
#define TEXUNIT6		register(t6)
#define TEXUNIT7		register(t7)
#define TEXUNIT8		register(t8)
#define TEXUNIT9		register(t9)
#define TEXUNIT10		register(t10)
#define TEXUNIT11		register(t11)
#define TEXUNIT12		register(t12)
#define TEXUNIT13		register(t13)
#define TEXUNIT14		register(t14)
#define TEXUNIT15		register(t15)
#define	SAMPLERUNIT0	register(s0)
#define	SAMPLERUNIT1	register(s1)
#define	SAMPLERUNIT2	register(s2)
#define	SAMPLERUNIT3	register(s3)
#define	SAMPLERUNIT4	register(s4)
#define	SAMPLERUNIT5	register(s5)
#define	SAMPLERUNIT6	register(s6)
#define	SAMPLERUNIT7	register(s7)
#define	SAMPLERUNIT8	register(s8)
#define	SAMPLERUNIT9	register(s9)
#define	SAMPLERUNIT10	register(s10)
#define	SAMPLERUNIT11	register(s11)
#define	SAMPLERUNIT12	register(s12)
#define	SAMPLERUNIT13	register(s13)
#define	SAMPLERUNIT14	register(s14)
#define	SAMPLERUNIT15	register(s15)

#define SAMPLERUNIT_SYSTEM SAMPLERUNIT8


#line 372 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#define OUT_COLOR		SV_Target0
#define OUT_COLOR0		SV_Target0
#define OUT_COLOR1		SV_Target1
#define OUT_COLOR2		SV_Target2
#define OUT_COLOR3		SV_Target3
#define OUT_DEPTH		SV_Depth
#define OUT_POSITION	SV_Position
#define VPOS			SV_Position
#define VFACE			SV_IsFrontFace
#define OUT_CLIPDISTANCE SV_ClipDistance
#define VINDEXID		SV_VertexID
#define VINSTANCEID		SV_InstanceID
#define VPRIMITIVEID	SV_PrimitiveID

typedef bool			vface;

bool isFrontFace(vface face)
{
	return face;
}
float getFaceSign(vface face)
{
	return face ? 1 : -1;
}




inline float4 ApplyMatrix(Matrix4x4 mat, float4 vec)
{
	return mul(mat, vec);
}
inline float4 ApplyMatrixT(TMatrix4x4 mat, float4 vec)
{
	return mul(vec, mat);
}
inline float3 ApplyMatrixT(TMatrix4x4 mat, float3 vec)
{
	return mul(float4(vec, 0), mat).xyz;
}
inline float3 ApplyMatrixT(TMatrix4x3 mat, float4 vec)
{
	return mul(vec, mat);
}
inline float3 ApplyMatrixT(TMatrix4x3 mat, float3 vec)
{
	return mul(float4(vec, 0), mat);
}
inline float3 ApplyMatrixT(TANGENT2WORLD mat, float3 vec)
{
	return mul(vec, float3x3(mat[0], mat[1], mat[2]));
}
inline void SetTranslate(inout Matrix4x4 mat, float4 translate)
{
	mat[0].w = translate.x;
	mat[1].w = translate.y;
	mat[2].w = translate.z;
	mat[3].w = translate.w;
}
inline void SetTranslateT(inout TMatrix4x4 mat, float4 translate)
{
	mat[3].xyzw = translate.xyzw;
}
inline void SetTranslateT(inout TMatrix4x3 mat, float3 translate)
{
	mat[3].xyz = translate.xyz;
}
inline float4 GetTranslate(Matrix4x4 mat)
{
	return float4(mat[0].w, mat[1].w, mat[2].w, mat[3].w);
}
inline float4 GetTranslateT(TMatrix4x4 mat)
{
	return mat[3].xyzw;
}
inline float3 GetTranslateT(TMatrix4x3 mat)
{
	return mat[3].xyz;
}
inline TMatrix4x4 GetTranspose(TMatrix4x4 mat)
{
	return transpose(mat);
}
inline float4 GetRow(TMatrix4x4 mat, half _row)
{
	return float4(mat[0][(int)_row], mat[1][(int)_row], mat[2][(int)_row], mat[3][(int)_row]);
}
inline float4 GetRowT(TMatrix4x4 mat, half _row)
{
	return mat[(int)_row].xyzw;
}
inline float3 GetRow(TMatrix4x3 mat, half _row)
{
	return float3(mat[0][(int)_row], mat[1][(int)_row], mat[2][(int)_row]);
}
inline float3 GetRowT(TMatrix4x3 mat, half _row)
{
	return mat[(int)_row].xyz;
}
inline float GetElement(TMatrix4x4 mat, half _row, half _column)
{
	return mat[(int)_row][(int)_column];
}

inline float3 GetViewspaceWorldXDir(TMatrix4x4 invViewMat) {
	return float3 (invViewMat[0][0], invViewMat[0][1], invViewMat[0][2]);
}
inline float3 GetViewspaceWorldYDir(TMatrix4x4 invViewMat) {
	return float3 (invViewMat[1][0], invViewMat[1][1], invViewMat[1][2]);
}
inline float3 GetViewspaceWorldZDir(TMatrix4x4 invViewMat) {
	return float3 (invViewMat[2][0], invViewMat[2][1], invViewMat[2][2]);
}


#line 492 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 494 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 498 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 6 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefineForDx11Gen.h"


#define _DG_SHADER_DEF_FOR_DIRECTX11_GEN_H_




#define SHADER_CONSTANTBUFFER_SYSTEM		0
#define SHADER_CONSTANTBUFFER_RENDERBUFFER	1
#define SHADER_CONSTANTBUFFER_SCENE			2
#define SHADER_CONSTANTBUFFER_LIGHTS		3
#define SHADER_CONSTANTBUFFER_MATERIAL		4
#define SHADER_CONSTANTBUFFER_OBJECT		5
#define SHADER_CONSTANTBUFFER_BONES			6
#define SHADER_CONSTANTBUFFER_WORK			7


#define SHADER_CONSTANTBUFFER_LIGHT			SHADER_CONSTANTBUFFER_LIGHTS



struct SSystem
{
	float4		m_param;
	float4		m_renderInfo;
	float4		m_renderBuffer;
	float4		m_dominantLightDir;
};
typedef SSystem VSSystem;
typedef SSystem PSSystem;

#define SHADER_CONST_SYSTEM_PARAM				0
#define SHADER_CONST_SYSTEM_RENDERINFO			1
#define SHADER_CONST_SYSTEM_RENDERBUFFER		2
#define SHADER_CONST_SYSTEM_DOMINANT_LIGHT_DIR	3
#define SHADER_CONSTANTBUFFER_SYSTEM_SIZE		4




struct SScene
{
	TMatrix4x4		m_projectionView;
	TMatrix4x4		m_projection;
	TMatrix4x4		m_view;
	TMatrix4x4		m_shadowProjection;
	TMatrix4x4		m_shadowProjection2;
	float4			m_eyepos;
	float4			m_projectionParam;
	float4			m_viewportSize;
	float4			m_exposure;
	float4			m_fogParam[3];
	float4			m_fogColor;
	float4			m_cameraCenterOffset;
	float4			m_shadowMapResolutions;
};
typedef SScene VSScene;
typedef SScene PSScene;

#define SHADER_CONST_PROJECTIONVIEW				0
#define SHADER_CONST_PROJECTION					4
#define SHADER_CONST_VIEW						8
#define SHADER_CONST_SHADOWPROJECTION			12
#define SHADER_CONST_SHADOWPROJECTION2			16
#define SHADER_CONST_EYEPOS						20
#define SHADER_CONST_PROJECTIONPARAM			21
#define SHADER_CONST_VIEWPORTSIZE				22
#define SHADER_CONST_EXPOSURE					23
#define SHADER_CONST_FOGPARAM0					24
#define SHADER_CONST_FOGPARAM1					25
#define SHADER_CONST_FOGPARAM2					26
#define SHADER_CONST_FOGCOLOR					27
#define SHADER_CONST_CAMERACENTEROFFSET			28
#define SHADER_CONST_SHADOWMAP_RESOLUTIONS		29
#define SHADER_CONSTANTBUFFER_SCENE_SIZE		30




struct SRenderBuffer
{
	float4		m_size;
};
typedef SRenderBuffer PSRenderBuffer;

#define SHADER_CONST_RENDERBUFFER_SIZE			0
#define SHADER_CONSTANTBUFFER_RENDERBUFFER_SIZE	1




#define SHADER_CONST_LIGHTPARAM0				0
#define SHADER_CONST_LIGHTPARAM1				1
#define SHADER_CONST_LIGHTPARAM2				2
#define	SHADER_CONST_LIGHTPARAM3				3
#define	SHADER_CONST_LIGHTPARAM4				4
#define	SHADER_CONST_LIGHTPARAM5				5
#define	SHADER_CONST_LIGHTPARAM6				6
#define	SHADER_CONST_LIGHTPARAM7				7
#define	SHADER_CONST_LIGHTPARAM8				8
#define SHADER_CONST_LIGHTPARAM9		 		9
#define SHADER_CONST_LIGHTPARAM10				10
#define SHADER_CONSTANTBUFFER_LIGHTS_SIZE		11

struct SLights
{
	float4		m_lightParams[SHADER_CONSTANTBUFFER_LIGHTS_SIZE];
};
typedef SLights VSLight;
typedef SLights PSLight;





#define SHADER_CONST_MATERIAL0					0
#define SHADER_CONST_MATERIAL1					1
#define SHADER_CONST_MATERIAL2					2
#define SHADER_CONST_MATERIAL3					3
#define SHADER_CONST_MATERIAL4					4
#define SHADER_CONST_MATERIAL5					5
#define SHADER_CONST_MATERIAL6					6
#define SHADER_CONST_MATERIAL7					7
#define SHADER_CONSTAMTBUFFER_MATERIAL_SIZE		8

struct SMaterial
{
	float4		m_materials[SHADER_CONSTAMTBUFFER_MATERIAL_SIZE];
};
typedef SMaterial VSMaterial;
typedef SMaterial PSMaterial;




struct SObjectBase
{
	TMatrix4x4		m_viewWorld;
	TMatrix4x4		m_world;
	float4			m_useWeightCount;
};



struct SObject
{
	TMatrix4x4		m_viewWorld;
	TMatrix4x4		m_world;
	float4			m_useWeightCount;
	float4			m_localParam[4];
};
typedef SObject VSObject;
typedef SObject PSObject;

#define SHADER_CONST_VIEWWORLD					0
#define SHADER_CONST_WORLD						4
#define SHADER_CONST_USEWEIGHTCOUNT				8
#define SHADER_CONST_LOCALPARAM0				9
#define SHADER_CONST_LOCALPARAM1				10
#define SHADER_CONST_LOCALPARAM2				11
#define SHADER_CONST_LOCALPARAM3				12
#define SHADER_CONSTANTBUFFER_OBJECT_SIZE		13




struct SBone
{
	TMatrix4x3		m_boneMatrices[32];

};
typedef SBone VSBone;

#define SHADER_CONST_BLENDMATRIX0				0
#define SHADER_CONST_PREV_BLENDMATRIX0			96
#define SHADER_BLENDMATRIX_SIZE					3
#define SHADER_CONSTANTBUFFER_BONE_SIZE			192




struct SWork
{
	TMatrix4x4		m_viewInverse;
	TMatrix4x4		m_matrix[8];
};


struct PSWork
{
	float4			m_vectors[36];
};
typedef SWork VSWork;

#define SHADER_CONST_VIEWINVERSE				0
#define SHADER_CONST_WORKMATRIX0				4
#define SHADER_CONSTANTBUFFER_WORK_SIZE			36




#line 290 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefineForDx11Gen.h"


#define TEXUNIT_VOLUMEFOG	TEXUNIT12	// DefferredShading�ȍ~����Draw2D�܂ł͎g��
#define TEXUNIT_DEPTH		TEXUNIT13
#define TEXUNIT_SHADOW		TEXUNIT14



#line 501 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_CONSTANTBUFFER


#line 507 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#	define PS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define VS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define REGISTERMAP(_type, _name, _register) cbuffer c##_type { static _type _name; }

#line 517 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#define SHINESS_NORMALIZE_MAX			256.0
#define SQRT_SHINESS_NORMALIZE_MAX		16.0


#define DG_DRAWPROJECTION_CLIPSPACE_DIRECTX	0
#define DG_DRAWPROJECTION_CLIPSPACE_OPENGL	1








#line 554 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_SPHERICAL_GAUSSIAN_FRESNLE


#line 560 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 564 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"



#line 571 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 577 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_DIRECTX

#line 581 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 586 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 588 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_1002_OPTIMIZE
#define USE_1003_OPTIMIZE


#line 595 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define NOADJUST_DIMMER			//Dimmer��ݒ肵�Ă��P���̈ʒu�̋P�x�������Ȃ��@�\�͂���Ȃ�



#line 603 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 608 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define DG_HIGH_PRECISION_LACC


#line 616 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 620 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#line 626 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"



#line 634 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"


#define NORMALMAP_DECODE_DIVZERO_AVOIDANCE

#line 639 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_3RTGBUFFER_PROFILE	//GBUFFER�R���\��


#define PRIMIRIVE_OUTPUT_MULTI_TARGET		///< �k���o�b�t�@�ƃ}�X�N�����̐����������߂�

#define DRAW2D_BORDER_OLDTYPE				///< �t�H���g�V�F�[�_�̉������ȑO�̂܂܂ɂ���i�O���ΐV�������[�h)



#line 14 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#define _SHADER_H_


#line 19 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
#define F_TARGET_WINDX11

#line 26 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 30 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 37 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#define HALF_MIN	(-65504.0)
#define HALF_MAX	(65504.0)



#line 61 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 74 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"




#line 86 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 102 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define ResolveEndian(color) color.rgba

#define GBUFFER_WIDTH		(1920)
#define GBUFFER_HEIGHT		(1080.0)
#define GBUFFER_PIXELWIDTH	(1.0 / GBUFFER_WIDTH)
#define GBUFFER_PIXELHEIGHT	(1.0 / GBUFFER_HEIGHT)

#define h4tex1D(_s, _uv)		((half4)tex1D(_s, _uv))
#define h4tex2D(_s, _uv)		((half4)tex2D(_s, _uv))
#define h4tex3D(_s, _uv)		((half4)tex3D(_s, _uv))
#define h4tex2Dlod(_s, _uv)		((half4)tex2Dlod(_s, _uv))
#define h4tex2Dproj(_s, _uv)	((half4)tex2Dproj(_s, _uv))

#pragma warning( disable : 4000 )


#line 120 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 131 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"




#line 140 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define DG_SUPPORT_FLEXIBLE_VIEWPORT

#line 144 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 150 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#define MAX_FILTER_WIDTH   (64)
#define MAX_FILTER_HEIGHT  (64)

#line 155 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#define RANDOM_TEXTURE_SIZE (32.0)
#define INV_RANDOM_TEXTURE_SIZE (1.0 / 32.0)


#define DECODING_GAMMA  (2.2)

#define ENCODING_GAMMA  (1.0/DECODING_GAMMA)





#define COLOR_ROTATION    (g_psScene.m_shadowProjection)



#define ENABLE_NONDEFERRED_DISTANCE_FADE




#define LUMINANCE_VECTOR  (half3(0.2125h, 0.7154h, 0.0721h))




#define MAX_LUMINANCE (32.0)

#line 190 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define HDR_LUM_SCALE ( 16.0h )

#line 193 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define USER_TEXCUBELOD	//���t���N�V�����v�Z��texCUBElod���g��
#define CUBEMAP_BIAS_MAX (5.0H)

#line 200 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define LIGHTSCALE_DIFFUSE_TO_SPECULAR (3.1415926H)
#define FWLIGHT_INNER_RANGE (0.5)


#line 207 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"






#line 215 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"




#line 228 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 235 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
#define CORRECT_TANGNET_VALUE(n) {}

#line 244 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
#define CORRECT_CLONE_TANGNET_VALUE(n) {}

#line 247 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"




#line 253 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
#define DG_ENABLE_HALFPIXELOFFSET

#line 256 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define PIXELCENTEROFFSET (-0.5)

#line 262 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 272 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

#define ToVPos(wpos) (float2(wpos.x, g_psSystem.m_renderBuffer.y - wpos.y) + PIXELCENTEROFFSET)
#define ToVPos4(wpos) float4(ToVPos(wpos), 0, 0 )
#define ToWPos(vpos) (vpos + 0.5f + PIXELCENTEROFFSET)
#define ToWPos4(vpos) ToWPos(vpos)


#line 279 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"






#line 285 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

SamplerState g_samplerPoint_Wrap		: SAMPLERUNIT8;
SamplerState g_samplerPoint_Clamp	: SAMPLERUNIT9;
SamplerState g_samplerLinear_Wrap	: SAMPLERUNIT10;
SamplerState g_samplerLinear_Clamp	: SAMPLERUNIT11;
SamplerState g_samplerAnisotropic_Wrap : SAMPLERUNIT12;
SamplerState g_samplerAnisotropic_Clamp : SAMPLERUNIT13;
SamplerComparisonState g_samplerComparisonLess_Point_Clmap : SAMPLERUNIT14;
SamplerComparisonState g_samplerComparisonLess_Linear_Clmap : SAMPLERUNIT15;

#define SamplerPoint		g_samplerPoint_Wrap
#define SamplerPointClamp 	g_samplerPoint_Clamp
#define SamplerLinear	 	g_samplerLinear_Wrap
#define SamplerLinearClamp	g_samplerLinear_Clamp
#define SamplerAnisotropic	g_samplerAnisotropic_Wrap
#define SamplerAnisotropicClamp	g_samplerAnisotropic_Clamp
#define SamplerComparisonLess	g_samplerComparisonLess_Point_Clmap
#define SamplerComparisonLessLinear	g_samplerComparisonLess_Linear_Clmap

float2 CalcProjectCoords(float4 uv) {
	return (uv / uv.w).xy;
}

#define TFetch(_texture, _sampler, _uv) 		_texture.Sample(_sampler, float2((_uv).x, 1 - (_uv).y))
#define TFetchOffset(_texture, _sampler, _uv, _offset) _texture.Sample(_sampler, float2((_uv).x, 1 - (_uv).y), _offset)

#define TFetch1D(_texture, _sampler, _uv) 		_texture.Sample(_sampler, (_uv))
#define TFetch1DOffset(_texture, _sampler, _uv, _offset) _texture.Sample(_sampler, (_uv), _offset)
#define TFetch2D 								TFetch
#define TFetch2DOffset							TFetchOffset
#define TFetch2DGrad							TFetchGrad
#define TFetch2DProj(_texture, _sampler, _uv) 	TFetch(_texture, _sampler, CalcProjectCoords(_uv))

#define TFetch3D(_texture, _sampler, _uv)		_texture.Sample(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z))
#define TFetchCube(_texture, _sampler, _uv)		_texture.Sample(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z))
#define TFetchCubeBias(_texture, _sampler, _uv)	_texture.SampleBias(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z), (_uv).w)


#line 326 "..\Gr\Dg\shader\shader.h"
#define TFetchGrad(_texture, _sampler, _uv, _dx, _dy) _texture.SampleGrad(_sampler, float2((_uv).x, 1 - (_uv).y), _dx, _dy) // Forces 2D but only used for terrain albedo and noraml textures
#define TFetch2DLod(_texture, _sampler, _uv) 	_texture.SampleLevel(_sampler, float2((_uv).x, 1 - (_uv).y), (_uv).w)
#define TFetchCubeLod(_texture, _sampler, _uv)	_texture.SampleLevel(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z).xyz, (_uv).w)

#line 331 "..\Gr\Dg\shader\shader.h"

float TFetch2DProjCmp(Texture2D _texture, SamplerComparisonState _sampler, float4 _uv)
{
	float3 prjectionUV = (_uv.xyz / _uv.w);
	return _texture.SampleCmp(_sampler, float2(prjectionUV.x, 1 - prjectionUV.y), prjectionUV.z);
}

#define TFetchH(_texture, _sampler, _uv) ((half4)TFetch(_texture, _sampler, _uv))
#define TFetch1DH(_texture, _sampler, _uv) ((half4)TFetch1D(_texture, _sampler, _uv))
#define TFetch2DH(_texture, _sampler, _uv) ((half4)TFetch2D(_texture, _sampler, _uv))
#define TFetch2DProjH(_texture, _sampler, _uv) ((half4)TFetch2DProj(_texture, _sampler, _uv))
#define TFetch2DLodH(_texture, _sampler, _uv) ((half4)TFetch2DLod(_texture, _sampler, _uv))
#define TFetch3DH(_texture, _sampler, _uv) ((half4)TFetch3D(_texture, _sampler, _uv))
#define TFetch2DProjCmpH(_texture, _sampler, _uv) ((half4)TFetch2DProjCmp(_texture, _sampler, _uv))
#define TFetch2DGradH(_texture, _sampler, _uv, _dx, _dy) ((half4)TFetch2DGrad(_texture, _sampler, _uv, _dx, _dy))


#line 384 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 389 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half4 packFP16(float2 v)
{

	float4 _packed;





	_packed.xz = frac(256.0 * v.xy);
	_packed.yw = _packed.xz * (-1.0 / 256.0) + v.xy;

	return half4(_packed);
}



#line 409 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half4 packFP32(float v)
{

	float4 p = v * float4(1.0, 256.0, (256.0 * 256.0), (256.0 * 256.0 * 256.0));
	return half4(floor(frac(p) * 256.0) * (1.0 / 255.0));
}






float2 unpackFP16(float4 _packed)
{
	const float2 bitSh = float2(1.0 / 256.0, 1.0);
	float2 _unpacked;
	_unpacked.x = dot(_packed.xy, bitSh);
	_unpacked.y = dot(_packed.zw, bitSh);
	return _unpacked;
}




float unpackFP32(float4 _packed)
{
	return dot(_packed, float4(
		(255.0 / 256.0),
		(255.0 / (256.0 * 256.0)),
		(255.0 / (256.0 * 256.0 * 256.0)),
		(255.0 / (256.0 * 256.0 * 256.0 * 256.0))
		));
}



#line 448 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

inline half4 WriteSpecularAndVelocity(half2 inSpecular, half2 inVelocity)
{
	half4 outColor;
	outColor.xy = inSpecular;
	outColor.zw = inVelocity;
	return outColor;
}



#line 459 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

inline half2 ReadSpecular(half4 inColor)
{
	return inColor.xy;
}



#line 467 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

inline half2 ReadVelocity(half4 inColor)
{
	return inColor.zw;
}



#line 475 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

inline half PyramidalDoFMatting(float z, float4 zThresholds)
{
	float z_2 = zThresholds.x;
	float z_1 = zThresholds.y;
	float z0 = zThresholds.z;
	float z1 = zThresholds.w;

	half matting = 1;
	if (z < z_1) {
		matting = (z_1 <= z_2) ? 0 :
			half(saturate((z - z_2) / (z_1 - z_2)));
	}
	else if (z > z0) {
		matting = half(saturate((z1 - z) / (z1 - z0)));
	}

	return matting;
}



#line 501 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

float CalcGlobalVolumetricFogDensity(float3 cameraToWorldPos, float globalDensity, float heightFallOff, float volumetricFogHeightDensityAtViewer)
{

	float fogInt = length(cameraToWorldPos) * volumetricFogHeightDensityAtViewer;



	float t = max(heightFallOff * cameraToWorldPos.y, 0.00001);



	fogInt *= (1.0f - exp(-t)) / t;


	return exp(-globalDensity * fogInt);
}



#line 525 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 529 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
half GetFresnelSpecularFactor(half3 halfDir, half3 lightDir, half f0)
{

	half cosValue = half(saturate(dot(halfDir, lightDir)));
	return f0 + (1.0H - f0) * (half)exp2((-5.55473h * cosValue - 6.98316h) * cosValue);

#line 538 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
}

#line 541 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 547 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half AdjustLightSizeFromDistance(half size, float dist)
{








	return (half)saturate(size * 1.0H / dist * 0.9);
}





#line 572 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 GetReflectionWithRoughness(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, half raghnessRate, TMatrix4x4 mat)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	half4 ref_vec2;
	ref_vec2.xyz = (half3) ApplyMatrixT(mat, refVec.xyz);
	ref_vec2 = half4 (ref_vec2.xyz, lerp(0, CUBEMAP_BIAS_MAX, 1 - raghnessRate));


	return (half3)TFetchCubeLod(refTex, SamplerLinear, ref_vec2).xyz;

#line 586 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
}



#line 597 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 GetReflection(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, TMatrix4x4 mat)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	refVec.xyz = (half3) ApplyMatrixT(mat, refVec.xyz);


	return (half3)TFetchCube(refTex, SamplerLinear, refVec).xyz;
}



#line 615 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 GetReflectionWithRoughness_World(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, half raghnessRate)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	half4 ref_vec2 = half4 (refVec.xyz, lerp(0, CUBEMAP_BIAS_MAX, 1 - raghnessRate));


	return (half3)TFetchCubeLod(refTex, SamplerLinear, ref_vec2).xyz;

#line 627 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"
}



#line 637 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 GetReflection_World(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);


	return (half3)TFetchCube(refTex, SamplerLinear, refVec).xyz;
}



#line 654 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half4 select(half4 a, half4 b, half4 c)
{
	half4 sel = (half4)step(half4 (0, 0, 0, 0), a);
	return sel * c + (half4 (1, 1, 1, 1) - sel) * b;
}
half3 select(half3 a, half3 b, half3 c)
{
	half3 sel = (half3)step(half3 (0, 0, 0), a);
	return sel * c + (half3 (1, 1, 1) - sel) * b;
}
half2 select(half2 a, half2 b, half2 c)
{
	half2 sel = (half2)step(half2 (0, 0), a);
	return sel * c + (half2 (1, 1) - sel) * b;
}
half select(half a, half b, half c)
{
	half sel = (half)step(0, a);
	return sel * c + (1.0H - sel) * b;
}



#line 683 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 GetBlendColor_Overlay(half3 baseColor, half3 layerColor, half blendRate)
{
	half3 color0 = baseColor.xyz * layerColor.xyz * 2;
	half3 color1 = 1.0H - (1.0H - baseColor.xyz) * (1.0H - layerColor.xyz) * 2;
	half3 outColor = select(baseColor - 0.5H, color0, color1);

	return (half3) lerp(baseColor.xyz, outColor, blendRate);
}



#line 698 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half GetCheckerPattern(half2 uv, half repeat)
{
	half2 checker = (half2)step(0.5h, (half2)frac(uv.xy * repeat));
	return (1.0h - abs(checker.x - checker.y));
}

#define DIRTY_BLEND_AFTER_REFLECTION

half3 BlendDirtyColorSub(out half outRoughness, half4 dirtyColor, half3 inColor, half roughness, half3 mask)
{
	half3 outColor;



	half3 blend = mask.xyz * dirtyColor.xyz;


	half waterScaleBase = min(0.93H, max(0.73H, (roughness * 255.0H - 205.0H) / 25.0H * (-0.20H) + 0.93H));
	half waterScaleRoughness = min(0.66H, (half)saturate((roughness * 255.0H - 170.0H) / 60.0H * 0.66H));



	outColor = (half3)lerp(inColor, inColor * waterScaleBase.xxx, blend.zzz);
	outColor = (half3)lerp(outColor, half3 (0.2H, 0.196078431H, 0.192156863H), blend.yyy);

	outColor = (half3)lerp(outColor, half3 (0.2588H, 0.04705H, 0.043137H), blend.xxx);


	outRoughness = (half)lerp(roughness, roughness * waterScaleRoughness.x, blend.z);
	outRoughness = (half)lerp(outRoughness, 0.98H, blend.y);
	outRoughness = (half)lerp(outRoughness, 0.2H, blend.x);

	return outColor;

}
half3 BlendDirtyColorRoughnessMaskSub(out half outRoughness, half4 dirtyColor, half3 inColor, half roughness, half3 mask, half3 roughnessMask)
{
	half3 outColor;



	half3 blend = mask.xyz * dirtyColor.xyz;
	half3 blendR = roughnessMask.xyz * dirtyColor.xyz;


	half waterScaleBase = min(0.93H, max(0.73H, (roughness * 255.0H - 205.0H) / 25.0H * (-0.20H) + 0.93H));
	half waterScaleRoughness = min(0.66H, (half)saturate((roughness * 255.0H - 170.0H) / 60.0H * 0.66H));



	outColor = (half3)lerp(inColor, inColor * waterScaleBase.xxx, blend.zzz);
	outColor = (half3)lerp(outColor, half3 (0.2H, 0.196078431H, 0.192156863H), blend.yyy);

	outColor = (half3)lerp(outColor, half3 (0.2588H, 0.04705H, 0.043137H), blend.xxx);


	outRoughness = (half)lerp(roughness, roughness * waterScaleRoughness.x, blendR.z);
	outRoughness = (half)lerp(outRoughness, 0.98H, blendR.y);
	outRoughness = (half)lerp(outRoughness, 0.2H, blendR.x);

	return outColor;

}



#line 776 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 BlendDirtyColor(out half outRoughness, Texture2D dirtyTexture, float2 texcoord, half3 inColor, half roughness, half3 mask)
{
	half4 dirtyTex = TFetch2DH(dirtyTexture, SamplerLinear, texcoord);
	return BlendDirtyColorSub(outRoughness, dirtyTex, inColor, roughness, mask);
}
half3 BlendDirtyColorRoughnessMask(out half outRoughness, Texture2D dirtyTexture, float2 texcoord, half3 inColor, half roughness, half3 mask, half3 roughnessMask)
{
	half4 dirtyTex = TFetch2DH(dirtyTexture, SamplerLinear, texcoord);
	return BlendDirtyColorRoughnessMaskSub(outRoughness, dirtyTex, inColor, roughness, mask, roughnessMask);
}

half3 BlendDirtyColorWithSampler(out half outRoughness, Texture2D dirtyTexture, SamplerState dirtySampler, float2 texcoord, half3 inColor, half roughness, half3 mask)
{


	half4 dirtyTex = TFetch2DH(dirtyTexture, dirtySampler, texcoord);
	return BlendDirtyColorSub(outRoughness, dirtyTex, inColor, roughness, mask);
}
half3 BlendDirtyColorWithSamplerRoughnessMask(out half outRoughness, Texture2D dirtyTexture, SamplerState dirtySampler, float2 texcoord, half3 inColor, half roughness, half3 mask, half3 roughnessMask)
{


	half4 dirtyTex = TFetch2DH(dirtyTexture, dirtySampler, texcoord);
	return BlendDirtyColorRoughnessMaskSub(outRoughness, dirtyTex, inColor, roughness, mask, roughnessMask);
}


half3 BlendDirtyColorRSub(out half outRoughness, half4 dirtyColor, half3 inColor, half roughness, half3 mask)
{
	half3 outColor;



	half3 blend = mask.xyz * dirtyColor.xyz;







	outColor = (half3)lerp(inColor, half3 (0.2588H, 0.04705H, 0.043137H), blend.xxx);
	outRoughness = (half)lerp(roughness, 0.2H, blend.x);

	return outColor;

}



#line 834 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"

half3 BlendDirtyColorR(out half outRoughness, Texture2D dirtyTexture, float2 texcoord, half3 inColor, half roughness, half3 mask)
{
	half4 dirtyTex = (half4)TFetch2D(dirtyTexture, SamplerLinear, texcoord);
	return BlendDirtyColorRSub(outRoughness, dirtyTex, inColor, roughness, mask);
}

half3 BlendDirtyColorRWithSampler(out half outRoughness, Texture2D dirtyTexture, SamplerState dirtySampler, float2 texcoord, half3 inColor, half roughness, half3 mask)
{
	half4 dirtyTex = (half4)TFetch2D(dirtyTexture, dirtySampler, texcoord);
	return BlendDirtyColorRSub(outRoughness, dirtyTex, inColor, roughness, mask);
}


#line 848 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 2 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 5 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"

#define COMMON_H_




#line 36 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"



REGISTERMAP(PSScene, g_psScene, PS_REGISTER(SCENE));
REGISTERMAP(PSObject, g_psObject, PS_REGISTER(OBJECT));
REGISTERMAP(PSLight, g_psLight, PS_REGISTER(LIGHT));
REGISTERMAP(PSMaterial, g_psMaterial, PS_REGISTER(MATERIAL));
REGISTERMAP(PSWork, g_psWork, PS_REGISTER(WORK));
REGISTERMAP(PSSystem, g_psSystem, PS_REGISTER(SYSTEM));

#	ifndef USE_CONSTANTBUFFER
REGISTERMAP(PSTiling, g_psTiling, PS_REGISTER(TILING));
#	endif 

#line 53 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"


#line 1 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"







#line 13 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"



#line 22 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"




#line 32 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"



#line 41 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"

#define MAX_CASCADE_BLOCKS (4)

#define SHADOW_SUN_SIZE		g_psScene.m_shadowMapResolutions.x
#define SHADOW_CAST1_SIZE 	g_psScene.m_shadowMapResolutions.y
#define SHADOW_CAST2_WIDTH	g_psScene.m_shadowMapResolutions.z
#define SHADOW_CAST2_HEIGHT	g_psScene.m_shadowMapResolutions.w

#line 58 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"



#line 67 "..\..\..\..\fox\source\system\Gr\Dg\shader\shadowDefine.h"



#line 55 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"



#line 68 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"



#line 71 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"





#line 76 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"

float3 GetEyePosition() {
	return g_psScene.m_eyepos.xyz;
}

#line 81 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.h"



#line 3 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#define NEW_VIEWPOS_RECONSTRUCT_CALC



#define ENCODE_NORMAL					// XY�̐��K���AZ��sqrt���Ƃ��





#line 19 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"




#line 25 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

half4 EncodeViewSpaceNormal(half3 normal)
{
	half4	encodeNormal = 0.0;

#line 30 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

	encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
	encodeNormal.z = half(sqrt(half(normal.z) * 0.5h + 0.5h));

#line 45 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 51 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

	return encodeNormal;
}



#line 88 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"





#line 96 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

half3 DecodeViewSpaceNormal(half4 encodeNormal)
{

#line 107 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 116 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 127 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	float bias = 1.0e-007f;

#line 131 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	half3	viewSpaceNormal;
	viewSpaceNormal.xy = encodeNormal.xy * 2.0h - 1.0h;
	viewSpaceNormal.z = (encodeNormal.z * encodeNormal.z) * 2.0h - 1.0h;
	half	oneMinusZz = 1.0h - viewSpaceNormal.z * viewSpaceNormal.z;
	viewSpaceNormal.xy = (viewSpaceNormal.xy * oneMinusZz) * (half)rsqrt(oneMinusZz * (half)dot(viewSpaceNormal.xy, viewSpaceNormal.xy) + bias);

#line 139 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 145 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	return half3(viewSpaceNormal);
}



#line 154 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

half3 ReconstructViewSpaceNormal(Texture2D normals, float2 uv)
{

	return DecodeViewSpaceNormal(TFetch2DLodH(normals, SamplerPointClamp, float4(uv, 0, 0)));
}

half3 ReconstructViewSpaceNormalWithSampler(Texture2D normals, SamplerState samplerstate, float2 uv)
{

	return DecodeViewSpaceNormal(TFetch2DH(normals, samplerstate, uv));
}




#line 188 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 DecodeNormalTexture(half4 color)
{
	half3	normal;


#line 196 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"



#line 201 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	normal.xyz = half3(color.agb) * 2.0h - 1.0h;





	half tmp = half(saturate(1.0h - normal.x * normal.x - normal.y * normal.y) + 0.0001h);

#line 213 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	normal.z = half(tmp * rsqrt(tmp));


	return normal;
}



#line 227 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromTextureWithSampler(Texture2D tex, SamplerState samplerstate, float2 uv)
{
	return DecodeNormalTexture(TFetch2DH(tex, samplerstate, uv));
}



#line 238 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromTexture(Texture2D tex, float2 uv)
{
	return DecodeNormalTexture(TFetch2DH(tex, SamplerLinear, uv));
}





#line 251 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromArrayTexture(Texture3D tex, float3 texcoord)
{
	return DecodeNormalTexture(TFetch3DH(tex, SamplerLinear, texcoord));
}


#line 269 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"






#line 278 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPos(float4 clipSpacePos, float4 proj)
{
	float3 viewPos;


#line 288 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	viewPos.z = proj.z / (clipSpacePos.z - proj.w);
	viewPos.xy = (clipSpacePos.xy * proj.xy) * viewPos.z;

#line 292 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

	return float4(viewPos, 1);
}



#line 303 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPosFromTexture(Texture2D inDepth, half2 inTexCoord, float2 clipSpacePosXY, float4 inProjectionParam)
{

#line 329 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, half4(inTexCoord, 0, 0)).x;

#line 335 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

	return ReconstructViewPos(float4(clipSpacePosXY, zOverW, 1), inProjectionParam);
}



#line 347 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPos2(float2 inScreenSpacePos, float inDepth, float4 inProjectionParam)
{

#line 356 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 366 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	float3	viewPos;
	viewPos.xy = inScreenSpacePos.xy * inProjectionParam.xy;
	viewPos.z = inProjectionParam.z / (inDepth - inProjectionParam.w);

#line 374 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	viewPos.xy = viewPos.xy * viewPos.z;
	return float4(viewPos.xyz, 1);
}



#line 385 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

float ReconstructViewZ(float zOverW, float4 proj)
{

#line 394 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"


#line 397 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	return (proj.z / (zOverW - proj.w));
}



#line 408 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"

float ReconstructViewZFromTexture(Texture2D inDepth, float2 inTexCoord, float4 projectionParameter)
{

#line 425 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)).x;

#line 431 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	return ReconstructViewZ(zOverW, projectionParameter);
}


struct DepthBlendResult
{
	float		value;
	float		valueSub;
};

struct PrimitiveDepthFactor
{
	float		viewZ;
	float		viewZSub;
};


void ReconstructViewZFromPrimitiveDepthTexture(Texture2D inDepth, float2 inTexCoord, float4 projectionParameter, out PrimitiveDepthFactor depth)
{

#line 467 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	float4 fetchDepth = TFetch2D(inDepth, SamplerPointClamp, inTexCoord);

#line 472 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
	depth.viewZ = ReconstructViewZ(fetchDepth.x, projectionParameter);

	{

#line 480 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
		depth.viewZSub = ReconstructViewZ(fetchDepth.y, projectionParameter);
	}

#line 484 "..\..\..\..\fox\source\system\Gr\Dg\shader\CoordinateCalculation.h"
}

#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"





#line 8 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 18 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 23 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 34 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 39 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 62 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"



#line 64 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 74 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 79 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 88 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"



#line 97 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"



#line 103 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 114 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 120 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 130 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 136 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 146 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 152 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 163 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 169 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 180 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 184 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 197 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"



#line 200 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 213 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"



#line 216 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 223 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 233 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 239 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 249 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 255 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 265 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 271 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 284 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"




#line 290 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 300 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"





#line 307 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 320 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 1 "..\..\..\..\fox\source\system\Gr\Dg\shader\HdrColor.h"
#define HDR_COLOR_H


#line 6 "..\..\..\..\fox\source\system\Gr\Dg\shader\HdrColor.h"




#line 12 "..\..\..\..\fox\source\system\Gr\Dg\shader\HdrColor.h"

half4 EncodeHDRColor(half3 color)
{
	half4	encodeColor;


	encodeColor.xyz = color.xyz;


	encodeColor.w = dot(color.xyz, LUMINANCE_VECTOR * (1.0h / HDR_LUM_SCALE));

	return encodeColor;
}



#line 30 "..\..\..\..\fox\source\system\Gr\Dg\shader\HdrColor.h"

half3 DecodeHDRColor(half4 encodeColor)
{
	half	scale;
	half3	color;


	scale = max(1.0h, encodeColor.w * HDR_LUM_SCALE);
	color.xyz = encodeColor.xyz * scale;

	return color;
}


#line 5 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\Tonemap.h"



#line 9 "..\..\..\..\fox\source\system\Gr\Dg\shader\Tonemap.h"

half3 GetTonemapedColor_Filmic(half3 color)
{
	half3 x = max(0, (color - 0.004h));
	return (x * ((6.2h * x) + 0.5h)) / ((x * ((6.2h * x) + 1.7h)) + 0.06h);
}



#line 20 "..\..\..\..\fox\source\system\Gr\Dg\shader\Tonemap.h"

half3 getTonemapedColor_UnchartedFilmic(half3 color, half a, half b, half c, half d, half e, half f)
{
	return ((color * ((a * color) + (c * b)) + (d * e)) / (color * ((a * color) + b) + (d * f))) - (e / f);
}



#line 30 "..\..\..\..\fox\source\system\Gr\Dg\shader\Tonemap.h"

half3 GetTonemapedColor_UnchartedFilmic(half3 color, half w, half a, half b, half c, half d, half e, half f)
{
	half3 invTonemapedWhite = (1.0 / getTonemapedColor_UnchartedFilmic(w, a, b, c, d, e, f));
	return getTonemapedColor_UnchartedFilmic(color, a, b, c, d, e, f) * invTonemapedWhite;
}

#line 6 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"

#define _GAMMA_TRANSFORMATION_H_


#line 11 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"

half3 GammaCorrection(float3 linearRGB)
{

#line 24 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(linearRGB, 0.0031308);
	return (half3)((mask * (linearRGB * 12.92)) + ((1 - mask) * (1.055 * pow(max(linearRGB, 0.00001), (1.0 / 2.4)) - 0.055)));
}



#line 35 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"

float3 GammaDecode(float3 inSRGB)
{

#line 48 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(inSRGB, 0.03928);
	return (half3)(mask * (inSRGB / 12.92)) + ((1 - mask) * (pow(max((inSRGB + 0.055) / 1.055, 0.00001), 2.4)));
}



#line 59 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"

float GammaDecodeF(float f)
{
	float linear_f;
	linear_f = ((f <= 0.03928) ? f / 12.92 : pow(abs((f + 0.055) / 1.055), 2.4));
	return linear_f;
}


#line 7 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 3 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"




#define GVFOG_VERTICAL_RESOLUTION	( 64.0 )
#define GVFOG_VOLUME_W				( 16.0 )	// volume width
#define GVFOG_VOLUME_H				( 64.0 )	// volume height
#define GVFOG_VOLUME_D				( 128.0 )	// volume depth
#define GVFOG_LAYERS_PER_ROW		( 32.0 )
#define GVFOG_LAYERS_PER_COL		( GVFOG_VOLUME_D / GVFOG_LAYERS_PER_ROW )
#define GVFOG_TEXTURE_W				( GVFOG_LAYERS_PER_ROW * GVFOG_VOLUME_W )	// texture width
#define GVFOG_TEXTURE_H				( GVFOG_LAYERS_PER_COL * GVFOG_VOLUME_H )	// texture height
#define GVFOG_YSCALE				( GVFOG_VERTICAL_RESOLUTION / GVFOG_VOLUME_H )
#define GVFOG_XCLIPSCALE			( 2.0 * GVFOG_VOLUME_W / ( GVFOG_VOLUME_W - 1.0 ) )
#define GVFOG_YCLIPSCALE			( 2.0 * GVFOG_VOLUME_H / ( GVFOG_VOLUME_H - 1.0 ) )
#define GVFOG_USCALE				( 0.5 / GVFOG_LAYERS_PER_ROW - 0.5 / GVFOG_TEXTURE_W )
#define GVFOG_VSCALE				( 0.5 * GVFOG_YSCALE / GVFOG_LAYERS_PER_COL - 0.5 / GVFOG_TEXTURE_H )
#define GVFOG_UOFFSET				( 0.5 / GVFOG_LAYERS_PER_ROW )
#define GVFOG_VOFFSET				( 0.5 * GVFOG_YSCALE / GVFOG_LAYERS_PER_COL )



half EncodeFogCameraZ(float inViewZ)
{
	half invLogFarDistance = (half)g_psScene.m_fogParam[1].x;

#line 30 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	return invLogFarDistance * (half)log2(inViewZ);
}



float DecodeFogCameraZ(float inEncodedZ)
{
	float logFarDistance = 1.0 / g_psScene.m_fogParam[1].x;

#line 42 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	return exp2(inEncodedZ * logFarDistance);
}


#line 47 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"

half4 GetVolumetricFog2D(half2 inClipPos, float inViewZ, Texture2D inFogVolume)
{
	half	zEncoded = EncodeFogCameraZ(inViewZ);
	zEncoded = (half)saturate(zEncoded);
	zEncoded *= (GVFOG_VOLUME_D - 1.0h);
	half2	layerPacking = half2(1.0 / GVFOG_LAYERS_PER_ROW, 1.0 / GVFOG_LAYERS_PER_COL);
	half2	uvScale = half2(GVFOG_USCALE, GVFOG_VSCALE);
	half2	uvOffset = half2(GVFOG_UOFFSET, GVFOG_VOFFSET);
	half2	uv = uvScale * (half2)inClipPos + uvOffset;
	half2	zInt = (half2)floor(float2(zEncoded, clamp(zEncoded + 1, 0, GVFOG_VOLUME_D - 1.0)));
	half4 layerOffset;
	layerOffset.xz = (half2) frac(zInt.xy / GVFOG_LAYERS_PER_ROW) * GVFOG_LAYERS_PER_ROW;
	layerOffset.yw = (half2) floor(zInt.xy / GVFOG_LAYERS_PER_ROW);
	half4 uv_lerp = uv.xyxy + layerPacking.xyxy * layerOffset.xyzw;
	half4 zBlend = (half4)frac(zEncoded);
	half4 c0 = TFetch2DH(inFogVolume, SamplerLinearClamp, uv_lerp.xy);
	half4 c1 = TFetch2DH(inFogVolume, SamplerLinearClamp, uv_lerp.zw);
	half4 fogColor = (1.0h - zBlend) * c0 + zBlend * c1;

#line 69 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	half normalizeFactor = (half)g_psScene.m_fogParam[1].y;
	fogColor.xyz *= normalizeFactor;
	return fogColor;
}

half4 GetFurthestVolumetricFog2D(half2 inClipPos, Texture2D inFogVolume)
{
	half2	layerPacking = half2(1.0 / GVFOG_LAYERS_PER_ROW, 1.0 / GVFOG_LAYERS_PER_COL);
	half2	uvScale = half2(GVFOG_USCALE, GVFOG_VSCALE);
	half2	uvOffset = half2(GVFOG_UOFFSET, GVFOG_VOFFSET);
	half2	uv = uvScale * (half2)inClipPos + uvOffset;
	half2	zInt = half2(127, 127);
	half4 layerOffset;
	layerOffset.xz = (half2) frac(zInt.xy / GVFOG_LAYERS_PER_ROW) * GVFOG_LAYERS_PER_ROW;
	layerOffset.yw = (half2) floor(zInt.xy / GVFOG_LAYERS_PER_ROW);
	half2 uv_lerp = uv.xy + layerPacking.xy * layerOffset.xy;
	half4 fogColor = TFetch2DH(inFogVolume, SamplerLinearClamp, uv_lerp.xy);

#line 90 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	half normalizeFactor = (half)g_psScene.m_fogParam[1].y;
	fogColor.xyz *= normalizeFactor;
	return fogColor;
}

half4 GetVolumetricFog3D(half2 inClipPos, float inViewZ, Texture3D inFogVolume)
{
	half	zEncoded = EncodeFogCameraZ(inViewZ);
	half3 volCoord = 0;
	volCoord.xy = inClipPos * half2(-0.5, 0.5) + half2(0.5, 0.5);
	volCoord.z = zEncoded;
	half4 fogColor = (half4)TFetch3D(inFogVolume, SamplerLinearClamp, volCoord.yxz);

#line 106 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	half normalizeFactor = (half)g_psScene.m_fogParam[1].y;
	fogColor.xyz *= normalizeFactor;
	return fogColor;
}

half4 GetFurthestVolumetricFog3D(half2 inClipPos, Texture3D inFogVolume)
{
	float3 volCoord = 1.0;
	volCoord.xy = inClipPos * float2(-0.5, 0.5) + float2(0.5, 0.5);
	half4 fogColor = (half4)TFetch3D(inFogVolume, SamplerLinearClamp, volCoord.yxz);

#line 120 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	half normalizeFactor = (half)g_psScene.m_fogParam[1].y;
	fogColor.xyz *= normalizeFactor;
	return fogColor;
}

Texture2D g_tex_fog	: TEXUNIT_VOLUMEFOG;

#line 131 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"


#line 137 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"

half4 GetVolumetricFog(half2 inClipPos, float inViewZ)
{

#line 142 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	return GetVolumetricFog2D(inClipPos, inViewZ, g_tex_fog);
}


#line 151 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"

half4 GetFurthestVolumetricFog(half2 inClipPos)
{

#line 156 "..\..\..\..\fox\source\system\Gr\Dg\shader\FogVolume.h"
	return GetFurthestVolumetricFog2D(inClipPos, g_tex_fog);
}


#line 8 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 1 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"

#define HDRBUFFER_COMMON_SHDR_


#line 2 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"













#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"




#line 14 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 848 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 5 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"

#define ALIAS_HDR_COLOR_H_


#line 2 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"













#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\../DgShaderDefine.h"




#line 14 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"



#line 848 "..\..\..\..\fox\source\system\Gr\Dg\shader\shader.h"


#line 8 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\GammaTransformation.h"


#line 9 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"



#line 95 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"

float3	BlendLuv(float3 src, float3 dest)
{
	return float3(
		lerp(dest.rg, src.rg, saturate((src.b / dest.b) * 0.5f)),
		dest.b + src.b
		);
}

const static float3x3 M = float3x3(
	0.2209, 0.3390, 0.4184,
	0.1138, 0.6780, 0.7319,
	0.0102, 0.1130, 0.2969);
const static float3x3 InverseM = float3x3(
	6.0014, -2.7008, -1.7996,
	-1.3320, 3.1029, -5.7721,
	0.3008, -1.0882, 5.6268);

float4 logLuvEncode(in float3 vRGB) {
	float4 vResult;
	float3 Xp_Y_XYZp = mul(vRGB, M);
	Xp_Y_XYZp = max(Xp_Y_XYZp, float3(1e-6, 1e-6, 1e-6));
	vResult.xy = Xp_Y_XYZp.xy / Xp_Y_XYZp.z;
	float Le = 2 * log2(Xp_Y_XYZp.y) + 127;
	vResult.w = frac(Le);
	vResult.z = (Le - (floor(vResult.w * 255.0f)) / 255.0f) / 255.0f;
	return vResult;
}

float3 logLuvDecode(in float4 vLogLuv) {
	float Le = vLogLuv.z * 255 + vLogLuv.w;
	float3 Xp_Y_XYZp;
	Xp_Y_XYZp.y = exp2((Le - 127) / 2);
	Xp_Y_XYZp.z = Xp_Y_XYZp.y / vLogLuv.y;
	Xp_Y_XYZp.x = vLogLuv.x * Xp_Y_XYZp.z;
	float3 vRGB = mul(Xp_Y_XYZp, InverseM);
	return max(vRGB, 0);
}

float4 rgbeEncode(in float3 vRGB)
{
	float fMax = max(max(vRGB.r, vRGB.g), vRGB.b);
	float fExp = floor(log(fMax) / log(1.04));
	float alpha = clamp(fExp / 255.0, 0.0, 1.0);
	vRGB /= pow(1.04, alpha * 255.0);
	return float4(vRGB, alpha);
}

float3 rgbeDecode(in float4 vRGBE)
{
	float e = pow(1.04f, vRGBE.a * 255.0f);
	vRGBE.rgb *= e;
	return vRGBE.rgb;
}

half4 RGBMEncode(half3 color)
{
	half4 rgbm;

	color = (half3)saturate(color * (1.0h / 32.0h));














	rgbm.a = (half)dot(color.rgb, half(255.0h / 3.0h).xxx);
	rgbm.a = (half)saturate((half)floor(rgbm.a) * (1.0h / 255.0h) + (1.0h / 255.0h));
	rgbm.rgb = color.rgb * (1.0h / 3.0h) / rgbm.a;





	return rgbm;
}

half3 RGBMDecode(half4 rgbm)
{
	return 32.0h * 3.0h * rgbm.rgb * rgbm.a;
}

half3 SRGBDecode(half4 srgb)
{
	return (half3)pow(2.2, srgb.xyz);
}

half4 SRGBEncode(half3 color)
{
	return half4(pow(0.4545454545454545, color.xyz), 1);
}


#line 214 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 259 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"




#line 265 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"

half4 EncodeAliasHDRColor(half3 color)
{

#line 269 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"
	return half4(color.xyz, 1.0h);

#line 278 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 289 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 300 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 304 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 334 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"
}



#line 341 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"

half3 DecodeAliasHDRColor(half4 encodedColor)
{

#line 345 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


	return encodedColor.xyz;

#line 354 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 356 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 369 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 381 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 387 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"


#line 419 "..\..\..\..\fox\source\system\Gr\Dg\shader\AliasHDRColor.h"
}

half4 EncodeRGBEColor(half3 color)
{
	half4	encodedColor;
	float3 vRGB = (float3)color;
	encodedColor = (half4)rgbeEncode(vRGB);
	return encodedColor;
}

half3 DecodeRGBEColor(half4 encodedColor)
{
	float4 vRGBE = (float4)encodedColor;
	half3 color = (half3)rgbeDecode(vRGBE);
	return color;
}



#line 7 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 9 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"
#define HDRBUF_ENCODE_DIFFUSE	EncodeAliasHDRColor
#define HDRBUF_DECODE_DIFFUSE	DecodeAliasHDRColor
#define HDRBUF_ENCODE_SPECULAR	EncodeAliasHDRColor
#define HDRBUF_DECODE_SPECULAR	DecodeAliasHDRColor

#line 21 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 35 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 49 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 63 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 77 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"

#define SamplerGBuffer SamplerPoint



#line 85 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 99 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 105 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 152 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 159 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 216 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"






#line 278 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 285 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 311 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 317 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 331 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 337 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 351 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 358 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 386 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 413 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 420 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 447 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 453 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 466 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 473 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 487 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 9 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"





#line 32 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"



#line 40 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"

float CalcInscatter(float3 cameraToWorldPos, float globalDensity, float heightFallOff, float volumetricFogHeightDensityAtViewer)
{
	float H = volumetricFogHeightDensityAtViewer;
	float B = globalDensity;
	float s = length(cameraToWorldPos);
	float a = heightFallOff;
	float y = max(cameraToWorldPos.y, 0);

#line 52 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"
	float	tmp = a * y + s * B * H;
	float inscatter = exp(-tmp - H) * s / (tmp);
	inscatter = 1 - inscatter;

	return inscatter;
}



#line 69 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 92 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"




#line 98 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 124 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"





#line 132 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 144 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"




#line 148 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 179 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"



#line 210 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"




#line 216 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 228 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


#line 5 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 4 "..\..\..\..\fox\source\system\Gr\Dg\shader\NearFarCommon.shdr"



#line 25 "..\..\..\..\fox\source\system\Gr\Dg\shader\NearFarCommon.shdr"





#line 43 "..\..\..\..\fox\source\system\Gr\Dg\shader\NearFarCommon.shdr"



#line 64 "..\..\..\..\fox\source\system\Gr\Dg\shader\NearFarCommon.shdr"



#line 75 "..\..\..\..\fox\source\system\Gr\Dg\shader\NearFarCommon.shdr"


#line 6 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"






#line 11 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 25 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"





#line 33 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 46 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"




#line 53 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 82 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"






#line 87 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 143 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"


#line 7 "shader\DR_VolFog_TppTonemap.shdr"


#line 3 "shader\TppTonemap.h"



#line 8 "shader\TppTonemap.h"

half3 TppTonemap(half3 params, half3 x)
{
	half3 mask = (half3)step(x, params.y);
	return (mask * x) + ((1.0h - mask) * (-1.0h / (params.x * (x + params.z - params.y)) + params.z + params.y));
}

#line 8 "shader\DR_VolFog_TppTonemap.shdr"




#line 14 "shader\DR_VolFog_TppTonemap.shdr"


#line 44 "shader\DR_VolFog_TppTonemap.shdr"




#line 47 "shader\DR_VolFog_TppTonemap.shdr"


#line 105 "shader\DR_VolFog_TppTonemap.shdr"



#line 41 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"
inline void NScreenToTextureCoordinate(float2 inPixelPosition, out float2 outTexcoord)
{
#line 46 "..\..\..\..\fox\source\system\Gr\Dg\shader\Common.shdr"


#ifdef F_TARGET_XBOX360
	outTexcoord = (inPixelPosition.xy + g_psTiling.m_vposOffset.xy + float2(0.5, 0.5))
		* g_psSystem.m_renderBuffer.zw;
#else
#ifdef DG_SHADER_GEN_DX11

	const float epsilon = 1.0 / 256.0;
	outTexcoord = (inPixelPosition.xy + (0.5 - epsilon))
		* g_psSystem.m_renderBuffer.zw;
#else
	outTexcoord = (inPixelPosition.xy + float2(0.5, 0.5))
		* g_psSystem.m_renderBuffer.zw;
#endif
#endif
}



#line 107 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"
inline void NFetchExposuredLAccDiffuse(Texture2D inSampler, float2 inTexcoord, out half3 outColor)
{
#line 116 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"

	half4 encodedDiffuse = TFetch2DH(inSampler, SamplerGBuffer, inTexcoord).xyzw;

	outColor = HDRBUF_DECODE_DIFFUSE(encodedDiffuse);

#ifdef F_TARGET_WIN32
#ifndef DG_HIGH_PRECISION_LACC
	outColor *= (half)g_psScene.m_exposure.y;
#endif
#endif

#ifdef F_TARGET_XBOXONE
#ifndef DG_HIGH_PRECISION_LACC
	outColor *= (half)g_psScene.m_exposure.y;
#endif
#endif

#ifdef F_TARGET_PS4
#ifndef DG_HIGH_PRECISION_LACC
	outColor *= (half)g_psScene.m_exposure.y;
#endif
#endif


#ifdef F_TARGET_XBOX360
#ifndef LACC_PRECISION_7E3
	outColor *= (half)g_psScene.m_exposure.y;
#endif
#endif


#ifdef F_TARGET_PS3
#ifndef HIGHPREC_LACC
	outColor *= (half)g_psScene.m_exposure.y;
#endif
#endif
}



#line 339 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"
inline void NFetchExposuredLAccSpecular(Texture2D inSampler, float2 inTexcoord, out half3 outColor)
{
#line 348 "..\..\..\..\fox\source\system\Gr\Dg\shader\HDRBuffer_Common.shdr"

	half4 encodedSpecular = TFetch2DH(inSampler, SamplerGBuffer, inTexcoord);
	outColor = HDRBUF_DECODE_SPECULAR(encodedSpecular);
}



#line 71 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"
inline void NCalculateColor(half3 inLightDiffuse, half3 inLightSpecular, float2 inTexcoord, Texture2D inAlbedo, Texture2D inOcclusion, out half3 outColor)
{
#line 83 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"


	half3 albedo = TFetch2DH(inAlbedo, SamplerLinear, inTexcoord).xyz;

	half3 occlusion = TFetch2DH(inOcclusion, SamplerLinear, inTexcoord).xxx;



	outColor = (half3)(albedo * inLightDiffuse.xyz + inLightSpecular.xyz) * occlusion;
}



#line 218 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"
inline void NApplyVolFog(half3 inColor, half2 inClipPos, float3 inViewPos, out half3 outColor)
{
#line 225 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_Common.shdr"

	half4 fogColor = GetVolumetricFog(inClipPos, inViewPos.z);
	outColor = inColor * fogColor.w + fogColor.xyz;
}



#line 35 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"
inline void NFetchViewZ(float2 inBasePos, float2 inBaseUV, Texture2D inZBuffer, out float3 outViewPos)
{
#line 42 "..\..\..\..\fox\source\system\Gr\Dg\shader\DeferredRendering_VolFog.shdr"

	PrimitiveDepthFactor	outDepth;
	ReconstructViewZFromPrimitiveDepthTexture(inZBuffer, inBaseUV, g_psScene.m_projectionParam, outDepth);
	outViewPos.xyz = outDepth.viewZ.xxx;
}



#line 16 "shader\DR_VolFog_TppTonemap.shdr"
inline void NCalcurateOutputColor2(half3 inColor, half2 inVPos, Texture2D inMesh, out half4 outColor)
{
#line 25 "shader\DR_VolFog_TppTonemap.shdr"

	outColor.xyz = inColor;
	half luminance = dot(inColor, LUMINANCE_VECTOR);
	outColor.w = luminance * (1.0h / MAX_LUMINANCE);

	outColor.w *= (half)rsqrt(max(outColor.w, 0.5 / 256.0));

	outColor.xyz = TppTonemap((half3)g_psMaterial.m_materials[0].xyz, outColor.xyz);

#ifdef F_TARGET_XBOX360
	outColor.xyz = GammaCorrection(outColor.xyz);
#endif

#ifdef USE_MESH_DITHER
	const float MESH_SIZE = (8.0);
	half2 meshTexcoord = (half2) frac(inVPos * float2(1.0 / MESH_SIZE, 1.0 / MESH_SIZE));
	outColor.xyz = outColor.xyz + (TFetch2DH(inMesh, SamplerPoint, meshTexcoord).r - 0.5h) / 128.0h;
#endif

}







Texture2D	NCalcurateOutputColor2_calculateOutputColor_inMesh;
Texture2D	NCalculateColor_calculateColor_inOcclusion;
Texture2D	NCalculateColor_calculateColor_inAlbedo;
Texture2D	NFetchExposuredLAccDiffuse_fetchLAccDiffuse_inSampler;
Texture2D	NFetchExposuredLAccSpecular_fetchLAccSpecular_inSampler;
Texture2D	NFetchViewZ_fetchViewPos_inZBuffer;
Texture2D	inAlbedo	:TEXUNIT8;
Texture2D	inLightDiffuse	:TEXUNIT9;
Texture2D	inLightSpecular	:TEXUNIT10;
Texture2D	inDepth	:TEXUNIT11;
Texture2D	inOcclusion	:TEXUNIT13;
Texture2D	inMesh	:TEXUNIT15;
#line 49 "shader\DR_VolFog_TppTonemap.shdr"
void ps_main(

	in	float4	inVPos	: VPOS,
	in	float2	inTexcoord : TEXCOORD0,
	out	half4	outColor : OUT_COLOR0
)
{
	#include "../UnityPatch/PreEntryPoint.hlsl"

	inVPos = ToVPos4(inVPos);
	float2	NScreenToTextureCoordinate_screenToTexcoord_inPixelPosition;
	float2 NScreenToTextureCoordinate_screenToTexcoord_outTexcoord;
#line 74 "shader\DR_VolFog_TppTonemap.shdr"
	NScreenToTextureCoordinate_screenToTexcoord_inPixelPosition = inVPos.xy;
	NScreenToTextureCoordinate(NScreenToTextureCoordinate_screenToTexcoord_inPixelPosition, NScreenToTextureCoordinate_screenToTexcoord_outTexcoord);


	float2	NFetchViewZ_fetchViewPos_inBasePos;
	float2	NFetchViewZ_fetchViewPos_inBaseUV;
	float3 NFetchViewZ_fetchViewPos_outViewPos;
#line 77 "shader\DR_VolFog_TppTonemap.shdr"
	NFetchViewZ_fetchViewPos_inBasePos = inTexcoord.xy;
#line 78 "shader\DR_VolFog_TppTonemap.shdr"
	NFetchViewZ_fetchViewPos_inBaseUV = NScreenToTextureCoordinate_screenToTexcoord_outTexcoord;
	NFetchViewZ(NFetchViewZ_fetchViewPos_inBasePos, NFetchViewZ_fetchViewPos_inBaseUV, inDepth, NFetchViewZ_fetchViewPos_outViewPos);


	float2	NFetchExposuredLAccSpecular_fetchLAccSpecular_inTexcoord;
	half3 NFetchExposuredLAccSpecular_fetchLAccSpecular_outColor;
#line 85 "shader\DR_VolFog_TppTonemap.shdr"
	NFetchExposuredLAccSpecular_fetchLAccSpecular_inTexcoord = NScreenToTextureCoordinate_screenToTexcoord_outTexcoord;
	NFetchExposuredLAccSpecular(inLightSpecular, NFetchExposuredLAccSpecular_fetchLAccSpecular_inTexcoord, NFetchExposuredLAccSpecular_fetchLAccSpecular_outColor);


	float2	NFetchExposuredLAccDiffuse_fetchLAccDiffuse_inTexcoord;
	half3 NFetchExposuredLAccDiffuse_fetchLAccDiffuse_outColor;
#line 83 "shader\DR_VolFog_TppTonemap.shdr"
	NFetchExposuredLAccDiffuse_fetchLAccDiffuse_inTexcoord = NScreenToTextureCoordinate_screenToTexcoord_outTexcoord;
	NFetchExposuredLAccDiffuse(inLightDiffuse, NFetchExposuredLAccDiffuse_fetchLAccDiffuse_inTexcoord, NFetchExposuredLAccDiffuse_fetchLAccDiffuse_outColor);


	half3	NCalculateColor_calculateColor_inLightDiffuse;
	half3	NCalculateColor_calculateColor_inLightSpecular;
	float2	NCalculateColor_calculateColor_inTexcoord;
	half3 NCalculateColor_calculateColor_outColor;
#line 87 "shader\DR_VolFog_TppTonemap.shdr"
	NCalculateColor_calculateColor_inLightDiffuse = NFetchExposuredLAccDiffuse_fetchLAccDiffuse_outColor;
#line 88 "shader\DR_VolFog_TppTonemap.shdr"
	NCalculateColor_calculateColor_inLightSpecular = NFetchExposuredLAccSpecular_fetchLAccSpecular_outColor;
#line 89 "shader\DR_VolFog_TppTonemap.shdr"
	NCalculateColor_calculateColor_inTexcoord = NScreenToTextureCoordinate_screenToTexcoord_outTexcoord;
	NCalculateColor(NCalculateColor_calculateColor_inLightDiffuse, NCalculateColor_calculateColor_inLightSpecular, NCalculateColor_calculateColor_inTexcoord, inAlbedo, inOcclusion, NCalculateColor_calculateColor_outColor);


	half3	NApplyVolFog_applyFog_inColor;
	half2	NApplyVolFog_applyFog_inClipPos;
	float3	NApplyVolFog_applyFog_inViewPos;
	half3 NApplyVolFog_applyFog_outColor;
#line 94 "shader\DR_VolFog_TppTonemap.shdr"
	NApplyVolFog_applyFog_inColor = NCalculateColor_calculateColor_outColor.xyz;
#line 95 "shader\DR_VolFog_TppTonemap.shdr"
	NApplyVolFog_applyFog_inClipPos = (half2)inTexcoord; NApplyVolFog_applyFog_inClipPos.y *= -1;
#line 96 "shader\DR_VolFog_TppTonemap.shdr"
	NApplyVolFog_applyFog_inViewPos = NFetchViewZ_fetchViewPos_outViewPos.zzz;
	NApplyVolFog(NApplyVolFog_applyFog_inColor, NApplyVolFog_applyFog_inClipPos, NApplyVolFog_applyFog_inViewPos, NApplyVolFog_applyFog_outColor);


	half3	NCalcurateOutputColor2_calculateOutputColor_inColor;
	half2	NCalcurateOutputColor2_calculateOutputColor_inVPos;
	half4 NCalcurateOutputColor2_calculateOutputColor_outColor;
#line 101 "shader\DR_VolFog_TppTonemap.shdr"
	NCalcurateOutputColor2_calculateOutputColor_inColor = NApplyVolFog_applyFog_outColor;
#line 99 "shader\DR_VolFog_TppTonemap.shdr"
	NCalcurateOutputColor2_calculateOutputColor_inVPos = inVPos;
	NCalcurateOutputColor2(NCalcurateOutputColor2_calculateOutputColor_inColor, NCalcurateOutputColor2_calculateOutputColor_inVPos, inMesh, NCalcurateOutputColor2_calculateOutputColor_outColor);


#line 104 "shader\DR_VolFog_TppTonemap.shdr"
	outColor = NCalcurateOutputColor2_calculateOutputColor_outColor;



	#include "../UnityPatch/PostEntryPoint.hlsl"
}



#line 4 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"



#line 4 "..\Gr\Dg\shader\../DgShaderDefine.h"



#define _DG_SHADER_DEF_H_


#line 60 "..\Gr\Dg\shader\../DgShaderDefine.h"




#line 230 "..\Gr\Dg\shader\../DgShaderDefine.h"





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



#line 320 "..\Gr\Dg\shader\../DgShaderDefine.h"

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


#line 372 "..\Gr\Dg\shader\../DgShaderDefine.h"


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


#line 492 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 494 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 498 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 6 "..\Gr\Dg\shader\../DgShaderDefineForDx11Gen.h"


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




#line 290 "..\Gr\Dg\shader\../DgShaderDefineForDx11Gen.h"


#define TEXUNIT_VOLUMEFOG	TEXUNIT12	// DefferredShading�ȍ~����Draw2D�܂ł͎g��
#define TEXUNIT_DEPTH		TEXUNIT13
#define TEXUNIT_SHADOW		TEXUNIT14



#line 501 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_CONSTANTBUFFER


#line 507 "..\Gr\Dg\shader\../DgShaderDefine.h"

#	define PS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define VS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define REGISTERMAP(_type, _name, _register) cbuffer c##_type { static _type _name; }

#line 517 "..\Gr\Dg\shader\../DgShaderDefine.h"


#define SHINESS_NORMALIZE_MAX			256.0
#define SQRT_SHINESS_NORMALIZE_MAX		16.0


#define DG_DRAWPROJECTION_CLIPSPACE_DIRECTX	0
#define DG_DRAWPROJECTION_CLIPSPACE_OPENGL	1








#line 554 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_SPHERICAL_GAUSSIAN_FRESNLE


#line 560 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 564 "..\Gr\Dg\shader\../DgShaderDefine.h"



#line 571 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 577 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_DIRECTX

#line 581 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 586 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 588 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_1002_OPTIMIZE
#define USE_1003_OPTIMIZE


#line 595 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define NOADJUST_DIMMER			//Dimmer��ݒ肵�Ă��P���̈ʒu�̋P�x�������Ȃ��@�\�͂���Ȃ�



#line 603 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 608 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define DG_HIGH_PRECISION_LACC


#line 616 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 620 "..\Gr\Dg\shader\../DgShaderDefine.h"


#line 626 "..\Gr\Dg\shader\../DgShaderDefine.h"



#line 634 "..\Gr\Dg\shader\../DgShaderDefine.h"


#define NORMALMAP_DECODE_DIVZERO_AVOIDANCE

#line 639 "..\Gr\Dg\shader\../DgShaderDefine.h"

#define USE_3RTGBUFFER_PROFILE	//GBUFFER�R���\��


#define PRIMIRIVE_OUTPUT_MULTI_TARGET		///< �k���o�b�t�@�ƃ}�X�N�����̐����������߂�

#define DRAW2D_BORDER_OLDTYPE				///< �t�H���g�V�F�[�_�̉������ȑO�̂܂܂ɂ���i�O���ΐV�������[�h)



#line 5 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"


#line 1 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"

#define HDRBUFFER_COMMON_SHDR_


#line 2 "..\Gr\Dg\shader\shader.h"













#line 4 "..\Gr\Dg\shader\../DgShaderDefine.h"




#line 14 "..\Gr\Dg\shader\shader.h"


#define _SHADER_H_


#line 19 "..\Gr\Dg\shader\shader.h"
#define F_TARGET_WINDX11

#line 26 "..\Gr\Dg\shader\shader.h"


#line 30 "..\Gr\Dg\shader\shader.h"


#line 37 "..\Gr\Dg\shader\shader.h"


#define HALF_MIN	(-65504.0)
#define HALF_MAX	(65504.0)



#line 61 "..\Gr\Dg\shader\shader.h"



#line 74 "..\Gr\Dg\shader\shader.h"




#line 86 "..\Gr\Dg\shader\shader.h"



#line 102 "..\Gr\Dg\shader\shader.h"

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


#line 120 "..\Gr\Dg\shader\shader.h"



#line 131 "..\Gr\Dg\shader\shader.h"




#line 140 "..\Gr\Dg\shader\shader.h"

#define DG_SUPPORT_FLEXIBLE_VIEWPORT

#line 144 "..\Gr\Dg\shader\shader.h"



#line 150 "..\Gr\Dg\shader\shader.h"


#define MAX_FILTER_WIDTH   (64)
#define MAX_FILTER_HEIGHT  (64)

#line 155 "..\Gr\Dg\shader\shader.h"


#define RANDOM_TEXTURE_SIZE (32.0)
#define INV_RANDOM_TEXTURE_SIZE (1.0 / 32.0)


#define DECODING_GAMMA  (2.2)

#define ENCODING_GAMMA  (1.0/DECODING_GAMMA)





#define COLOR_ROTATION    (g_psScene.m_shadowProjection)



#define ENABLE_NONDEFERRED_DISTANCE_FADE




#define LUMINANCE_VECTOR  (half3(0.2125h, 0.7154h, 0.0721h))




#define MAX_LUMINANCE (32.0)

#line 190 "..\Gr\Dg\shader\shader.h"

#define HDR_LUM_SCALE ( 16.0h )

#line 193 "..\Gr\Dg\shader\shader.h"

#define USER_TEXCUBELOD	//���t���N�V�����v�Z��texCUBElod���g��
#define CUBEMAP_BIAS_MAX (5.0H)

#line 200 "..\Gr\Dg\shader\shader.h"

#define LIGHTSCALE_DIFFUSE_TO_SPECULAR (3.1415926H)
#define FWLIGHT_INNER_RANGE (0.5)


#line 207 "..\Gr\Dg\shader\shader.h"






#line 215 "..\Gr\Dg\shader\shader.h"




#line 228 "..\Gr\Dg\shader\shader.h"


#line 235 "..\Gr\Dg\shader\shader.h"
#define CORRECT_TANGNET_VALUE(n) {}

#line 244 "..\Gr\Dg\shader\shader.h"
#define CORRECT_CLONE_TANGNET_VALUE(n) {}

#line 247 "..\Gr\Dg\shader\shader.h"




#line 253 "..\Gr\Dg\shader\shader.h"
#define DG_ENABLE_HALFPIXELOFFSET

#line 256 "..\Gr\Dg\shader\shader.h"

#define PIXELCENTEROFFSET (-0.5)

#line 262 "..\Gr\Dg\shader\shader.h"



#line 272 "..\Gr\Dg\shader\shader.h"

#define ToVPos(wpos) (float2(wpos.x, g_psSystem.m_renderBuffer.y - wpos.y) + PIXELCENTEROFFSET)
#define ToVPos4(wpos) float4(ToVPos(wpos), 0, 0 )
#define ToWPos(vpos) (vpos + 0.5f + PIXELCENTEROFFSET)
#define ToWPos4(vpos) ToWPos(vpos)


#line 279 "..\Gr\Dg\shader\shader.h"






#line 285 "..\Gr\Dg\shader\shader.h"

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


#line 384 "..\Gr\Dg\shader\shader.h"



#line 389 "..\Gr\Dg\shader\shader.h"

half4 packFP16(float2 v)
{

	float4 _packed;





	_packed.xz = frac(256.0 * v.xy);
	_packed.yw = _packed.xz * (-1.0 / 256.0) + v.xy;

	return half4(_packed);
}



#line 409 "..\Gr\Dg\shader\shader.h"

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



#line 448 "..\Gr\Dg\shader\shader.h"

inline half4 WriteSpecularAndVelocity(half2 inSpecular, half2 inVelocity)
{
	half4 outColor;
	outColor.xy = inSpecular;
	outColor.zw = inVelocity;
	return outColor;
}



#line 459 "..\Gr\Dg\shader\shader.h"

inline half2 ReadSpecular(half4 inColor)
{
	return inColor.xy;
}



#line 467 "..\Gr\Dg\shader\shader.h"

inline half2 ReadVelocity(half4 inColor)
{
	return inColor.zw;
}



#line 475 "..\Gr\Dg\shader\shader.h"

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



#line 501 "..\Gr\Dg\shader\shader.h"

float CalcGlobalVolumetricFogDensity(float3 cameraToWorldPos, float globalDensity, float heightFallOff, float volumetricFogHeightDensityAtViewer)
{

	float fogInt = length(cameraToWorldPos) * volumetricFogHeightDensityAtViewer;



	float t = max(heightFallOff * cameraToWorldPos.y, 0.00001);



	fogInt *= (1.0f - exp(-t)) / t;


	return exp(-globalDensity * fogInt);
}



#line 525 "..\Gr\Dg\shader\shader.h"


#line 529 "..\Gr\Dg\shader\shader.h"
half GetFresnelSpecularFactor(half3 halfDir, half3 lightDir, half f0)
{

	half cosValue = half(saturate(dot(halfDir, lightDir)));
	return f0 + (1.0H - f0) * (half)exp2((-5.55473h * cosValue - 6.98316h) * cosValue);

#line 538 "..\Gr\Dg\shader\shader.h"
}

#line 541 "..\Gr\Dg\shader\shader.h"



#line 547 "..\Gr\Dg\shader\shader.h"

half AdjustLightSizeFromDistance(half size, float dist)
{








	return (half)saturate(size * 1.0H / dist * 0.9);
}





#line 572 "..\Gr\Dg\shader\shader.h"

half3 GetReflectionWithRoughness(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, half raghnessRate, TMatrix4x4 mat)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	half4 ref_vec2;
	ref_vec2.xyz = (half3) ApplyMatrixT(mat, refVec.xyz);
	ref_vec2 = half4 (ref_vec2.xyz, lerp(0, CUBEMAP_BIAS_MAX, 1 - raghnessRate));


	return (half3)TFetchCubeLod(refTex, SamplerLinear, ref_vec2).xyz;

#line 586 "..\Gr\Dg\shader\shader.h"
}



#line 597 "..\Gr\Dg\shader\shader.h"

half3 GetReflection(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, TMatrix4x4 mat)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	refVec.xyz = (half3) ApplyMatrixT(mat, refVec.xyz);


	return (half3)TFetchCube(refTex, SamplerLinear, refVec).xyz;
}



#line 615 "..\Gr\Dg\shader\shader.h"

half3 GetReflectionWithRoughness_World(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec, half raghnessRate)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);
	half4 ref_vec2 = half4 (refVec.xyz, lerp(0, CUBEMAP_BIAS_MAX, 1 - raghnessRate));


	return (half3)TFetchCubeLod(refTex, SamplerLinear, ref_vec2).xyz;

#line 627 "..\Gr\Dg\shader\shader.h"
}



#line 637 "..\Gr\Dg\shader\shader.h"

half3 GetReflection_World(out half3 refVec, TextureCube refTex, half3 viewVec, half3 normalVec)
{
	refVec = (half3) reflect(viewVec.xyz, normalVec.xyz);


	return (half3)TFetchCube(refTex, SamplerLinear, refVec).xyz;
}



#line 654 "..\Gr\Dg\shader\shader.h"

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



#line 683 "..\Gr\Dg\shader\shader.h"

half3 GetBlendColor_Overlay(half3 baseColor, half3 layerColor, half blendRate)
{
	half3 color0 = baseColor.xyz * layerColor.xyz * 2;
	half3 color1 = 1.0H - (1.0H - baseColor.xyz) * (1.0H - layerColor.xyz) * 2;
	half3 outColor = select(baseColor - 0.5H, color0, color1);

	return (half3) lerp(baseColor.xyz, outColor, blendRate);
}



#line 698 "..\Gr\Dg\shader\shader.h"

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



#line 776 "..\Gr\Dg\shader\shader.h"

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



#line 834 "..\Gr\Dg\shader\shader.h"

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


#line 848 "..\Gr\Dg\shader\shader.h"


#line 5 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 1 "..\Gr\Dg\shader\hdrColor.h"
#define HDR_COLOR_H


#line 6 "..\Gr\Dg\shader\hdrColor.h"




#line 12 "..\Gr\Dg\shader\hdrColor.h"

half4 EncodeHDRColor(half3 color)
{
	half4	encodeColor;


	encodeColor.xyz = color.xyz;


	encodeColor.w = dot(color.xyz, LUMINANCE_VECTOR * (1.0h / HDR_LUM_SCALE));

	return encodeColor;
}



#line 30 "..\Gr\Dg\shader\hdrColor.h"

half3 DecodeHDRColor(half4 encodeColor)
{
	half	scale;
	half3	color;


	scale = max(1.0h, encodeColor.w * HDR_LUM_SCALE);
	color.xyz = encodeColor.xyz * scale;

	return color;
}


#line 6 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 4 "..\Gr\Dg\shader\AliasHDRColor.h"

#define ALIAS_HDR_COLOR_H_


#line 2 "..\Gr\Dg\shader\shader.h"













#line 4 "..\Gr\Dg\shader\../DgShaderDefine.h"




#line 14 "..\Gr\Dg\shader\shader.h"



#line 848 "..\Gr\Dg\shader\shader.h"


#line 8 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 4 "..\Gr\Dg\shader\GammaTransformation.h"

#define _GAMMA_TRANSFORMATION_H_


#line 11 "..\Gr\Dg\shader\GammaTransformation.h"

half3 GammaCorrection(float3 linearRGB)
{

#line 24 "..\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(linearRGB, 0.0031308);
	return (half3)((mask * (linearRGB * 12.92)) + ((1 - mask) * (1.055 * pow(max(linearRGB, 0.00001), (1.0 / 2.4)) - 0.055)));
}



#line 35 "..\Gr\Dg\shader\GammaTransformation.h"

float3 GammaDecode(float3 inSRGB)
{

#line 48 "..\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(inSRGB, 0.03928);
	return (half3)(mask * (inSRGB / 12.92)) + ((1 - mask) * (pow(max((inSRGB + 0.055) / 1.055, 0.00001), 2.4)));
}



#line 59 "..\Gr\Dg\shader\GammaTransformation.h"

float GammaDecodeF(float f)
{
	float linear_f;
	linear_f = ((f <= 0.03928) ? f / 12.92 : pow(abs((f + 0.055) / 1.055), 2.4));
	return linear_f;
}


#line 9 "..\Gr\Dg\shader\AliasHDRColor.h"



#line 95 "..\Gr\Dg\shader\AliasHDRColor.h"

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


#line 214 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 259 "..\Gr\Dg\shader\AliasHDRColor.h"




#line 265 "..\Gr\Dg\shader\AliasHDRColor.h"

half4 EncodeAliasHDRColor(half3 color)
{

#line 269 "..\Gr\Dg\shader\AliasHDRColor.h"
	return half4(color.xyz, 1.0h);

#line 278 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 289 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 300 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 304 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 334 "..\Gr\Dg\shader\AliasHDRColor.h"
}



#line 341 "..\Gr\Dg\shader\AliasHDRColor.h"

half3 DecodeAliasHDRColor(half4 encodedColor)
{

#line 345 "..\Gr\Dg\shader\AliasHDRColor.h"


	return encodedColor.xyz;

#line 354 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 356 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 369 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 381 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 387 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 419 "..\Gr\Dg\shader\AliasHDRColor.h"
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



#line 7 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 9 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"
#define HDRBUF_ENCODE_DIFFUSE	EncodeAliasHDRColor
#define HDRBUF_DECODE_DIFFUSE	DecodeAliasHDRColor
#define HDRBUF_ENCODE_SPECULAR	EncodeAliasHDRColor
#define HDRBUF_DECODE_SPECULAR	DecodeAliasHDRColor

#line 21 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 35 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 49 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 63 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 77 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"

#define SamplerGBuffer SamplerPoint



#line 85 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 99 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 105 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 152 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 159 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 216 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"






#line 278 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 285 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 311 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 317 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 331 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 337 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 351 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 358 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 386 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 413 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 420 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 447 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 453 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 466 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"




#line 473 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 487 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"



#line 7 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"


#define SH_BLEND_AND_ENCODE

Texture2D g_shMaskTex : TEXUNIT1;


#line 89 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"





#line 4 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"




#line 4 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"





#line 4 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#define USE_SHRINKSHADER

















#define SHINESS_NORMALIZE_NEWLIMIT  // 2012.10.23 Specular正規化の式を変更





#define MORE_FAST_SPECULAR


#define DISABLE_DIMMER


#line 2 "..\Gr\Dg\shader\shader.h"













#line 4 "..\Gr\Dg\shader\../DgShaderDefine.h"




#line 14 "..\Gr\Dg\shader\shader.h"



#line 848 "..\Gr\Dg\shader\shader.h"


#line 35 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 4 "..\Gr\Dg\shader\CoordinateCalculation.h"


#define NEW_VIEWPOS_RECONSTRUCT_CALC



#define ENCODE_NORMAL					// XY�̐��K���AZ��sqrt���Ƃ��





#line 19 "..\Gr\Dg\shader\CoordinateCalculation.h"




#line 25 "..\Gr\Dg\shader\CoordinateCalculation.h"

half4 EncodeViewSpaceNormal(half3 normal)
{
	half4	encodeNormal = 0.0;

#line 30 "..\Gr\Dg\shader\CoordinateCalculation.h"

	encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
	encodeNormal.z = half(sqrt(half(normal.z) * 0.5h + 0.5h));

#line 45 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 51 "..\Gr\Dg\shader\CoordinateCalculation.h"

	return encodeNormal;
}



#line 88 "..\Gr\Dg\shader\CoordinateCalculation.h"





#line 96 "..\Gr\Dg\shader\CoordinateCalculation.h"

half3 DecodeViewSpaceNormal(half4 encodeNormal)
{

#line 107 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 116 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 127 "..\Gr\Dg\shader\CoordinateCalculation.h"
	float bias = 1.0e-007f;

#line 131 "..\Gr\Dg\shader\CoordinateCalculation.h"
	half3	viewSpaceNormal;
	viewSpaceNormal.xy = encodeNormal.xy * 2.0h - 1.0h;
	viewSpaceNormal.z = (encodeNormal.z * encodeNormal.z) * 2.0h - 1.0h;
	half	oneMinusZz = 1.0h - viewSpaceNormal.z * viewSpaceNormal.z;
	viewSpaceNormal.xy = (viewSpaceNormal.xy * oneMinusZz) * (half)rsqrt(oneMinusZz * (half)dot(viewSpaceNormal.xy, viewSpaceNormal.xy) + bias);

#line 139 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 145 "..\Gr\Dg\shader\CoordinateCalculation.h"
	return half3(viewSpaceNormal);
}



#line 154 "..\Gr\Dg\shader\CoordinateCalculation.h"

half3 ReconstructViewSpaceNormal(Texture2D normals, float2 uv)
{

	return DecodeViewSpaceNormal(TFetch2DLodH(normals, SamplerPointClamp, float4(uv, 0, 0)));
}

half3 ReconstructViewSpaceNormalWithSampler(Texture2D normals, SamplerState samplerstate, float2 uv)
{

	return DecodeViewSpaceNormal(TFetch2DH(normals, samplerstate, uv));
}




#line 188 "..\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 DecodeNormalTexture(half4 color)
{
	half3	normal;


#line 196 "..\Gr\Dg\shader\CoordinateCalculation.h"



#line 201 "..\Gr\Dg\shader\CoordinateCalculation.h"
	normal.xyz = half3(color.agb) * 2.0h - 1.0h;





	half tmp = half(saturate(1.0h - normal.x * normal.x - normal.y * normal.y) + 0.0001h);

#line 213 "..\Gr\Dg\shader\CoordinateCalculation.h"
	normal.z = half(tmp * rsqrt(tmp));


	return normal;
}



#line 227 "..\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromTextureWithSampler(Texture2D tex, SamplerState samplerstate, float2 uv)
{
	return DecodeNormalTexture(TFetch2DH(tex, samplerstate, uv));
}



#line 238 "..\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromTexture(Texture2D tex, float2 uv)
{
	return DecodeNormalTexture(TFetch2DH(tex, SamplerLinear, uv));
}





#line 251 "..\Gr\Dg\shader\CoordinateCalculation.h"

inline half3 GetNormalFromArrayTexture(Texture3D tex, float3 texcoord)
{
	return DecodeNormalTexture(TFetch3DH(tex, SamplerLinear, texcoord));
}


#line 269 "..\Gr\Dg\shader\CoordinateCalculation.h"






#line 278 "..\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPos(float4 clipSpacePos, float4 proj)
{
	float3 viewPos;


#line 288 "..\Gr\Dg\shader\CoordinateCalculation.h"
	viewPos.z = proj.z / (clipSpacePos.z - proj.w);
	viewPos.xy = (clipSpacePos.xy * proj.xy) * viewPos.z;

#line 292 "..\Gr\Dg\shader\CoordinateCalculation.h"

	return float4(viewPos, 1);
}



#line 303 "..\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPosFromTexture(Texture2D inDepth, half2 inTexCoord, float2 clipSpacePosXY, float4 inProjectionParam)
{

#line 329 "..\Gr\Dg\shader\CoordinateCalculation.h"
	float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, half4(inTexCoord, 0, 0)).x;

#line 335 "..\Gr\Dg\shader\CoordinateCalculation.h"

	return ReconstructViewPos(float4(clipSpacePosXY, zOverW, 1), inProjectionParam);
}



#line 347 "..\Gr\Dg\shader\CoordinateCalculation.h"

float4 ReconstructViewPos2(float2 inScreenSpacePos, float inDepth, float4 inProjectionParam)
{

#line 356 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 366 "..\Gr\Dg\shader\CoordinateCalculation.h"
	float3	viewPos;
	viewPos.xy = inScreenSpacePos.xy * inProjectionParam.xy;
	viewPos.z = inProjectionParam.z / (inDepth - inProjectionParam.w);

#line 374 "..\Gr\Dg\shader\CoordinateCalculation.h"
	viewPos.xy = viewPos.xy * viewPos.z;
	return float4(viewPos.xyz, 1);
}



#line 385 "..\Gr\Dg\shader\CoordinateCalculation.h"

float ReconstructViewZ(float zOverW, float4 proj)
{

#line 394 "..\Gr\Dg\shader\CoordinateCalculation.h"


#line 397 "..\Gr\Dg\shader\CoordinateCalculation.h"
	return (proj.z / (zOverW - proj.w));
}



#line 408 "..\Gr\Dg\shader\CoordinateCalculation.h"

float ReconstructViewZFromTexture(Texture2D inDepth, float2 inTexCoord, float4 projectionParameter)
{

#line 425 "..\Gr\Dg\shader\CoordinateCalculation.h"
	float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)).x;

#line 431 "..\Gr\Dg\shader\CoordinateCalculation.h"
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

#line 467 "..\Gr\Dg\shader\CoordinateCalculation.h"
	float4 fetchDepth = TFetch2D(inDepth, SamplerPointClamp, inTexCoord);

#line 472 "..\Gr\Dg\shader\CoordinateCalculation.h"
	depth.viewZ = ReconstructViewZ(fetchDepth.x, projectionParameter);

	{

#line 480 "..\Gr\Dg\shader\CoordinateCalculation.h"
		depth.viewZSub = ReconstructViewZ(fetchDepth.y, projectionParameter);
	}

#line 484 "..\Gr\Dg\shader\CoordinateCalculation.h"
}

#line 36 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 4 "..\Gr\Dg\shader\AliasHDRColor.h"


#line 42 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 1 "..\Gr\Dg\shader\HDRBuffer_Common.shdr"


#line 44 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 48 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 53 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 84 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 86 "..\Gr\Dg\shader\SSLighting_Common.shdr"

REGISTERMAP(PSScene, g_psScene, PS_REGISTER(SCENE));
REGISTERMAP(PSObject, g_psObject, PS_REGISTER(OBJECT));
REGISTERMAP(PSLight, g_psLight, PS_REGISTER(LIGHT));
REGISTERMAP(PSMaterial, g_psMaterial, PS_REGISTER(MATERIAL));
REGISTERMAP(PSSystem, g_psSystem, PS_REGISTER(SYSTEM));

#line 95 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 104 "..\Gr\Dg\shader\SSLighting_Common.shdr"
VSScene			g_vsScene;
VSObject		g_vsObject;
VSLight			g_vsLight;
VSMaterial		g_vsMaterial;
VSWork			g_vsWork;

#line 111 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 114 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 1 "..\Gr\Dg\shader\shadowDefine.h"







#line 13 "..\Gr\Dg\shader\shadowDefine.h"



#line 22 "..\Gr\Dg\shader\shadowDefine.h"




#line 32 "..\Gr\Dg\shader\shadowDefine.h"



#line 41 "..\Gr\Dg\shader\shadowDefine.h"

#define MAX_CASCADE_BLOCKS (4)

#define SHADOW_SUN_SIZE		g_psScene.m_shadowMapResolutions.x
#define SHADOW_CAST1_SIZE 	g_psScene.m_shadowMapResolutions.y
#define SHADOW_CAST2_WIDTH	g_psScene.m_shadowMapResolutions.z
#define SHADOW_CAST2_HEIGHT	g_psScene.m_shadowMapResolutions.w

#line 58 "..\Gr\Dg\shader\shadowDefine.h"



#line 67 "..\Gr\Dg\shader\shadowDefine.h"



#line 117 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 7 "..\Gr\Dg\shader\ShadowCommon.h"


#define SHADOWCOMMON_H_

Texture2D g_RandomTexture		: TEXUNIT12;


float4 CalcCascadeShadowUVArea(float4x4 shadowParams, float4 view_pos, float4 projection_pos, float4 CascadePlanes[9])
{
	half   shadowDepth = (half)GetElement(shadowParams, 3, 0);
	float4 shadow_uv;

	half3 j1 = half3((half)(dot(view_pos, CascadePlanes[0])), (half)(dot(view_pos, CascadePlanes[1])), (half)(dot(view_pos, CascadePlanes[2])));
	half3 j2 = half3((half)(dot(view_pos, CascadePlanes[3])), (half)(dot(view_pos, CascadePlanes[4])), (half)(dot(view_pos, CascadePlanes[5])));
	half3 j3 = half3((half)(dot(view_pos, CascadePlanes[6])), (half)(dot(view_pos, CascadePlanes[7])), (half)(dot(view_pos, CascadePlanes[8])));
	j1 = 1.0h - (half3)(step(0.99h, abs(j1)));
	j2 = 1.0h - (half3)(step(0.99h, abs(j2)));
	j3 = 1.0h - (half3)(step(0.99h, abs(j3)));
	half3 mask = half3(j1.x * j1.y * j1.z, j2.x * j2.y * j2.z, j3.x * j3.y * j3.z);

	half4 final_mask = half4(mask.x, mask.y * (1 - mask.x), mask.z * (1 - mask.y), 1 - step(1, mask.x + mask.y + mask.z));
	float4	scale_vec;
	scale_vec = ApplyMatrixT(shadowParams, float4((float3)final_mask.yzw, 0));
	scale_vec.w += (float)(1.0h * final_mask.x);
	shadow_uv.xyz = (projection_pos.xyz * scale_vec.w) + scale_vec.xyz;
	shadow_uv.z = (shadow_uv.z + 1.0) * shadowDepth;

	shadow_uv.xy = shadow_uv.xy * 0.5f + 0.5f;
	shadow_uv.y = 1.0f - shadow_uv.y;

	shadow_uv.xy *= 0.5f;
	const half4x4 cascadeOffset = {
		0,0.5h,    0,0.5h,
		0,0    ,0.5h,0.5h,
		0,0,        0,     0,
		0,0,        0,     0,
	};
	half2 selectedOffset = (half2)ApplyMatrixT(cascadeOffset, final_mask.xyzw);
	shadow_uv.xy += (half2)selectedOffset;
	shadow_uv.w = 1;
	return shadow_uv;
}



#line 57 "..\Gr\Dg\shader\ShadowCommon.h"

float4 CalcCascadeShadowUV(float4x4 shadowParams, float4 projection_pos, float invRangeIntervalLog)
{
	float  shadowDepth = GetElement(shadowParams, 3, 0);

#line 91 "..\Gr\Dg\shader\ShadowCommon.h"

	const float   SHADOW_TEXTURE_UV_AREA = pow(1.0f - ((1.0 / SHADOW_SUN_SIZE) * 4), 2);




	float4 selected_uv[4];

	selected_uv[0] = float4(projection_pos.xyz, 0);

	const float4 lv1Param = GetRowT(shadowParams, 0);
	const float4 lv2Param = GetRowT(shadowParams, 1);
	const float4 lv3Param = GetRowT(shadowParams, 2);


	selected_uv[1] = float4(((projection_pos.xyz * lv1Param.w) + lv1Param.xyz), 1);
	selected_uv[2] = float4(((projection_pos.xyz * lv2Param.w) + lv2Param.xyz), 2);
	selected_uv[3] = float4(((projection_pos.xyz * lv3Param.w) + lv3Param.xyz), 3);


	selected_uv[0].z = (selected_uv[0].z + 1.0f) * shadowDepth;
	selected_uv[1].z = (selected_uv[1].z + 1.0f) * shadowDepth;
	selected_uv[2].z = (selected_uv[2].z + 1.0f) * shadowDepth;
	selected_uv[3].z = (selected_uv[3].z + 1.0f) * shadowDepth;


	half3 areaJudg1 = half3(step(selected_uv[0].xy * selected_uv[0].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[0].z));
	half3 areaJudg2 = half3(step(selected_uv[1].xy * selected_uv[1].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[1].z));
	half3 areaJudg3 = half3(step(selected_uv[2].xy * selected_uv[2].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[2].z));



	half4 mask = half4(areaJudg1.x * areaJudg1.y * areaJudg1.z,
		areaJudg2.x * areaJudg2.y * areaJudg2.z,
		areaJudg3.x * areaJudg3.y * areaJudg3.z,
		1);
	half hit = 1.0h - mask.x;
	mask.y = mask.y * hit;
	hit = hit * (1.0h - mask.y);
	mask.z = mask.z * hit;
	hit = hit * (1.0h - mask.z);
	mask.w = mask.w * hit;

	half4 result = (half4)(
		(selected_uv[0] * mask.x) +
		(selected_uv[1] * mask.y) +
		(selected_uv[2] * mask.z) +
		(selected_uv[3] * mask.w));


	result.z = max(0.000001, result.z);
	return result;
}



#line 150 "..\Gr\Dg\shader\ShadowCommon.h"

float4 CalcCascadeShadowUVWithCascadeBlend(float4x4 shadowParams, float4 projection_pos, float invRangeIntervalLog, float2 screenTexCoord)
{


	const float	SHADOW_TEXTURE_UV_AREA = 1.0f - ((1.0 / SHADOW_SUN_SIZE) * 8);
	const half SHADOW_TEXTURE_UV_AREA_RANDOM_LV0 = (half)(SHADOW_TEXTURE_UV_AREA * SHADOW_TEXTURE_UV_AREA);


#line 159 "..\Gr\Dg\shader\ShadowCommon.h"

	float  useCascadeBlend = GetElement(shadowParams, 3, 3);


	half SHADOW_TEXTURE_UV_AREA_RANDOM_OTH = SHADOW_TEXTURE_UV_AREA_RANDOM_LV0;
	float randomValue = 0;

	if (useCascadeBlend) {

		const half2	texCoordCenterOffset = ((half2)(TFetch2D(g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE).xy));

		const float2 INV_SHADOW_SUN_SIZE = (1.0 / SHADOW_SUN_SIZE);
		randomValue = max(texCoordCenterOffset.x, texCoordCenterOffset.y) * 0.0025f;
		SHADOW_TEXTURE_UV_AREA_RANDOM_OTH = (half)pow((SHADOW_TEXTURE_UV_AREA - ((max(texCoordCenterOffset.x, texCoordCenterOffset.y) * SHADOW_SUN_SIZE / 4.0h) * INV_SHADOW_SUN_SIZE)), 2);
	}


#line 182 "..\Gr\Dg\shader\ShadowCommon.h"


	float  shadowDepth = GetElement(shadowParams, 3, 0);


	float4 selected_uv[4];

	selected_uv[0] = float4(projection_pos.xyz, 0);


	const float4 lv1Param = GetRowT(shadowParams, 0);
	const float4 lv2Param = GetRowT(shadowParams, 1);
	const float4 lv3Param = GetRowT(shadowParams, 2);


	selected_uv[1] = float4(((projection_pos.xyz * lv1Param.w) + lv1Param.xyz), 1);
	selected_uv[2] = float4(((projection_pos.xyz * lv2Param.w) + lv2Param.xyz), 2);
	selected_uv[3] = float4(((projection_pos.xyz * lv3Param.w) + lv3Param.xyz), 3);


	selected_uv[0].z = (selected_uv[0].z + 1.0f) * shadowDepth;
	selected_uv[1].z = (selected_uv[1].z + 1.0f) * shadowDepth;
	selected_uv[2].z = (selected_uv[2].z + 1.0f) * shadowDepth;
	selected_uv[3].z = (selected_uv[3].z + 1.0f) * shadowDepth;


	half2 calcAreaUV[4];



	calcAreaUV[0] = (half2)selected_uv[0] * (half2)selected_uv[0];
	calcAreaUV[1] = (half2)selected_uv[1] * (half2)selected_uv[1];
	calcAreaUV[2] = (half2)selected_uv[2] * (half2)selected_uv[2];

#line 218 "..\Gr\Dg\shader\ShadowCommon.h"


	half3 areaJudg1 = half3(step(calcAreaUV[0], SHADOW_TEXTURE_UV_AREA_RANDOM_LV0), step(randomValue, selected_uv[0].z));
	half3 areaJudg2 = half3(step(calcAreaUV[1], SHADOW_TEXTURE_UV_AREA_RANDOM_OTH), step(randomValue, selected_uv[1].z));
	half3 areaJudg3 = half3(step(calcAreaUV[2], SHADOW_TEXTURE_UV_AREA_RANDOM_OTH), step(randomValue, selected_uv[2].z));

#line 226 "..\Gr\Dg\shader\ShadowCommon.h"


	half4 mask = half4(areaJudg1.x * areaJudg1.y * areaJudg1.z,
		areaJudg2.x * areaJudg2.y * areaJudg2.z,
		areaJudg3.x * areaJudg3.y * areaJudg3.z,

#line 233 "..\Gr\Dg\shader\ShadowCommon.h"
		1);
	half hit = 1.0h - mask.x;
	mask.y = mask.y * hit;
	hit = hit * (1.0h - mask.y);
	mask.z = mask.z * hit;
	hit = hit * (1.0h - mask.z);
	mask.w = mask.w * hit;

	half4 result = (half4)(
		(selected_uv[0] * mask.x) +
		(selected_uv[1] * mask.y) +
		(selected_uv[2] * mask.z) +
		(selected_uv[3] * mask.w));


#line 253 "..\Gr\Dg\shader\ShadowCommon.h"


	result.z = max(0.000001, result.z);
	return result;
}



#line 266 "..\Gr\Dg\shader\ShadowCommon.h"

float4 CalcCascadeShadowUV2(float4x4 shadowParams, float4 projection_pos, float4 projectionParameter)
{
	float4	shadow_uv = projection_pos;


	float depth_scale = GetElement(shadowParams, 3, 0);

	shadow_uv.z = (shadow_uv.z + 1.0) * depth_scale;

	return shadow_uv;
}



#line 285 "..\Gr\Dg\shader\ShadowCommon.h"

float4 CalcParaboloidShadowUV(float4 lightParams, float4 view_pos)
{


	float range_inv = lightParams.z;

	float4 position = view_pos;

	position = position / position.w;

	float isBack = (position.z <= 0.0) ? -1.0 : 1.0;
	position.z *= isBack;
	float len = length(position.xyz);
	position.xyz = position.xyz / len;

	position.z = position.z + 1;
	position.xy = position.xy / position.z;

	float w = SHADOW_CAST2_WIDTH / 2.0;
	float h = SHADOW_CAST2_HEIGHT;
	position.xy *= float2((w - 2.0) / w, (h - 2.0) / h);



	position.z = len * range_inv;
	position.z = 1 - position.z;


#line 316 "..\Gr\Dg\shader\ShadowCommon.h"

	position.w = isBack;

	return position;
}




#line 327 "..\Gr\Dg\shader\ShadowCommon.h"


float ShadowComparisonFiltered(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float attenuation = 1.0)
{


#line 341 "..\Gr\Dg\shader\ShadowCommon.h"

	float shadow;


#line 376 "..\Gr\Dg\shader\ShadowCommon.h"

	shadow = TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, texCoord.xyzw).x;

#line 388 "..\Gr\Dg\shader\ShadowCommon.h"
	shadow *= attenuation;

	shadow = 1.0 - shadow;






	shadow = shadow * shadow;

	return shadow;
}



#line 411 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonFourSampleGaussianFilterWithMicroDither(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	float	shadow = 0;
	float4 neighbour;
	float4	offset = float4(0.5, 0.5, -0.5, -0.5);
	float2	ditherOffset2x2 = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
	offset += ditherOffset2x2.xyxy * 0.125;
	offset *= texCoord.wwww / shadowMapSize.xyxy;

	neighbour = texCoord;
	neighbour.xy += offset.xy;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	neighbour = texCoord;
	neighbour.xy += offset.zy;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	neighbour = texCoord;
	neighbour.xy += offset.xw;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	neighbour = texCoord;
	neighbour.xy += offset.zw;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	shadow *= 1.0 / 4.0;

	shadow = 1.0 - shadow * attenuation;
	shadow = shadow * shadow;

	return (half)shadow;
}


#line 451 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonTwoSampleWithDitherGaussianFilter(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{

	float2	ditherOffset2x2 = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
	float2	offset = float2(0.5, 0.5) * ditherOffset2x2.xy / shadowMapSize;
	float	shadow = 0;
	float4 neighbour;

	neighbour = texCoord;
	neighbour.xy += offset.xy * texCoord.w;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	neighbour = texCoord;
	neighbour.xy -= offset.xy * texCoord.w;
	shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

	shadow *= 1.0 / (float)2;

	shadow = 1.0 - shadow * attenuation;
	shadow = shadow * shadow;

	return (half)shadow;
}



#line 479 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonFilteredDither(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{

#line 485 "..\Gr\Dg\shader\ShadowCommon.h"
	const half2	ditherOffsetScale = half2(0.25 / shadowMapSize.xy);
	const half2	ditherOffsetOffset = half2(-0.5 * 0.25 / shadowMapSize.xy);
	half2 texCoordCenterOffset = TFetch2DH(g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE).xy * ditherOffsetScale + ditherOffsetOffset;
	float4	texCoord = baseTexCoord + float4(texCoordCenterOffset, 0, 0) * baseTexCoord.w;
	half shadow = (half)ShadowComparisonFiltered(shadowMap, texCoord, shadowMapSize, attenuation);
	return shadow;
}



#line 498 "..\Gr\Dg\shader\ShadowCommon.h"


half GetShadowComparison(Texture2D shadowMap, float4 texCoord)
{
	return (half)TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, texCoord.xyzw).x;

#line 523 "..\Gr\Dg\shader\ShadowCommon.h"
}

float ShadowComparisonFilteredRandomFetchFast(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	half4 rand = TFetch2DH(g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE);
	half2 texCoordCenterOffset = ((half2)(rand.xy) - 0.5h) * 0.35h / (half2)shadowMapSize;
	texCoord += float4(texCoordCenterOffset, 0.0, 0.0) * texCoord.w;

	half rotOffset = 3.1415926 * rand.z;

	float2 uv;
	float shadow = GetShadowComparison(shadowMap, texCoord.xyzw).x;


	for (int j = 0; j < 1; j++) {
		float4 neighbour = texCoord;
		sincos(3.1415926 / 1 * j + rotOffset, uv.x, uv.y);
		neighbour.xy += uv.xy / shadowMapSize * texCoord.w;
		shadow += GetShadowComparison(shadowMap, neighbour.xyzw).x;
	}
	shadow *= (1.0 / 2.0);

	shadow = 1.0 - shadow * attenuation;
	shadow = shadow * shadow;

	return shadow;
}

float ShadowComparisonFilteredRandomFetch(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{

	return ShadowComparisonFourSampleGaussianFilterWithMicroDither(shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation);

#line 580 "..\Gr\Dg\shader\ShadowCommon.h"
}




#line 587 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonFilteredGaussian(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float attenuation = 1.0)
{

#line 634 "..\Gr\Dg\shader\ShadowCommon.h"

#define NUM_SAMPLES (4)
	float2 invShadowMapSize = (1.0 / shadowMapSize);
	float4 offsetPixelSize = float4((invShadowMapSize * 0.3).xx, 0, 0);

	half shadow;
	shadow = TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(-1, -1, 0, 0))).x;
	shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(1, -1, 0, 0))).x;
	shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(-1, 1, 0, 0))).x;
	shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(1, 1, 0, 0))).x;

	shadow *= (half)attenuation;


	shadow = (1.0h - (shadow * (half)(1.0 / NUM_SAMPLES)));







	shadow = shadow * shadow;

#line 659 "..\Gr\Dg\shader\ShadowCommon.h"

	return shadow;
}



#line 666 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonFilteredGaussianWithDitherForSun(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	const float2 INV_SHADOW_SUN_SIZE = (1.0 / SHADOW_SUN_SIZE);


#line 679 "..\Gr\Dg\shader\ShadowCommon.h"

	float2	ditherOffset = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
	float4 texcoord = float4((baseTexCoord.xy + ditherOffset * 0.125 * INV_SHADOW_SUN_SIZE), baseTexCoord.zw);

	return ShadowComparisonFilteredGaussian(shadowMap, texcoord, float2(SHADOW_SUN_SIZE, SHADOW_SUN_SIZE), attenuation);
}

half ShadowComparisonFilteredGaussianWithDitherForPointSpot(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	const float2 INV_SHADOW_SIZE = (1.0 / shadowMapSize);


#line 696 "..\Gr\Dg\shader\ShadowCommon.h"

	float2	ditherOffset = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
	float4 texcoord = baseTexCoord.xyzw /= baseTexCoord.w;
	texcoord = float4((texcoord.xy + ditherOffset * 0.125 * INV_SHADOW_SIZE), texcoord.zw);

#line 702 "..\Gr\Dg\shader\ShadowCommon.h"

	return ShadowComparisonFilteredGaussian(shadowMap, texcoord, shadowMapSize, attenuation);
}




#line 711 "..\Gr\Dg\shader\ShadowCommon.h"

half ShadowComparisonFilteredSunLight(Texture2D shadowMap, float4 baseTexCoord, float2 screenTexCoord, float attenuation = 1.0)
{

	return (half)ShadowComparisonFilteredRandomFetch(shadowMap, baseTexCoord, float2(SHADOW_SUN_SIZE, SHADOW_SUN_SIZE), screenTexCoord, attenuation);


#line 723 "..\Gr\Dg\shader\ShadowCommon.h"


#line 729 "..\Gr\Dg\shader\ShadowCommon.h"


#line 735 "..\Gr\Dg\shader\ShadowCommon.h"


#line 740 "..\Gr\Dg\shader\ShadowCommon.h"


}



#line 748 "..\Gr\Dg\shader\ShadowCommon.h"

float ShadowComparisonFilteredPointLight(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	return ShadowComparisonFilteredRandomFetch(shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation);

#line 760 "..\Gr\Dg\shader\ShadowCommon.h"


#line 764 "..\Gr\Dg\shader\ShadowCommon.h"


#line 768 "..\Gr\Dg\shader\ShadowCommon.h"
}



#line 774 "..\Gr\Dg\shader\ShadowCommon.h"

float ShadowComparisonFilteredSpotLight(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	return ShadowComparisonFilteredRandomFetch(shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation);


#line 784 "..\Gr\Dg\shader\ShadowCommon.h"


#line 788 "..\Gr\Dg\shader\ShadowCommon.h"



#line 793 "..\Gr\Dg\shader\ShadowCommon.h"


#line 797 "..\Gr\Dg\shader\ShadowCommon.h"
}


#line 118 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 126 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 157 "..\Gr\Dg\shader\SSLighting_Common.shdr"






Texture2D g_NormalTexture		: TEXUNIT0;
Texture2D g_SpecularTexture		: TEXUNIT1;
Texture2D g_DepthTexture		: TEXUNIT2;
Texture2D g_ShadowTexture		: TEXUNIT3;
Texture2D g_CloudTexture		: TEXUNIT4;

#line 170 "..\Gr\Dg\shader\SSLighting_Common.shdr"
Texture2D g_MaterialTexture	: TEXUNIT10;
TextureCube g_ReflectionTexture : TEXUNIT11;
Texture2D g_SpecularTexture2  : TEXUNIT14;

#line 177 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 182 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 214 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 220 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 318 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 323 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 343 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 351 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 367 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 373 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 387 "..\Gr\Dg\shader\SSLighting_Common.shdr"



struct AddtionalLight
{
	half3	inAdditionalLightDir[7];
	half4	inAdditionalLightColor[7];
};


#line 419 "..\Gr\Dg\shader\SSLighting_Common.shdr"





#line 426 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 441 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 447 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 462 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#define H_PI (3.141592h)
#define H_INV_PI (1.0h/3.141592h)
#define NORMALIZATION_SCALE (1.0h/(8.0h * H_PI))
#define NORMALIZATION_OFFSET (2.04h/(8.0h * H_PI))
#define NORMALIZATION_FACTOR_ENCODE_SCALE (256.0h)

Texture2D g_lut0  : TEXUNIT7;
Texture2D g_lut1  : TEXUNIT9;
Texture3D g_lut2  : TEXUNIT8;

half roughnessToShinness(half roughness)
{
	return (half)exp2(-roughness * 11.0h + 12.0h);
}

half2 roughnessToShinness(half2 roughness)
{
	return (half)exp2(-roughness * 11.0h + 12.0h);
}

half lookupShinness(half roughness)
{
	half4 t = TFetch2DH(g_lut1, SamplerLinear, float2(0, roughness));
	return dot(t, half4(0, 1.0h, 1.0h / 256.0h, 0));
}

half specularErrorMask(half LN)
{
	return (half)saturate(4.0h * LN);
}


half lookupAnisoShinnessNormalizeFactor(half2 roughness)
{

#line 505 "..\Gr\Dg\shader\SSLighting_Common.shdr"
	half	factor = TFetch2DH(g_lut0, SamplerLinearClamp, roughness).y;
	return factor * factor * 4096.0h;

#line 509 "..\Gr\Dg\shader\SSLighting_Common.shdr"
}

half2 lookupAnisoShinnessNormalizeFactorAndShinness(half2 roughness)
{

#line 519 "..\Gr\Dg\shader\SSLighting_Common.shdr"
	half4 t = TFetch2DH(g_lut0, SamplerLinearClamp, roughness);

#line 526 "..\Gr\Dg\shader\SSLighting_Common.shdr"






	const half4	decodeFactor = half4(4096.0, 4096.0 * NORMALIZATION_SCALE,
		0, NORMALIZATION_OFFSET);
	half2	factor = t.xy * t.xy;
	factor = factor.xy * decodeFactor.xy + decodeFactor.zw;
	return factor.yx;

#line 539 "..\Gr\Dg\shader\SSLighting_Common.shdr"
}


half lookupFresnel(half EH, half F0)
{

#line 548 "..\Gr\Dg\shader\SSLighting_Common.shdr"
	return TFetch2DH(g_lut1, SamplerLinearClamp, float2(EH, F0)).x;
}



#line 563 "..\Gr\Dg\shader\SSLighting_Common.shdr"

half lookupSpecularPower(float HN, half roughness, half anisoRoughness)
{
	float3	uv;
	uv.x = saturate(HN);
	uv.y = roughness;
	uv.z = anisoRoughness;

	uv.xyz = uv.xyz * uv.xyz;

	float4	correctParam = float4(63.0 / 64.0, 15.0 / 16.0, 0.5 / 64.0, 0.5 / 16.0);

	uv.xyz = uv.xyz * correctParam.xyy + correctParam.zww;

#line 602 "..\Gr\Dg\shader\SSLighting_Common.shdr"
	half2	value = TFetch3DH(g_lut2, SamplerLinearClamp, uv.xyz).xy;
	value.xy = value.xy * value.xy;
	return value.x / value.y;
}

#define nosaturate(_x) _x


struct LitNoShadowIn
{
	half3 m_lightDir;
	half4 m_lightColor;
};

struct LitNoShadowConst
{
	half m_materialIndex;
	half4 m_material[2];
	half m_materialTranslucent;
	half m_f0;

	half3 m_normal;
	half3 m_eyeDir;
	half m_specularPower;
	half m_specularIntensity;
	half m_translucent;

	half3 E, N, VR;
	half2 normalizeFactorAndShinness;
	half3 K_s, K_d;
};

struct LitNoShadowOut
{
	half3 m_diffuse;
	half3 m_specular;
};


void LitNoShadowIterator(inout LitNoShadowOut Out, LitNoShadowIn litInput, LitNoShadowConst litConst)
{

	half3 E = litConst.m_eyeDir.xyz;
	half3 N = litConst.m_normal.xyz;
	half3 VR = (half3) - reflect(-E, N);
	half4 material1 = litConst.m_material[0];
	half4 material0 = litConst.m_material[1];

	const half3 SPECULER_COLOR = material1.xyz;
	const half TANSLUCENT = material1.w;
	const half F0 = material0.x;
	const half ANISO_ROUGHNESS = material0.w;

	half2 roughness = half2(litConst.m_specularPower, max(ANISO_ROUGHNESS, litConst.m_specularPower));
	half2 normalizeFactorAndShinness = lookupAnisoShinnessNormalizeFactorAndShinness(roughness);


	half3 L = litInput.m_lightDir.xyz;
	half3 H = (half3)normalize(L - E);
	half3 VRtoL = VR - L;
	half LH = (half)nosaturate(dot(H, L));
	half LN = (half)saturate(dot(L, N));


	const half SPECULAR_SIZE = litInput.m_lightColor.w;


	half F_d = 1.0h;
	half F_s = lookupFresnel(LH, F0);

	half cspec_ratio = (half)saturate(SPECULAR_SIZE / length(VRtoL));
	half LN_trans = (half)saturate(max(LN + litConst.m_translucent - LN * LN * litConst.m_translucent, litConst.m_translucent * TANSLUCENT));
	half3 L_cspec = (half3) normalize(lerp(L, VR, cspec_ratio));
	half3 H_cspec = (half3)normalize(L_cspec - E);
	float HN_cspec = saturate(dot(H_cspec, N));


#line 683 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 688 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 692 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 696 "..\Gr\Dg\shader\SSLighting_Common.shdr"

	half3 K_s = SPECULER_COLOR * litConst.m_specularIntensity;

#line 703 "..\Gr\Dg\shader\SSLighting_Common.shdr"
	half	specularPower =
		normalizeFactorAndShinness.x * F_s * (half)pow(HN_cspec, normalizeFactorAndShinness.y) * specularErrorMask(LN);
	specularPower = (half)min(specularPower,
		(half)((SQRT_SHINESS_NORMALIZE_MAX * SQRT_SHINESS_NORMALIZE_MAX + 2.04H) / (8.0H * 3.141592H)));
	half3	specular = K_s.xyz * litInput.m_lightColor.xyz * specularPower;

#line 710 "..\Gr\Dg\shader\SSLighting_Common.shdr"

	half K_d = 1.0h;
	half3 diffuse = K_d
		* LN_trans * F_d
		* litInput.m_lightColor.xyz;

	Out.m_specular += specular * LIGHTSCALE_DIFFUSE_TO_SPECULAR;
	Out.m_diffuse += diffuse;
}







#line 737 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 1140 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 1145 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 1155 "..\Gr\Dg\shader\SSLighting_Common.shdr"




#line 1160 "..\Gr\Dg\shader\SSLighting_Common.shdr"


#line 1173 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 1190 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 1206 "..\Gr\Dg\shader\SSLighting_Common.shdr"



#line 8 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"



#line 3 "..\Gr\Dg\shader\SH_SphereMap.h"



#define ENCODE_SPHEREMAP_NORMAL



#define SPHEREMAP_PIXEL_SIZE (1.0/256.0)
#define SPHEREMAP_HALF_SIZE (8.0)




half2 GetSphereMapUV(half2 clipCoord, half2 InvUnitPerSide)
{



#line 23 "..\Gr\Dg\shader\SH_SphereMap.h"
	const half	areaCorrectScale = 0.8125h;
	clipCoord.xy = clipCoord.xy * (areaCorrectScale * 0.5h) + 0.5h;

	return clipCoord * InvUnitPerSide;
}

float2 GetRefSphereMapUV(float2 clipCoord, float2 InvUnitPerSide)
{


	const float areaCorrectScale = 1.0f - (4.0f / 128.0f);
	clipCoord.xy = clipCoord.xy * areaCorrectScale * 0.5f + 0.5f;
	return clipCoord * InvUnitPerSide;
}



half2 GetClipCoord(half3 normal)
{
	half2 clipCoord;


#line 47 "..\Gr\Dg\shader\SH_SphereMap.h"
	float square_r = 0.5 * normal.z + 0.5;
	float r = (square_r == 0) ? 0 : sqrt(square_r);
	float len_xy = length(normal.xy);
	float2 normalize_xy = (len_xy == 0) ? float2(1, 0) : normal.xy * rcp(len_xy);
	clipCoord.xy = (half2)(-normalize_xy * r);

#line 57 "..\Gr\Dg\shader\SH_SphereMap.h"


#line 64 "..\Gr\Dg\shader\SH_SphereMap.h"

	return clipCoord;
}



float3 GetSphereMapping(float2 clipCoord)
{
	float3 normal;


	const half	areaCorrectScale = 0.8125h;
	clipCoord *= (1.0f / areaCorrectScale);


	normal.xy = float2(-clipCoord.x, clipCoord.y);
	normal.z = -sqrt(max(0, 1 - normal.x * normal.x - normal.y * normal.y));


#line 83 "..\Gr\Dg\shader\SH_SphereMap.h"

	float r2 = dot(normal.xy, normal.xy);
	normal.z = min(2 * r2 - 1, 1);
	normal.xy = normalize(normal.xy) * sqrt(1 - normal.z * normal.z);


#line 94 "..\Gr\Dg\shader\SH_SphereMap.h"

	return normal;
}

float3 GetSphereMapping2(float2 clipCoord)
{
	float3 normal;

	normal.xy = float2(-clipCoord.x, clipCoord.y);
	normal.z = -sqrt(max(0, 1 - normal.x * normal.x - normal.y * normal.y));

	normal = normalize(normal);

	return normal;
}

#line 10 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"


Texture2D g_sphericalMaps         : TEXUNIT3;

struct PSLightSH
{

	float4		m_projectionPlanes[3];
};
cbuffer PsWork	: PS_REGISTER(WORK)
{
	PSLightSH		g_psLightSH;
}

#line 34 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"



#line 55 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"

TMatrix4x4 GetExpansionMatrix(int channel, float2 weights)
{
	TMatrix4x4 m = 0;

	m[1][0] = weights.x * GetElement(g_psScene.m_shadowProjection2, 0.0h, (half)channel);
	m[2][0] = weights.x * GetElement(g_psScene.m_shadowProjection2, 3.0h, (half)channel);
	m[3][0] = dot(weights, half2(GetElement(g_psScene.m_shadowProjection, 3.0h, (half) channel), GetElement(g_psScene.m_shadowProjection2, (half) channel, 3.0h)));
	m[2][1] = weights.x * GetElement(g_psScene.m_shadowProjection2, 1.0h, (half) channel);
	m[3][1] = dot(weights, half2(GetElement(g_psScene.m_shadowProjection, 1.0h, (half) channel), g_psMaterial.m_materials[1][channel]));
	m[3][2] = dot(weights, half2(GetElement(g_psScene.m_shadowProjection, 2.0h, (half) channel), g_psMaterial.m_materials[0][channel]));


	m = m + transpose(m);


	m[0][0] = weights.x * g_psObject.m_localParam[0][channel];
	m[1][1] = -m[0][0];
	m[2][2] = 3.0 * weights.x * GetElement(g_psScene.m_shadowProjection2, 2.0h, (half) channel);
	m[3][3] = dot(weights, half2(
		GetElement(g_psScene.m_shadowProjection, 0.0h, (half) channel) - GetElement(g_psScene.m_shadowProjection2, 2.0h, (half) channel),
		GetElement(g_psScene.m_shadowProjection, (half) channel, 3.0h)));

	return m;
}


#line 89 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"



#line 92 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"

half3 ReconstructSHFunction(float3 normal, float2 weights)
{

	const float4 cartesian = float4(-normal.xz, normal.y, 1);


	half red = (half)dot(cartesian, ApplyMatrixT(GetExpansionMatrix(0, weights), cartesian));
	half green = (half)dot(cartesian, ApplyMatrixT(GetExpansionMatrix(1, weights), cartesian));
	half blue = (half)dot(cartesian, ApplyMatrixT(GetExpansionMatrix(2, weights), cartesian));

	return half3(red, green, blue);

}



#line 118 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"


#line 200 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"



#line 205 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"


#line 276 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"




#line 281 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"


#line 314 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"





#line 328 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"





#line 440 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"


#line 7 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"





#line 13 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


#line 45 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"




#line 48 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


#line 68 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"






#line 82 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


#line 151 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"



#line 156 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


#line 171 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


#line 93 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"




#line 13 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"
inline void NWriteSHBlendAndEncode(half4 inColor, float2 inTexcoord, Texture2D inAccBuf, out half4 outColor)
{
#line 23 "..\Gr\Dg\shader\SSLighting_SH_SkyLight_Encode.shdr"

	half4 accumulate = TFetch2DH(inAccBuf, SamplerLinear, inTexcoord);

	half  mulMask = 1.0h - TFetch2DH(g_shMaskTex, SamplerLinear, inTexcoord).x;

#ifdef F_TARGET_PS3
	//SRGBWriteでブレンド出来ない（リニアに変換してブレンドしれくれない）ので二乗で出力してネガを軽減してみる
	accumulate.xyz = pow(accumulate.xyz, 1.428571f);
	//SphereMapに書いたものがすでに変換したものなのでここで元に戻す
	inColor.xyz = pow(inColor.xyz, 1.428571f);
#endif

#ifdef DG_SHADER_GEN_DX11
	accumulate.w = (half)saturate(accumulate.w);
#endif

	/*
		//塗りが10％を下回ったものは正規化で誤色が出る元なので打ち切りを行う
		#ifdef SH_BLENDTYPE_TRUE
		accumulate.w = accumulate.w < 0.1h ? 0.0h : accumulate.w;
		half weight = accumulate.w;
		half3 color = (weight > 0.0h)? (accumulate.xyz * (1.0h / weight)) : inColor.xyz;
		#else
		accumulate.w = accumulate.w > ((255.0h * 0.90h) / 255.0h ) ? 1.0h : accumulate.w;
		half weight = (1.0h - accumulate.w);
		half3 color = (weight > 0.0h)? (accumulate.xyz * (1.0h / weight)) : inColor.xyz;
		#endif
	*/


	half weight = (1.0h - accumulate.w);
	half3 color = (half3)lerp(inColor.xyz, accumulate.xyz, weight) * mulMask;


	/*****************************************************************************************************
	SPHER_EBUFFER		LACC変換		LACC_BUFFER(格納Format)			Platform			Comment
	---------------------------------------------------------------------------------------------------------------------------------------------------------------
	RGBA(RGBBlend/4)		無し				RGBA8(RGBE/4)						Win32			※四分の一を戻すのはDeffered最終工程
											define なし

	RGBAF16(DirectBlend) 	無し				RGBA16F(Direct)						Win32
											#define LACC_SPHERE_RGBA16F

	RGBA(RGBBlend/4)		x4				7e3(Direct)							X360
						(m_exposure.y)		#define LACC_PRECISION_7E3

	RGBA(RGBBlend/4)		x4				RGBA8(RGBM)						Ps3
						(m_exposure.y)		#define HIGHPREC_LACC
	*******************************************************************************************************/



#ifdef	LACC_PRECISION_7E3		//X360
	color *= g_psScene.m_exposure.y;
#endif

#ifdef HIGHPREC_LACC				//PS3
	color *= g_psScene.m_exposure.y;
#endif





	outColor = HDRBUF_ENCODE_DIFFUSE(color);

}



#line 184 "..\Gr\Dg\shader\SSLighting_Common.shdr"
inline void NScreenToTextureCoordinate(half2 inPixelPosition, float4 inBackBufferSamplingPosition, out float2 outTexcoord)
{
#line 193 "..\Gr\Dg\shader\SSLighting_Common.shdr"

#if 0
	// ピクセルの真ん中になるようにUV値を補正する(Cgでは必要なくなる)
#ifdef F_TARGET_XBOX360
	outTexcoord = ((inPixelPosition.xy + g_psTiling.m_vposOffset.xy + float2(0.5, 0.5)) * g_psSystem.m_renderBuffer.zw);
#endif

#ifdef F_TARGET_XBOXONE
	outTexcoord = ((inPixelPosition.xy + half2(0.5, 0.5)) * (half2)g_psSystem.m_renderBuffer.zw);
#endif

#ifdef F_TARGET_WIN32
	outTexcoord = ((inPixelPosition.xy + half2(0.5, 0.5)) * (half2)g_psSystem.m_renderBuffer.zw);
#endif

#ifdef F_TARGET_PS3
	outTexcoord = ((inPixelPosition.xy + float2(0.5, 0.5)) * g_psSystem.m_renderBuffer.zw);
#endif
#else
	outTexcoord = inBackBufferSamplingPosition.xy / inBackBufferSamplingPosition.w;
#endif
}



#line 222 "..\Gr\Dg\shader\SSLighting_Common.shdr"
inline void NGetGeometryParam(float2 inTexcoord, out half3 outViewSpaceNormal, out half outMaterialIndex, out half outSpecularMap, out half outRoughness, out half outCalcedReflectionTh, out half outTranslucent, out float outDepth)
{
#line 236 "..\Gr\Dg\shader\SSLighting_Common.shdr"

	half4 encodeViewNormal;
	half4 specular;
	half4 specular2;

#ifdef F_TARGET_WIN32
	encodeViewNormal = TFetch2DH(g_NormalTexture, SamplerPoint, inTexcoord);
	specular = TFetch2DH(g_SpecularTexture, SamplerPoint, inTexcoord);
	specular2 = TFetch2DH(g_SpecularTexture2, SamplerPoint, inTexcoord);
	outDepth = TFetch2D(g_DepthTexture, SamplerPoint, inTexcoord).x;
#endif

#ifdef F_TARGET_XBOX360
	float texLOD = 0;
	asm {
		setTexLOD texLOD;
		tfetch2D encodeViewNormal.xyzw, inTexcoord.xy, g_NormalTexture, MinFilter = point, MagFilter = point, MipFilter = point, UseComputedLOD = false, UseRegisterLOD = true
			tfetch2D specular.xyzw, inTexcoord.xy, g_SpecularTexture, MinFilter = point, MagFilter = point, MipFilter = point, UseComputedLOD = false, UseRegisterLOD = true
			tfetch2D specular2.xyzw, inTexcoord.xy, g_SpecularTexture2, MinFilter = point, MagFilter = point, MipFilter = point, UseComputedLOD = false, UseRegisterLOD = true
			tfetch2D outDepth.x___, inTexcoord.xy, g_DepthTexture, MinFilter = point, MagFilter = point, MipFilter = point, UseComputedLOD = false, UseRegisterLOD = true
	};
#endif

#ifdef F_TARGET_XBOXONE
	encodeViewNormal = TFetch2DH(g_NormalTexture, SamplerPoint, inTexcoord);
	specular = TFetch2DH(g_SpecularTexture, SamplerPoint, inTexcoord);
	specular2 = TFetch2DH(g_SpecularTexture2, SamplerPoint, inTexcoord);
	outDepth = TFetch2D(g_DepthTexture, SamplerPoint, inTexcoord).x; // 深度
#endif

#ifdef F_TARGET_PS4
	encodeViewNormal = TFetch2DH(g_NormalTexture, SamplerPoint, inTexcoord);
	specular = TFetch2DH(g_SpecularTexture, SamplerPoint, inTexcoord);
	specular2 = TFetch2DH(g_SpecularTexture2, SamplerPoint, inTexcoord);
	outDepth = TFetch2D(g_DepthTexture, SamplerPoint, inTexcoord).x; // 深度
#endif

#ifdef F_TARGET_PS3
	encodeViewNormal = h4tex2D(g_NormalTexture, inTexcoord);
	specular = h4tex2D(g_SpecularTexture, inTexcoord);
	specular2 = h4tex2D(g_SpecularTexture2, inTexcoord);
#ifndef DEPTHTEXTURE_AS_PACKED_W
#ifdef DEPTH_RANGE_MINUSONETOONE
	outDepth = (2.0 * pack_4ubyte(h4tex2D(g_DepthTexture, inTexcoord).bgra)) - 1.0;
#else
	outDepth = pack_4ubyte(h4tex2D(g_DepthTexture, inTexcoord).bgra));
#endif
#else
	outDepth = ReconstructViewZFromTexture(g_DepthTexture, inTexcoord, g_psScene.m_projectionParam);
#endif
#endif



#ifndef USE_3RTGBUFFER_PROFILE
	outViewSpaceNormal = DecodeViewSpaceNormal(encodeViewNormal);
	outSpecularMap = specular.x;
	outMaterialIndex = specular.y;
	outRoughness = specular2.x;
	outCalcedReflectionTh = specular2.y;
	outTranslucent = specular2.z;
#else

	outViewSpaceNormal = DecodeViewSpaceNormal(encodeViewNormal);

	outCalcedReflectionTh = encodeViewNormal.w;

	outRoughness = specular.x;

	outSpecularMap = specular.y;

	outMaterialIndex = specular.z;

	outTranslucent = specular.w;
#endif


#ifdef ENABLE_GBUFF_SPEC_BLEND
	outSpecularMap = specular2.z;
	outTranslucent = specular.x;

#endif
}



#line 353 "..\Gr\Dg\shader\SSLighting_Common.shdr"
inline void NGetViewPos(float inDepth, float4 inClipSpaceXY, out float4 outViewPosition, out float3 outEyeDir)
{
#line 363 "..\Gr\Dg\shader\SSLighting_Common.shdr"


	outViewPosition = ReconstructViewPos2(((inClipSpaceXY.xy / inClipSpaceXY.w) - g_psScene.m_cameraCenterOffset.xy), inDepth, g_psScene.m_projectionParam);
	outEyeDir.xyz = (float3)normalize(outViewPosition.xyz);
}



#line 318 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
inline void NUVOffset(float2 inUV, out float2 outUV)
{
#line 325 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"

	outUV = inUV + g_psObject.m_localParam[1].xy;

}



#line 84 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"
inline void NSHLightCalculateNew(half3 inNormal, half inWeight, out half4 outDiffuse)
{
#line 103 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


	half2 clipCoord = GetClipCoord(inNormal);
	half2 uvSky = GetSphereMapUV(clipCoord.xy, (half2)g_psObject.m_localParam[0].zw);

	outDiffuse = half4(TFetch2DH(g_sphericalMaps, SamplerLinear, uvSky).xyz, inWeight);


#ifdef LIGHTCALC_REFLECTION
	//新シェーダー処理

#ifdef USE_1003_OPTIMIZE
	half index = inMaterialIndex;
	//上下逆なので注意
	half4 sampler1 = (half4) tex2Dlod(g_MaterialTexture, float4 (index, 0.25, 0, 0));
	half4 sampler0 = (half4) tex2Dlod(g_MaterialTexture, float4 (index, 0.75, 0, 0));
#else
	half index = (inMaterialIndex * 255.0H + 0.5H) / 256.0H;
	//上下逆なので注意
	half4 sampler1 = (half4) tex2D(g_MaterialTexture, float2 (index, 0.25), 1.0f / 512.0H, 1.0f / 512.0H);
	half4 sampler0 = (half4) tex2D(g_MaterialTexture, float2 (index, 0.75), 1.0f / 512.0H, 1.0f / 512.0H);
#endif

	half r = (half) ((saturate(sampler0.y - inRoughness) / max(0.001, sampler0.y)));

	half3 ref_vec;
	half3 cube = GetReflectionWithRoughness(ref_vec, g_ReflectionTexture, inEyeDir.xyz, inNormal.xyz, r, g_psScene.m_view);

	half3 halfDir = (half3) normalize(ref_vec.xyz - inEyeDir.xyz);

	//texCubeBiasが終わったら、Reflection_DependDiffuse優先でブレンド率を変更
	r = (half)lerp(r, 1.0H, sampler0.z);

	half ref_fresnel = (half)saturate(GetFresnelSpecularFactor(halfDir, ref_vec, sampler0.x)) * r;

	half3 ref_color = cube;

	half metalRate = r * sampler0.z * inSpecularIntensity.x;

	outSpecular.xyz = cube.xyz * outDiffuse.xyz * ref_fresnel * sampler1.xyz;	//金属処理+非金属処理
	outSpecular.w = inWeight;

	//Diffuseを出す
	inSpecularIntensity.x = (half)lerp(inSpecularIntensity.x, 1.0H, sampler0.z);
	metalRate = r * sampler0.z * inSpecularIntensity.x;

	outDiffuse.xyz = outDiffuse.xyz * (1 - metalRate) * (ref_color * ref_fresnel + (1 - ref_fresnel));		//非金属リフレクション処理
#endif	// ifdef LIGHTCALC_REFLECTION
}



#line 158 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"
inline void NGetSHLightParam(float3 inViewPosition, float inDepth, float4 inClipSpace, out half outWeight)
{
#line 168 "..\Gr\Dg\shader\SSLighting_SH_SkyLight.shdr"


	outWeight = 1;
}



Texture2D	NWriteSHBlendAndEncode_writeSHBlend0_inAccBuf;
Texture2D	inDiffuseAccBuf	:TEXUNIT4;
#line 332 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
void ps_main(

	in	float4	inClipSpacePosition	: TEXCOORD0,
	in	float4	inBackBufferSamplingPosition : TEXCOORD1,
	in	float4	inVPos : VPOS,
	out	half4	outDiffuse : OUT_COLOR0
)
{
	#include "../UnityPatch/PreEntryPoint.hlsl"

	inVPos = ToVPos4(inVPos);
	half2	NScreenToTextureCoordinate_screenToTextureCoordinate_inPixelPosition;
	float4	NScreenToTextureCoordinate_screenToTextureCoordinate_inBackBufferSamplingPosition;
	float2 NScreenToTextureCoordinate_screenToTextureCoordinate_outTexcoord;
#line 381 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NScreenToTextureCoordinate_screenToTextureCoordinate_inPixelPosition = (half2)inVPos.xy;
#line 383 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NScreenToTextureCoordinate_screenToTextureCoordinate_inBackBufferSamplingPosition = inBackBufferSamplingPosition;
	NScreenToTextureCoordinate(NScreenToTextureCoordinate_screenToTextureCoordinate_inPixelPosition, NScreenToTextureCoordinate_screenToTextureCoordinate_inBackBufferSamplingPosition, NScreenToTextureCoordinate_screenToTextureCoordinate_outTexcoord);


	float2	NUVOffset_makeUVOffset_inUV;
	float2 NUVOffset_makeUVOffset_outUV;
#line 389 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NUVOffset_makeUVOffset_inUV = NScreenToTextureCoordinate_screenToTextureCoordinate_outTexcoord;
	NUVOffset(NUVOffset_makeUVOffset_inUV, NUVOffset_makeUVOffset_outUV);


	float2	NGetGeometryParam_getGeometryParam_inTexcoord;
	half3 NGetGeometryParam_getGeometryParam_outViewSpaceNormal;
	half NGetGeometryParam_getGeometryParam_outMaterialIndex;
	half NGetGeometryParam_getGeometryParam_outSpecularMap;
	half NGetGeometryParam_getGeometryParam_outRoughness;
	half NGetGeometryParam_getGeometryParam_outCalcedReflectionTh;
	half NGetGeometryParam_getGeometryParam_outTranslucent;
	float NGetGeometryParam_getGeometryParam_outDepth;
#line 392 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetGeometryParam_getGeometryParam_inTexcoord = NUVOffset_makeUVOffset_outUV;
	NGetGeometryParam(NGetGeometryParam_getGeometryParam_inTexcoord, NGetGeometryParam_getGeometryParam_outViewSpaceNormal, NGetGeometryParam_getGeometryParam_outMaterialIndex, NGetGeometryParam_getGeometryParam_outSpecularMap, NGetGeometryParam_getGeometryParam_outRoughness, NGetGeometryParam_getGeometryParam_outCalcedReflectionTh, NGetGeometryParam_getGeometryParam_outTranslucent, NGetGeometryParam_getGeometryParam_outDepth);


	float	NGetViewPos_getViewPos_inDepth;
	float4	NGetViewPos_getViewPos_inClipSpaceXY;
	float4 NGetViewPos_getViewPos_outViewPosition;
	float3 NGetViewPos_getViewPos_outEyeDir;
#line 395 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetViewPos_getViewPos_inDepth = NGetGeometryParam_getGeometryParam_outDepth;
#line 396 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetViewPos_getViewPos_inClipSpaceXY = inClipSpacePosition;
	NGetViewPos(NGetViewPos_getViewPos_inDepth, NGetViewPos_getViewPos_inClipSpaceXY, NGetViewPos_getViewPos_outViewPosition, NGetViewPos_getViewPos_outEyeDir);


	float3	NGetSHLightParam_getLightParam_inViewPosition;
	float	NGetSHLightParam_getLightParam_inDepth;
	float4	NGetSHLightParam_getLightParam_inClipSpace;
	half NGetSHLightParam_getLightParam_outWeight;
#line 399 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetSHLightParam_getLightParam_inViewPosition.xyz = NGetViewPos_getViewPos_outViewPosition.xyz;
#line 400 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetSHLightParam_getLightParam_inDepth = NGetGeometryParam_getGeometryParam_outDepth;
#line 401 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NGetSHLightParam_getLightParam_inClipSpace = inClipSpacePosition;
	NGetSHLightParam(NGetSHLightParam_getLightParam_inViewPosition, NGetSHLightParam_getLightParam_inDepth, NGetSHLightParam_getLightParam_inClipSpace, NGetSHLightParam_getLightParam_outWeight);


	half3	NSHLightCalculateNew_lightCalculate_inNormal;
	half	NSHLightCalculateNew_lightCalculate_inWeight;
	half4 NSHLightCalculateNew_lightCalculate_outDiffuse;
#line 403 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NSHLightCalculateNew_lightCalculate_inNormal = NGetGeometryParam_getGeometryParam_outViewSpaceNormal;
#line 404 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NSHLightCalculateNew_lightCalculate_inWeight = NGetSHLightParam_getLightParam_outWeight;
	NSHLightCalculateNew(NSHLightCalculateNew_lightCalculate_inNormal, NSHLightCalculateNew_lightCalculate_inWeight, NSHLightCalculateNew_lightCalculate_outDiffuse);


	half4	NWriteSHBlendAndEncode_writeSHBlend0_inColor;
	float2	NWriteSHBlendAndEncode_writeSHBlend0_inTexcoord;
	half4 NWriteSHBlendAndEncode_writeSHBlend0_outColor;
#line 423 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NWriteSHBlendAndEncode_writeSHBlend0_inColor = NSHLightCalculateNew_lightCalculate_outDiffuse;
#line 424 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	NWriteSHBlendAndEncode_writeSHBlend0_inTexcoord = NScreenToTextureCoordinate_screenToTextureCoordinate_outTexcoord;
	NWriteSHBlendAndEncode(NWriteSHBlendAndEncode_writeSHBlend0_inColor, NWriteSHBlendAndEncode_writeSHBlend0_inTexcoord, inDiffuseAccBuf, NWriteSHBlendAndEncode_writeSHBlend0_outColor);


#line 435 "..\Gr\Dg\shader\SSLighting_SH_Common.shdr"
	outDiffuse = NWriteSHBlendAndEncode_writeSHBlend0_outColor;



	#include "../UnityPatch/PostEntryPoint.hlsl"
}


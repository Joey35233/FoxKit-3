/**
 * @file	Gr\Dg\DgShaderDefineForDx11Gen.h
 * @ingroup	DgShader
 *
 * @brief	Declares the dg shader define for dx 11 generate class.
**/

#ifndef _DG_SHADER_DEF_FOR_DIRECTX11_GEN_H_
#define _DG_SHADER_DEF_FOR_DIRECTX11_GEN_H_


// ----------------------------------------------------------------
// シェーダー定数バッファ定義
#define SHADER_CONSTANTBUFFER_SYSTEM		0
#define SHADER_CONSTANTBUFFER_RENDERBUFFER	1
#define SHADER_CONSTANTBUFFER_SCENE			2
#define SHADER_CONSTANTBUFFER_LIGHTS		3
#define SHADER_CONSTANTBUFFER_MATERIAL		4
#define SHADER_CONSTANTBUFFER_OBJECT		5
#define SHADER_CONSTANTBUFFER_BONES			6
#define SHADER_CONSTANTBUFFER_WORK			7

// legacy
#define SHADER_CONSTANTBUFFER_LIGHT			SHADER_CONSTANTBUFFER_LIGHTS

// --------------------------------
// システムパラメータ
struct SSystem
{
	float4		m_param;					///< wにアルファテストの閾値入れて使っている箇所があったので残しておきます
	float4		m_renderInfo;				///< 現在のビューポートサイズが入る（VPOS/WPOS変換のため）
	float4		m_renderBuffer;			///< (xy:現在レンダリング中バッファのサイズ,zw:サイズの逆数)
	float4		m_dominantLightDir;			///< 支配的な光源方向（Viewspece）
};
typedef SSystem VSSystem;
typedef SSystem PSSystem;

#define SHADER_CONST_SYSTEM_PARAM				0
#define SHADER_CONST_SYSTEM_RENDERINFO			1
#define SHADER_CONST_SYSTEM_RENDERBUFFER		2
#define SHADER_CONST_SYSTEM_DOMINANT_LIGHT_DIR	3
#define SHADER_CONSTANTBUFFER_SYSTEM_SIZE		4


// --------------------------------
// シーン固有パラメータ定数
struct SScene
{
	TMatrix4x4		m_projectionView;		///< ( 投影 x ビュー )マトリクス
	TMatrix4x4		m_projection;			///< 投影マトリクス
	TMatrix4x4		m_view;					///< ビューマトリクス
	TMatrix4x4		m_shadowProjection;		///< 影投影マトリクス
	TMatrix4x4		m_shadowProjection2;	///< 影投影マトリクス2
	float4			m_eyepos;				///< 視点座標
	float4			m_projectionParam;		///< 投影パラメータ( Z => W 変換等用 )
	float4			m_viewportSize;			///< ビューポートサイズ
	float4			m_exposure;				///< 露出関連パラメータ
	float4			m_fogParam[3];			///< フォグパラメータ
	float4			m_fogColor;				///< フォグカラー
	float4			m_cameraCenterOffset;	///< ワールド座標上でのカメラセンター
	float4			m_shadowMapResolutions;	///< シャドウマップサイズ変更用のパラメータ対応
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


// --------------------------------
// レンダーバッファ固有パラメータ定数
struct SRenderBuffer
{
	float4		m_size;						///< xy = サイズ, zw = サイズの逆数
};
typedef SRenderBuffer PSRenderBuffer;

#define SHADER_CONST_RENDERBUFFER_SIZE			0
#define SHADER_CONSTANTBUFFER_RENDERBUFFER_SIZE	1


// --------------------------------
// ライトパラメータ
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



// --------------------------------
// マテリアルパラメータ
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


// --------------------------------
// オブジェクト固有パラメータ定数
struct SObjectBase
{
	TMatrix4x4		m_viewWorld;			///< ( ビュー x ワールド )マトリクス
	TMatrix4x4		m_world;				///< ワールドマトリクス
	float4			m_useWeightCount;		///< スキニングの使用ウェイト数
};
// PSSL だと継承が通らないようなので、多重定義にする.
// SObjectBase を編集する際には注意 !!
//struct SObject : SObjectBase
struct SObject
{
	TMatrix4x4		m_viewWorld;			///< ( ビュー x ワールド )マトリクス
	TMatrix4x4		m_world;				///< ワールドマトリクス
	float4			m_useWeightCount;		///< スキニングの使用ウェイト数
	float4			m_localParam[4];		///< ローカルパラメータ(各レンダリングフェーズのローカル処理で利用)
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


// --------------------------------
// ボーンマトリクス配列
struct SBone
{
	TMatrix4x3		m_boneMatrices[32];		///< ブレンドマトリクス(3x32)
	//TMatrix4x3		m_prevBoneMatrices[32];		///< ブレンドマトリクス(3x32)
};
typedef SBone VSBone;

#define SHADER_CONST_BLENDMATRIX0				0
#define SHADER_CONST_PREV_BLENDMATRIX0			96
#define SHADER_BLENDMATRIX_SIZE					3
#define SHADER_CONSTANTBUFFER_BONE_SIZE			192


// --------------------------------
// シェーディング、ポストフィルタ、2D等でもうボーンが必要ではないので、overlapできるようにする
struct SWork
{
	TMatrix4x4		m_viewInverse;		///< viewInverse (シェーディングでよく使いまわせる）
	TMatrix4x4		m_matrix[8];		///< workMatrix[0]
};

// Make this the same size as the vertex version, but we will use it to upload a bunch of vector data
struct PSWork
{
	float4			m_vectors[36];
};
typedef SWork VSWork;

#define SHADER_CONST_VIEWINVERSE				0
#define SHADER_CONST_WORKMATRIX0				4
#define SHADER_CONSTANTBUFFER_WORK_SIZE			36


// ----------------------------------------------------------------
#ifdef __cplusplus


namespace vconst {
	enum
	{
		// システムパラメータ
		V_SYSTEMPARAM = (SHADER_CONST_SYSTEM_PARAM),
		V_RENDERINFO = (SHADER_CONST_SYSTEM_RENDERINFO),
		V_RENDERBUFFER_SIZE = (SHADER_CONST_SYSTEM_RENDERBUFFER),
		V_DOMINANTLIGHT_DIR = (SHADER_CONST_SYSTEM_DOMINANT_LIGHT_DIR),
		// シーン固有パラメータ
		M_PROJECTIONVIEW = (SHADER_CONST_PROJECTIONVIEW),
		M_PROJECTION = (SHADER_CONST_PROJECTION),
		M_VIEW = (SHADER_CONST_VIEW),
		M_SHADOWPROJECTION = (SHADER_CONST_SHADOWPROJECTION),
		M_SHADOWPROJECTION2 = (SHADER_CONST_SHADOWPROJECTION2),
		V_EYEPOS = (SHADER_CONST_EYEPOS),
		V_PROJECTIONPARAM = (SHADER_CONST_PROJECTIONPARAM),
		V_VIEWPORTSIZE = (SHADER_CONST_VIEWPORTSIZE),
		V_EXPOSURE = (SHADER_CONST_EXPOSURE),
		V_FOGPARAM0 = (SHADER_CONST_FOGPARAM0),
		V_FOGPARAM1 = (SHADER_CONST_FOGPARAM1),
		V_FOGPARAM2 = (SHADER_CONST_FOGPARAM2),
		V_FOGCOLOR = (SHADER_CONST_FOGCOLOR),
		V_CAMERACENTEROFFSET = (SHADER_CONST_CAMERACENTEROFFSET),
		V_SHADOWMAPRESOLUTIONS = (SHADER_CONST_SHADOWMAP_RESOLUTIONS),
		// レンダーバッファ固有パラメータ
		//V_RENDERBUFFER_SIZE		= (SHADER_CONST_RENDERBUFFER_SIZE),
		// ライトパラメータ
		V_LIGHTPARAM0 = (SHADER_CONST_LIGHTPARAM0),
		V_LIGHTPARAM1 = (SHADER_CONST_LIGHTPARAM1),
		V_LIGHTPARAM2 = (SHADER_CONST_LIGHTPARAM2),
		V_LIGHTPARAM3 = (SHADER_CONST_LIGHTPARAM3),
		V_LIGHTPARAM4 = (SHADER_CONST_LIGHTPARAM4),
		V_LIGHTPARAM5 = (SHADER_CONST_LIGHTPARAM5),
		V_LIGHTPARAM6 = (SHADER_CONST_LIGHTPARAM6),
		V_LIGHTPARAM7 = (SHADER_CONST_LIGHTPARAM7),
		V_LIGHTPARAM8 = (SHADER_CONST_LIGHTPARAM8),
		// マテリアルパラメータ
		V_MATERIAL0 = (SHADER_CONST_MATERIAL0),
		V_MATERIAL1 = (SHADER_CONST_MATERIAL1),
		V_MATERIAL2 = (SHADER_CONST_MATERIAL2),
		V_MATERIAL3 = (SHADER_CONST_MATERIAL3),
		V_MATERIAL4 = (SHADER_CONST_MATERIAL4),
		V_MATERIAL5 = (SHADER_CONST_MATERIAL5),
		V_MATERIAL6 = (SHADER_CONST_MATERIAL6),
		V_MATERIAL7 = (SHADER_CONST_MATERIAL7),
		// オブジェクト固有パラメータ
		M_VIEWWORLD = (SHADER_CONST_VIEWWORLD),
		M_WORLD = (SHADER_CONST_WORLD),
		V_USEWEIGHTCOUNT = (SHADER_CONST_USEWEIGHTCOUNT),
		V_LOCALPARAM0 = (SHADER_CONST_LOCALPARAM0),
		V_LOCALPARAM1 = (SHADER_CONST_LOCALPARAM1),
		V_LOCALPARAM2 = (SHADER_CONST_LOCALPARAM2),
		V_LOCALPARAM3 = (SHADER_CONST_LOCALPARAM3),
		// ボーンマトリクス配列
		M_BLENDMATRIX0 = (SHADER_CONST_BLENDMATRIX0),
		M_PREV_BLENDMATRIX0 = (SHADER_CONST_PREV_BLENDMATRIX0),
		// ワーク
		M_VIEWINVERSE = (SHADER_CONST_VIEWINVERSE),
		M_WORKMATRIX0 = (SHADER_CONST_WORKMATRIX0),
	};
}	// namespace vconst


namespace cbuf {
	enum
	{
		SYSTEM = (SHADER_CONSTANTBUFFER_SYSTEM),
		RENDERBUFFER = (SHADER_CONSTANTBUFFER_RENDERBUFFER),
		SCENE = (SHADER_CONSTANTBUFFER_SCENE),
		LIGHTS = (SHADER_CONSTANTBUFFER_LIGHTS),
		MATERIAL = (SHADER_CONSTANTBUFFER_MATERIAL),
		OBJECT = (SHADER_CONSTANTBUFFER_OBJECT),
		BONES = (SHADER_CONSTANTBUFFER_BONES),
		WORK = (SHADER_CONSTANTBUFFER_WORK),

		// legacy
		LIGHT = LIGHTS,
	};
}	// namespace cbufffer

#endif	// ifdef __cplusplus

// システム用のレジスタ
#define TEXUNIT_VOLUMEFOG	TEXUNIT12	// DefferredShading以降からDraw2Dまでは使う
#define TEXUNIT_DEPTH		TEXUNIT13
#define TEXUNIT_SHADOW		TEXUNIT14


#endif	// ifndef _DG_SHADER_DEF_FOR_DIRECTX11_GEN_H_
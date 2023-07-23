/**
	@file
	libDg / シェーダーパラメータレジスタ割り当て等
*/


#ifndef _DG_SHADER_DEF_H_
#define _DG_SHADER_DEF_H_

#ifdef __cplusplus


#include "DgConfig.h.hlsl"


// ================================================================
// C++用
typedef Matrix4			Matrix4x4 ;
typedef Matrix4			TMatrix4x4 ;
typedef Vector4			TMatrix4x3[3] ;
typedef Vector4			float4 ;

// Cgと同じ呼び方(SetTexture用）
#define TEXUNIT0	(0)
#define TEXUNIT1	(1)
#define TEXUNIT2	(2)
#define TEXUNIT3	(3)
#define TEXUNIT4	(4)
#define TEXUNIT5	(5)
#define TEXUNIT6	(6)
#define TEXUNIT7	(7)
#define TEXUNIT8	(8)
#define TEXUNIT9	(9)
#define TEXUNIT10	(10)
#define TEXUNIT11	(11)
#define TEXUNIT12	(12)
#define TEXUNIT13	(13)
#define TEXUNIT14	(14)
#define TEXUNIT15	(15)

#define SAMPLERUNIT0	(0)
#define SAMPLERUNIT1	(1)
#define SAMPLERUNIT2	(2)
#define SAMPLERUNIT3	(3)
#define SAMPLERUNIT4	(4)
#define SAMPLERUNIT5	(5)
#define SAMPLERUNIT6	(6)
#define SAMPLERUNIT7	(7)
#define SAMPLERUNIT8	(8)
#define SAMPLERUNIT9	(9)
#define SAMPLERUNIT10	(10)
#define SAMPLERUNIT11	(11)
#define SAMPLERUNIT12	(12)
#define SAMPLERUNIT13	(13)
#define SAMPLERUNIT14	(14)
#define SAMPLERUNIT15	(15)

#define SAMPLERUNIT_SYSTEM (8)

#else	// ifdef __cplusplus

// ================================================================
// HLSL <=> Cg 互換関連
#ifdef CGLANG
// ----------------------------------------------------------------
// Cg用設定

// 定数割り当てセマンティクス
#define REGISTER_C(_var)	c##_var
#define REGISTER_B(_var)	b##_var
#define REGISTER_I(_var)	i##_var
#define REGISTER_S(_var)	_var

	
// 言語非依存のマトリクス定義
typedef float4x4			Matrix4x4 ;
typedef float4x4			TMatrix4x4 ;
typedef float3x4			TMatrix4x3 ;
//typedef uint4				int4 ;			// Cgにはuint4が存在しない為
#define uint4				int4

// 現状のシェーダープリプロセッサでは配列が認識できないので、これらの型を利用します
typedef float3			TANGENT2VIEW[3] ;
typedef half3			HTANGENT2VIEW[3] ;
typedef float3			TANGENT2WORLD[3] ;
typedef half3			HTANGENT2WORLD[3] ;

#define BLENDWEIGHT		ATTR1				// CgではBLENDWEIGHTはfloat1と見なされる為
#define VPOS			WPOS				// CgにVPOSはない
#define VFACE			FACE				// CgにVFACEはない
#define OUT_COLOR		COLOR
#define OUT_COLOR0		COLOR0
#define OUT_COLOR1		COLOR1
#define OUT_COLOR2		COLOR2
#define OUT_COLOR3		COLOR3
#define OUT_DEPTH		DEPTH
#define OUT_POSITION	POSITION
#define OUT_CLIPDISTANCE0 CLP0
#define OUT_CLIPDISTANCE1 CLP1
#define OUT_CLIPDISTANCE2 CLP2
#define OUT_CLIPDISTANCE3 CLP3
#define OUT_CLIPDISTANCE4 CLP4
#define OUT_CLIPDISTANCE5 CLP5

#define SV_Target0		COLOR0
#define SV_Target1		COLOR1
#define SV_Target2		COLOR2
#define SV_Target3		COLOR2
#define SV_Depth		DEPTH
#define SV_Position		POSITION
#define SV_ClipDistance0	CLP0
#define SV_ClipDistance1	CLP1
#define SV_ClipDistance2	CLP2
#define SV_ClipDistance3	CLP3
#define SV_ClipDistance4	CLP4
#define SV_ClipDistance5	CLP5
#define SV_TARGET0		SV_Target0
#define SV_TARGET1		SV_Target1
#define SV_TARGET2		SV_Target2
#define SV_TARGET3		SV_Target3
#define SV_DEPTH		SV_Depth
#define SV_POSITION		SV_Position
#define SV_CLIPDISTANCE0	SV_ClipDistance0
#define SV_CLIPDISTANCE1	SV_ClipDistance1
#define SV_CLIPDISTANCE2	SV_ClipDistance2
#define SV_CLIPDISTANCE3	SV_ClipDistance3
#define SV_CLIPDISTANCE4	SV_ClipDistance4
#define SV_CLIPDISTANCE5	SV_ClipDistance5
typedef float 			vface;
bool isFrontFace(vface face)
{
	return (face>0);
}
float getFaceSign(vface face)
{
	return face;
}

// 言語非依存のマトリクス用演算関数
inline float4 ApplyMatrix( Matrix4x4 mat, float4 vec )
{
	return mul( vec, mat );
}
inline float4 ApplyMatrixT( TMatrix4x4 mat, float4 vec )
{
	return mul( mat, vec );
}
inline float3 ApplyMatrixT( TMatrix4x4 mat, float3 vec )
{
	return mul( mat, float4(vec,0) ).xyz;
}
inline float3 ApplyMatrixT( TMatrix4x3 mat, float4 vec )
{
	return mul( mat, vec ).xyz;
}
inline float3 ApplyMatrixT( TMatrix4x3 mat, float3 vec )
{
	return mul( mat, float4(vec,0) ).xyz;
}
inline float3 ApplyMatrixT( TANGENT2WORLD mat, float3 vec )
{
	return mul( float3x3(mat[0], mat[1], mat[2]), vec ).xyz;
}
inline void SetTranslate( inout Matrix4x4 mat, float4 translate )
{
	mat[3].xyzw = translate.xyzw ;
}
inline void SetTranslateT( inout TMatrix4x4 mat, float4 translate )
{
	mat[0].w = translate.x ;
	mat[1].w = translate.y ;
	mat[2].w = translate.z ;
	mat[3].w = translate.w ;
}
inline void SetTranslateT( inout TMatrix4x3 mat, float3 translate )
{
	mat[0].w = translate.x ;
	mat[1].w = translate.y ;
	mat[2].w = translate.z ;
}
inline float4 GetTranslate( Matrix4x4 mat )
{
	return mat[3].xyzw ;
}
inline float4 GetTranslateT( TMatrix4x4 mat )
{
	return float4( mat[0].w, mat[1].w, mat[2].w, mat[3].w );
}
inline float3 GetTranslateT( TMatrix4x3 mat )
{
	return float3( mat[0].w, mat[1].w, mat[2].w );
}
inline float4 GetRow( TMatrix4x4 mat, half row )
{
	return mat[row].xyzw;
}
inline float4 GetRowT( TMatrix4x4 mat, half row )
{
	return float4( mat[0][row], mat[1][row], mat[2][row], mat[3][row]);
}
inline float3 GetRow( TMatrix4x3 mat, half row )
{
	return mat[row].xyz;
}
inline float3 GetRowT( TMatrix4x3 mat, half row )
{
	return float3( mat[0][row], mat[1][row], mat[2][row] );
}

inline float3 GetViewspaceWorldXDir ( TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[0][0], invViewMat[0][1], invViewMat[0][2] );
}
inline float3 GetViewspaceWorldYDir (TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[1][0], invViewMat[1][1], invViewMat[1][2] );
}
inline float3 GetViewspaceWorldZDir (TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[2][0], invViewMat[2][1], invViewMat[2][2] );
}

#ifdef USEDEFINE_GetElement
#define GetElement(mat,row,column) \
	(mat[column][row])
#else
inline float GetElement( TMatrix4x4 mat, half row, half column )
{
	return mat[column][row];
}
#endif

#else	// ifdef CGLANG

// ----------------------------------------------------------------
// HSLS用設定

// 定数割り当てセマンティクス
#define REGISTER_C(_var)	register(c##_var)
#define REGISTER_B(_var)	register(b##_var)
#define REGISTER_I(_var)	register(i##_var)
#define REGISTER_T(_var)	register(t##_var)
#define REGISTER_S(_var)	register(s##_var)

// 言語非依存のマトリクス定義
typedef float4x4			Matrix4x4 ;
typedef float4x4			TMatrix4x4 ;
typedef float4x3			TMatrix4x3 ;

// 現状のシェーダープリプロセッサでは配列が認識できないので、これらの型を利用します
typedef float3			TANGENT2VIEW[3] ;
typedef half3			HTANGENT2VIEW[3] ;
typedef float3			TANGENT2WORLD[3] ;
typedef half3			HTANGENT2WORLD[3] ;

// Cgと同じセマンティクスを利用可能にする
#ifdef DG_SHADER_GEN_DX9
#define TEXUNIT0		register(s0)
#define TEXUNIT1		register(s1)
#define TEXUNIT2		register(s2)
#define TEXUNIT3		register(s3)
#define TEXUNIT4		register(s4)
#define TEXUNIT5		register(s5)
#define TEXUNIT6		register(s6)
#define TEXUNIT7		register(s7)
#define TEXUNIT8		register(s8)
#define TEXUNIT9		register(s9)
#define TEXUNIT10		register(s10)
#define TEXUNIT11		register(s11)
#define TEXUNIT12		register(s12)
#define TEXUNIT13		register(s13)
#define TEXUNIT14		register(s14)
#define TEXUNIT15		register(s15)
#define SAMPLERUNIT0	TEXUNIT0
#define SAMPLERUNIT1	TEXUNIT1
#define SAMPLERUNIT2	TEXUNIT2
#define SAMPLERUNIT3	TEXUNIT3
#define SAMPLERUNIT4	TEXUNIT4
#define SAMPLERUNIT5	TEXUNIT5
#define SAMPLERUNIT6	TEXUNIT6
#define SAMPLERUNIT7	TEXUNIT7
#define SAMPLERUNIT8	TEXUNIT8
#define SAMPLERUNIT9	TEXUNIT9
#define SAMPLERUNIT10	TEXUNIT10
#define SAMPLERUNIT11	TEXUNIT11
#define SAMPLERUNIT12	TEXUNIT12
#define SAMPLERUNIT13	TEXUNIT13
#define SAMPLERUNIT14	TEXUNIT14
#define SAMPLERUNIT15	TEXUNIT15

#define SAMPLERUNIT_SYSTEM SAMPLERUNIT8

// Dx11用システムセマンティクスマッピング
#define OUT_COLOR		COLOR
#define OUT_COLOR0		COLOR0
#define OUT_COLOR1		COLOR1
#define OUT_COLOR2		COLOR2
#define OUT_COLOR3		COLOR3
#define OUT_DEPTH		DEPTH
#define OUT_POSITION	POSITION
#define SV_Target0		COLOR0
#define SV_Target1		COLOR1
#define SV_Target2		COLOR2
#define SV_Target3		COLOR2
#define SV_Depth		DEPTH
#define SV_Position		POSITION
#define SV_TARGET0		SV_Target0
#define SV_TARGET1		SV_Target1
#define SV_TARGET2		SV_Target2
#define SV_TARGET3		SV_Target3
#define SV_DEPTH		SV_Depth
#define SV_POSITION		SV_Position
typedef float 			vface;
bool isFrontFace(vface face)
{
	return (face>0);
}
float getFaceSign(vface face)
{
	return face;
}

#else // DG_SHADER_GEN_DX11

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

#ifdef F_TARGET_PS4 // F_TARGET_PS4
// Dx11/ps4用システムセマンティクスマッピング

#define OUT_COLOR		OUT_COLOR0
#define OUT_COLOR0		S_TARGET_OUTPUT0
#define OUT_COLOR1		S_TARGET_OUTPUT1
#define OUT_COLOR2		S_TARGET_OUTPUT2
#define OUT_COLOR3		S_TARGET_OUTPUT3
#define OUT_DEPTH		S_DEPTH_OUTPUT
#define OUT_POSITION	S_POSITION
#define VPOS			S_POSITION
#define VFACE			S_FRONT_FACE
#define VINDEXID		S_VERTEX_ID
#define VINSTANCEID		S_INSTANCE_ID
#define VPRIMITIVEID	S_PRIMITIVE_ID
	
#else // F_TARGET_PS4
	
// Dx11用システムセマンティクスマッピング
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
#endif // F_TARGET_PS4
	
typedef bool			vface;

bool isFrontFace(vface face)
{
	return face;
}
float getFaceSign(vface face)
{
	return face?1:-1;
}
	
	
#endif //DG_SHADER_GEN_DX9
	
// 言語非依存のマトリクス用演算関数
inline float4 ApplyMatrix( Matrix4x4 mat, float4 vec )
{
	return mul( mat, vec );
}
inline float4 ApplyMatrixT( TMatrix4x4 mat, float4 vec )
{
	return mul( vec, mat );
}
inline float3 ApplyMatrixT( TMatrix4x4 mat, float3 vec )
{
	return mul( float4(vec, 0), mat ).xyz;
}
inline float3 ApplyMatrixT( TMatrix4x3 mat, float4 vec )
{
	return mul( vec, mat );
}
inline float3 ApplyMatrixT( TMatrix4x3 mat, float3 vec )
{
	return mul( float4(vec, 0), mat );
}
inline float3 ApplyMatrixT( TANGENT2WORLD mat, float3 vec )
{
	return mul( vec, float3x3(mat[0], mat[1], mat[2]) );
}
inline void SetTranslate( inout Matrix4x4 mat, float4 translate )
{
	mat[0].w = translate.x ;
	mat[1].w = translate.y ;
	mat[2].w = translate.z ;
	mat[3].w = translate.w ;
}
inline void SetTranslateT( inout TMatrix4x4 mat, float4 translate )
{
	mat[3].xyzw = translate.xyzw ;
}
inline void SetTranslateT( inout TMatrix4x3 mat, float3 translate )
{
	mat[3].xyz = translate.xyz ;
}
inline float4 GetTranslate( Matrix4x4 mat )
{
	return float4( mat[0].w, mat[1].w, mat[2].w, mat[3].w );
}
inline float4 GetTranslateT( TMatrix4x4 mat )
{
	return mat[3].xyzw ;
}
inline float3 GetTranslateT( TMatrix4x3 mat )
{
	return mat[3].xyz ;
}
inline TMatrix4x4 GetTranspose( TMatrix4x4 mat )
{
	return transpose ( mat );
}
inline float4 GetRow( TMatrix4x4 mat, half _row )
{
	return float4( mat[0][(int)_row], mat[1][(int)_row], mat[2][(int)_row], mat[3][(int)_row]);
}
inline float4 GetRowT( TMatrix4x4 mat, half _row )
{
	return mat[(int)_row].xyzw;
}
inline float3 GetRow( TMatrix4x3 mat, half _row )
{
	return float3( mat[0][(int)_row], mat[1][(int)_row], mat[2][(int)_row] );
}
inline float3 GetRowT( TMatrix4x3 mat, half _row )
{
	return mat[(int)_row].xyz;
}
inline float GetElement( TMatrix4x4 mat, half _row, half _column )
{
	return mat[(int)_row][(int)_column];
}

inline float3 GetViewspaceWorldXDir ( TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[0][0], invViewMat[0][1], invViewMat[0][2] );
}
inline float3 GetViewspaceWorldYDir ( TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[1][0], invViewMat[1][1], invViewMat[1][2] );
}
inline float3 GetViewspaceWorldZDir ( TMatrix4x4 invViewMat ){
	return float3 ( invViewMat[2][0], invViewMat[2][1], invViewMat[2][2] );
}

#endif	// ifdef CGLANG

#endif	// ifdef __cplusplus

#ifdef DG_SHADER_GEN_DX9
#include "DgShaderDefineForDx9Gen.h.hlsl"
#endif	// ifdef DG_SHADER_GEN_DX9

#ifdef DG_SHADER_GEN_DX11
#include "DgShaderDefineForDx11Gen.h.hlsl"
#define USE_CONSTANTBUFFER
#endif	// ifdef DG_SHADER_GEN_DX11
	
#ifdef F_TARGET_PS4
#define cbuffer ConstantBuffer
#endif

#ifdef USE_CONSTANTBUFFER
// J - Need static keyword
#	define PS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define VS_REGISTER(_type) REGISTER_B(SHADER_CONSTANTBUFFER_##_type)
#	define REGISTERMAP(_type, _name, _register) cbuffer c##_type/* : _register*/ { static _type _name; }
#else
#	define VS_REGISTER(_type) REGISTER_C( SHADER_CONST_VS_##_type##_GROUP_TOP )
#	define PS_REGISTER(_type) REGISTER_C( SHADER_CONST_PS_##_type##_GROUP_TOP )
#	define REGISTERMAP(_type, _name, _register) _type _name : _register 
#endif

// Specularの正規化用Shiness上限値
#define SHINESS_NORMALIZE_MAX			256.0
#define SQRT_SHINESS_NORMALIZE_MAX		16.0


#define DG_DRAWPROJECTION_CLIPSPACE_DIRECTX	0
#define DG_DRAWPROJECTION_CLIPSPACE_OPENGL	1


//Lighting計算時にReflection処理をするか？（重い。GBuffer時に事前計算すると多少見た目が変わるが軽くできる）
//#define LIGHTCALC_REFLECTION - 現状動作保障外、次世代機でもライトがネックなのでGbufferに回す

//プラットフォームごとにRefrection計算の方法を変えてみる（最終的にはプラットフォームではなく、ユーザーコンフィグの描画レベルで選べる?）
//シェーダー内とCPP内でifの書き方が違うので注意
#ifdef __cplusplus


#	if (F_TARGET == F_TARGET_PS3)
#		//define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_OPENGL
#	endif

#	if (F_TARGET == F_TARGET_PS4)
#		define ATTENTION_OPTIMIZE	///< ライト減衰計算最適化
#		//define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_OPENGL
#	endif

#	ifndef DG_DRAWPROJECTION_CLIPSPACE_TARGET
#		define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_DIRECTX
#	endif

#	if (F_TARGET == F_TARGET_PS4)
// DepthBoundsによる方法でローカルライトを描画する(shader側と揃える)
#	define USE_DEPTH_BOUNDS_DRAW_FOR_LOCALLIGHT
#	endif

#else	// ifdef __cplusplus

#define USE_SPHERICAL_GAUSSIAN_FRESNLE

#ifdef F_TARGET_XBOXONE
#define CALC_PREBLEND_REFLECTION_HIGHQUALITY
#endif

#ifdef F_TARGET_PS4
#define CALC_PREBLEND_REFLECTION_HIGHQUALITY
#endif


#ifdef F_TARGET_PS3
//#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_OPENGL
//#define DEPTH_RANGE_MINUSONETOONE
#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_DIRECTX
#endif

#ifdef F_TARGET_PS4
//#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_OPENGL
//#define DEPTH_RANGE_MINUSONETOONE
#define ATTENTION_OPTIMIZE			///< ライト減衰計算最適化
#endif

#ifndef DG_DRAWPROJECTION_CLIPSPACE_TARGET
#define DG_DRAWPROJECTION_CLIPSPACE_TARGET	DG_DRAWPROJECTION_CLIPSPACE_DIRECTX
#endif

#ifdef F_TARGET_PS4
// DepthBoundsによる方法でローカルライトを描画する(cpp側と揃える)
#define USE_DEPTH_BOUNDS_DRAW_FOR_LOCALLIGHT
#endif

#endif	// ifdef __cplusplus

#define USE_1002_OPTIMIZE
#define USE_1003_OPTIMIZE

#ifdef F_TARGET_XBOX360
#undef USE_1003_OPTIMIZE	//360の謎最適化のせいで結果的に遅くなるので
#endif

#define NOADJUST_DIMMER			//Dimmerを設定しても１ｍの位置の輝度がかわらない機能はいらない
//#define USE_REFLECTION_FRESNEL	//Reflection表現でもFresnelを考慮する

#ifdef F_TARGET_XBOX360
// Dg/Grコンポーネント及びシェーダ群に7E3フォーマット定義をON
#define LACC_PRECISION_7E3
#endif

#ifdef F_TARGET_PS3								//RGB888に対して擬似HDRに対応
#define HIGHPREC_LACC
//#define USE_ZCULL_RESOLVE_16BITDEPTH			//16bitDepthから復元する深度でZcull復元バッファを作成（デバックの為に残しておく)
#endif

#ifdef F_TARGET_WIN32
#define DG_HIGH_PRECISION_LACC
#endif
	
#ifdef F_TARGET_XBOXONE
#define DG_HIGH_PRECISION_LACC
#endif

#ifdef F_TARGET_PS4
#define DG_HIGH_PRECISION_LACC
#endif

#ifndef DG_HIGH_PRECISION_LACC
#ifdef F_TARGET_WIN64
#define DG_HIGH_PRECISION_LACC
#endif
#endif

//SpecularSizeをサポートしないターゲットプラットフォーム
#ifdef F_TARGET_XBOX360
#define FORCE_NOSPECSIZE
#endif
#ifdef F_TARGET_PS3
#define FORCE_NOSPECSIZE
#endif

//ノーマルマップを引いた時にゼロ割になる可能性を回避
#ifdef DG_SHADER_GEN_DX11
#define NORMALMAP_DECODE_DIVZERO_AVOIDANCE
#endif

#define USE_3RTGBUFFER_PROFILE	//GBUFFER３枚構成
//#define SH_BLENDTYPE_TRUE		//SH新方式ブレンド

#define PRIMIRIVE_OUTPUT_MULTI_TARGET		///< 縮小バッファとマスク抜きの整合性を高める

#define DRAW2D_BORDER_OLDTYPE				///< フォントシェーダの縁取りを以前のままにする（外せば新しいモード)


#endif //_DG_SHADER_DEF_H_
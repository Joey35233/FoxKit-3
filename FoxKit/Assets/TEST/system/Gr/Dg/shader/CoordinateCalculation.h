/**
	@file 	CoordinateCalculation.h
	@brief	座標計算関連の関数定義
*/

#define NEW_VIEWPOS_RECONSTRUCT_CALC
// ---------------------------------------------------------
// NORMALS

#define ENCODE_NORMAL					// XYの正規化、Zのsqrtをとる版
//#define ENCODE_NORMAL_SEPARATED_Z		// ENCODE_NORMALに更にZの要素をZWに分割して記録する版

//#define TEST_ENCODE_NORMAL				// ENCODE_NORMALの差をチェックする

#ifdef ENCODE_NORMAL_SEPARATED_Z
#ifndef ENCODE_NORMAL
#define ENCODE_NORMAL
#endif
#endif


// ---------------------------------------------------------
/** @brief Encode viewspace normal for GBuffer
	@param	normal	the viewspace normal
	@return			the encoded value
 */
half4 EncodeViewSpaceNormal(half3 normal)
{
    half4 encodeNormal = 0.0;
#ifdef ENCODE_NORMAL

#ifndef ENCODE_NORMAL_SEPARATED_Z
    encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
    encodeNormal.z = half(sqrt(half(normal.z) * 0.5h + 0.5h));
#else
	// 新エンコード方式
	// エンコード処理は下記方式で得られた結果をブレンドで破綻しないように8bit4要素に分解して格納
	// xy = normlize( N.xy );
	// z = sqrt( N.z * 0.5 + 0.5 )
	// xy : 精度を保つ様に四角上にマッピング
	// z : 上位と下位ビットに分けて2要素で記録。ブレンド時には下位ビットを無視する予定
	encodeNormal.xy = normal.xy / ( max( abs(normal.x), abs(normal.y) ) ) * 0.5h + 0.5h;
	encodeNormal.z = half(sqrt( half(normal.z) * 0.5h + 0.5h ));
	encodeNormal.w = half(frac( half(encodeNormal.z) * 256.0h ));
	encodeNormal.z -= encodeNormal.w / 256.0h ;
#endif	// ifdef ENCODE_NORMAL_SEPARATED_Z
	
#else	// ifdef ENCODE_NORMAL
	// エンコードなし
	encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
#endif

    return encodeNormal;
}

// ---------------------------------------------------------
#ifdef TEST_ENCODE_NORMAL
/** @brief NormalEncodeの試験用　画面左右上下でNormalの書き出し方をかえてやる
	@param	normal	the viewspace normal
	@return			the encoded value
 */
half4 EncodeViewSpaceNormal2( half3 normal, half3 view )
{
	half4	encodeNormal = 0.0;
	if ( view.x > 0 ){
		// 新エンコード方式
		// エンコード処理は下記方式で得られた結果をブレンドで破綻しないように8bit4要素に分解して格納
		// xy = normlize( N.xy );
		// z = sqrt( N.z * 0.5 + 0.5 )
		// xy : 精度を保つ様に四角上にマッピング
		// z : 上位と下位ビットに分けて2要素で記録。ブレンド時には下位ビットを無視する予定
		if ( view.y < 0 ){
			encodeNormal.xy = normal.xy / ( max( abs(normal.x), abs(normal.y) ) ) * 0.5h + 0.5h;
			encodeNormal.z = half(sqrt( half(normal.z) * 0.5h + 0.5h ));
			encodeNormal.w = half(frac( half(encodeNormal.z) * 256.0h ));
			encodeNormal.z -= encodeNormal.w / 256.0h ;
		} else {
			// エンコードなし
			encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
		}
	} else {
		encodeNormal.xyz = normal.xyz * 0.5h + 0.5h;
		encodeNormal.z = half(sqrt( half(normal.z) * 0.5h + 0.5h ));
	}

	return encodeNormal ;
}
#endif


//#define HIGH_PRECISION_VIEWNORMAL	// これを有効にしないとPS3で法線の精度が落ちてしまうが、パフォーマンスを考慮して無効化
// ---------------------------------------------------------
/**
 * @brief	Decode view space normal.
 * @param	encodeNormal	The encode normal.
 * @return	the decoded value
**/
half3 DecodeViewSpaceNormal(half4 encodeNormal)
{
#ifdef ENCODE_NORMAL
#ifdef ENCODE_NORMAL_SEPARATED_Z
	// 4要素エンコード版
	half3	viewSpaceNormal;
	half z = dot( encodeNormal.zw, half2( 1.0h, 1.0h/256.0h ) );
	viewSpaceNormal.z = ( z * z ) * 2.0h - 1.0h ;
	encodeNormal.xy = half2( normalize( half2( encodeNormal.xy * 2.0h - 1.0h ) ) );
	viewSpaceNormal.xy = encodeNormal.xy * (half) sqrt( 1.0h - viewSpaceNormal.z*viewSpaceNormal.z );
#else
	// 3要素エンコード版
#ifdef HIGH_PRECISION_VIEWNORMAL
	float3	viewSpaceNormal;
	viewSpaceNormal.xy = encodeNormal.xy * 2.0 - 1.0 ;
	viewSpaceNormal.z = ( encodeNormal.z * encodeNormal.z ) * 2.0 - 1.0 ;
	//viewSpaceNormal.xy = half2( normalize( viewSpaceNormal.xy ) ) * (half) sqrt( 1.0h - viewSpaceNormal.z*viewSpaceNormal.z );
	float	oneMinusZz = 1.0 - viewSpaceNormal.z * viewSpaceNormal.z ;// 1-z*z
	viewSpaceNormal.xy = ( viewSpaceNormal.xy * oneMinusZz ) * (half)rsqrt( oneMinusZz * (half)dot( viewSpaceNormal.xy, viewSpaceNormal.xy ) );
#else
	
#ifdef F_TARGET_PS3
		half3	viewSpaceNormal;
		viewSpaceNormal.xy = encodeNormal.xy * 2.0h - 1.0h ;
		viewSpaceNormal.z = 0;
		viewSpaceNormal = normalize( viewSpaceNormal );
		viewSpaceNormal.z = ( encodeNormal.z * encodeNormal.z ) * 2.0h - 1.0h ;
		half	oneMinusZz = 1.0h - viewSpaceNormal.z * viewSpaceNormal.z ;// 1-z*z
		viewSpaceNormal.xy *= ( oneMinusZz ) * (half)rsqrt( oneMinusZz + 0.0001h );
#else
#ifdef NORMALMAP_DECODE_DIVZERO_AVOIDANCE
		float bias = 1.0e-007f;
#else
    float bias = 1.175494e-038f;
#endif
    half3 viewSpaceNormal;
    viewSpaceNormal.xy = encodeNormal.xy * 2.0h - 1.0h;
    viewSpaceNormal.z = (encodeNormal.z * encodeNormal.z) * 2.0h - 1.0h;
    half oneMinusZz = 1.0h - viewSpaceNormal.z * viewSpaceNormal.z; // 1-z*z
    viewSpaceNormal.xy = (viewSpaceNormal.xy * oneMinusZz) * (half) rsqrt(oneMinusZz * (half) dot(viewSpaceNormal.xy, viewSpaceNormal.xy) + bias);
#endif
#endif

#endif
#else	// ifdef ENCODE_NORMAL
	// エンコードなし
	half3	viewSpaceNormal;
	viewSpaceNormal = encodeNormal.xyz * 2.0h - 1.0h;
#endif	// ifdef ENCODE_NORMAL
    return half3(viewSpaceNormal);
}

// ---------------------------------------------------------
/**	@brief Reconstructs the view normal vector from a G-Buffer with encoded viewspace normals (xy)
	@param[in] normals the Texture2D of the G-Buffer containing the normals
	@param[in] uv the texture coordinates
	@return the view normal vector
*/
half3 ReconstructViewSpaceNormal(Texture2D normals, float2 uv)
{
	// 新エンコード方式
    return DecodeViewSpaceNormal(TFetch2DLodH(normals, SamplerPointClamp, float4(uv, 0, 0)));
}

half3 ReconstructViewSpaceNormalWithSampler(Texture2D normals, SamplerState samplerstate, float2 uv)
{
	// 新エンコード方式
    return DecodeViewSpaceNormal(TFetch2DH(normals, samplerstate, uv));
}


// ----------------------------------------------------------------
/**	@brief ノーマルテクスチャのデコード処理
	@param[in] color	
    
    foxのシステムでは法線マップも圧縮をすることを前提としており、
    DXT5形式で、x成分をAに、y成分をGに入れるということを
    テクスチャの圧縮段階で行なっています。
    (Z成分はsqrt( 1 - x*x + y*y )で算出)
    
    注記：
 　　  x = R*A
 　　  y = G
 　　  z = sqrt( 1 - x*x + y*y )
 　　  とする手法も考えられる。
 　　  foxも同じ手段を取れば無圧縮の法線もそのまま使えるかも知れません。

	@XBOX360の場合について
	xbox360では法線マップテクスチャの圧縮にDXT5ではなくDXN形式を利用します。
	また、α成分にはGと同じ値が入る為上記の運用では正常法線が構築出来ない為
	xbox360では一律xyのみを利用する運用とします。
 */
inline half3 DecodeNormalTexture(half4 color)
{
    half3 normal;
	
#ifdef USE_LOW_ACCURACY_NORMAL	//エンコードされていない
//	normal.xyz = float3 ( 0,0,1 );
	normal.xyz = color.xyz * 2.0h - 1.0h ;
#else //USE_LOW_ACCURACY_NORMAL
    
	//normal.xyz = tex2d( tex, uv ).agb * 2 - 1 ;
#ifdef F_TARGET_XBOX360
	normal.xyz = half3( color.rgb ) * 2.0h - 1.0h ;
#else
    normal.xyz = half3(color.agb) * 2.0h - 1.0h;
#endif
	//normal.z = sqrt( 1.0h - dot( normal.xyz, normal.xyz ) ) );
	//normal.z = sqrt( saturate( 1.0h - dot( normal.xyz, normal.xyz ) ) );
	/* なぜかRSQ + DIVで実装されてしまう */
	//normal.z = sqrt( saturate( 1.0h - normal.x * normal.x - normal.y * normal.y ) );
	/* こう記述するとDVSQで処理されるので最適化されやすい */
#ifdef DG_SHADER_GEN_DX11
	half tmp = half( saturate( 1.0h - normal.x * normal.x - normal.y * normal.y ) + 0.0001h );
#else
    half tmp = half(saturate(1.0h - normal.x * normal.x - normal.y * normal.y));
#endif
    normal.z = half(tmp * rsqrt(tmp));
	
#endif //USE_LOW_ACCURACY_NORMAL
	
    return normal;
}

// ----------------------------------------------------------------
/** @brief fetch normal map texture
	@param	tex		Texture2D
	@param	samplerstate SamplerState
	@param	uv		texture address
	@return			normal
*/
inline half3 GetNormalFromTextureWithSampler(Texture2D tex, SamplerState samplerstate, float2 uv)
{
    return DecodeNormalTexture(TFetch2DH(tex, samplerstate, uv));
}

// ----------------------------------------------------------------
/** @brief fetch normal map texture
	@param	tex		Texture2D
	@param	uv		texture address
	@return			normal
*/
inline half3 GetNormalFromTexture(Texture2D tex, float2 uv)
{
    return DecodeNormalTexture(TFetch2DH(tex, SamplerLinear, uv));
}



// ----------------------------------------------------------------
/** @brief fetch normal map array texture
	@param	tex		Texture2D
	@param	uv		texture address
	@return			normal
*/
inline half3 GetNormalFromArrayTexture(Texture3D tex, float3 texcoord)
{
    return DecodeNormalTexture(TFetch3DH(tex, SamplerLinear, texcoord));
}

#if 0
// ----------------------------------------------------------------
/**	@brief fetch normal map array texture
	@param	tex		sampler
	@param	uv		texture address
	@return			normal
*/
inline half3 GetNormalFromArrayTexture( sampler tex, float3 texcoord, float3 dx, float3 dy )
{
	return DecodeNormalTexture( (half4)tex3D( tex, texcoord, dx, dy ) ) ;
}
#endif

// ---------------------------------------------------------    
// View Position

// ---------------------------------------------------------    
/**	@brief  Reconstructs the view position from clip space coordinates
	@param[in] clipSpacePos the position in clip space
	@param[in] proj parameters for reconstruction
	@return the view position
*/
float4 ReconstructViewPos(float4 clipSpacePos, float4 proj)
{
    float3 viewPos;
    
#ifndef NEW_VIEWPOS_RECONSTRUCT_CALC
	viewPos.xyz = float3(clipSpacePos.xy, 1) * float3(-1, proj.zw);

	float w = proj.y / ( clipSpacePos.z - proj.x );
	viewPos.xyz = viewPos.xyz * w / proj.w;
#else
    viewPos.z = proj.z / (clipSpacePos.z - proj.w);
    viewPos.xy = (clipSpacePos.xy * proj.xy) * viewPos.z;
#endif

    return float4(viewPos, 1);
}

// ---------------------------------------------------------    
/**	@brief  Reconstructs the view position from clip space coordinates from texture
	@param[in] inDepth depth texture
	@param[in] inTexCoord texture coordinate
	@param[in] clipSpacePos the position in clip space
	@param[in] proj parameters for reconstruction
	@return the view position
*/
float4 ReconstructViewPosFromTexture(Texture2D inDepth, half2 inTexCoord, float2 clipSpacePosXY, float4 inProjectionParam)
{
#ifdef DEPTHTEXTURE_AS_PACKED_W
	// PS3専用 W値に展開された値を取得する
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	float W = unpack_2half( pack_4ubyte( TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)) ) ).x;
#else
	float W = pack_4ubyte(TFetch2DLod(inDepth, SamplerPointClamp, half4(inTexCoord, 0, 0)).bgra);
#endif
#ifndef NEW_VIEWPOS_RECONSTRUCT_CALC
	float4	viewPos = float4(clipSpacePosXY, 1, 1) * float4(-1, inProjectionParam.z, 1, 1);
	viewPos.xyz *= W ;
#else
	float4	viewPos ;
	viewPos.xy = clipSpacePosXY * inProjectionParam.xy ;
	viewPos.zw = 1 ;
	viewPos.xyz *= W ;
#endif
	return viewPos ;
#else
#ifdef F_TARGET_PS3
	float zOverW = pack_4ubyte(TFetch2DLod(inDepth, SamplerPointClamp, half4(inTexCoord, 0, 0)).bgra);
#ifdef DEPTH_RANGE_MINUSONETOONE
	zOverW = 2.0 * zOverW - 1.0;
#endif
#else
    float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, half4(inTexCoord, 0, 0)).x;
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	zOverW = zOverW * 2 - 1;
#endif
#endif
	
    return ReconstructViewPos(float4(clipSpacePosXY, zOverW, 1), inProjectionParam);
#endif
}

// ---------------------------------------------------------    
/**	@brief  	Reconstructs the view position from clip space coordinates
	@param[in]	inScreenSpacePos the position in screen space
	@param[in]	inDepth	the depth value
	@param[in]	inProjectionParam parameters for reconstruction
	@return 	the view position
*/
float4 ReconstructViewPos2(float2 inScreenSpacePos, float inDepth, float4 inProjectionParam)
{
#ifdef F_TARGET_PS4
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	inDepth = inDepth * 2.0f - 1.0f;
#endif
#endif

#ifndef NEW_VIEWPOS_RECONSTRUCT_CALC
	float3 viewPos = float3(inScreenSpacePos, 1) * float3(-1, inProjectionParam.zw);
#ifndef DEPTHTEXTURE_AS_PACKED_W
	float w = inProjectionParam.y / (inDepth - inProjectionParam.x);
#else
	// PS3専用 W値に展開された値を取得する
	float	w = inDepth ;
#endif
	return float4((viewPos * w / inProjectionParam.w), 1);
#else
    float3 viewPos;
    viewPos.xy = inScreenSpacePos.xy * inProjectionParam.xy;
#ifndef DEPTHTEXTURE_AS_PACKED_W
    viewPos.z = inProjectionParam.z / (inDepth - inProjectionParam.w);
#else
	// PS3専用 W値に展開された値を取得する
	viewPos.z = inDepth ;
#endif
    viewPos.xy = viewPos.xy * viewPos.z;
    return float4(viewPos.xyz, 1);
#endif
}

// ---------------------------------------------------------    
/**	@brief		Reconstructs just depth (view depth)
	@param[in] z in clip space
	@param[in] proj parameters for reconstruction
	@return Depth (view_z)
*/
float ReconstructViewZ(float zOverW, float4 proj)
{
#ifdef F_TARGET_PS4
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	zOverW = zOverW * 2 - 1;
#endif
#endif

#ifndef NEW_VIEWPOS_RECONSTRUCT_CALC
	return (proj.y / (zOverW - proj.x));
#else
    return (proj.z / (zOverW - proj.w));
#endif
}

// ---------------------------------------------------------    
/**	@brief		Reconstructs just depth (view depth) from texture
	@param[in] inDepth depth texture
	@param[in] inTexCoord texture coordinate
	@param[in] projectionParameter parameters for reconstruction
	@return Depth (view_z)
*/
float ReconstructViewZFromTexture(Texture2D inDepth, float2 inTexCoord, float4 projectionParameter)
{
#ifdef DEPTHTEXTURE_AS_PACKED_W
	// PS3専用 W値に展開された値を取得する
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	float2 zOverW = unpack_2half( pack_4ubyte( TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)) ) );
	return zOverW.x;
#else
	return pack_4ubyte(TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)).bgra);
#endif
#else
#ifdef F_TARGET_PS3
	float zOverW = pack_4ubyte(TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)).bgra);
#ifdef DEPTH_RANGE_MINUSONETOONE
	zOverW = 2.0 * zOverW - 1.0;
#endif
#else
    float zOverW = TFetch2DLod(inDepth, SamplerPointClamp, float4(inTexCoord, 0, 0)).x;
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	//zOverW = zOverW * 2 - 1;
#endif
#endif
    return ReconstructViewZ(zOverW, projectionParameter);
#endif
}

//ソフトウェアブレンド出力の構造体
struct DepthBlendResult
{
    float value;
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	float		valueSub;
#endif
};

struct PrimitiveDepthFactor
{
    float viewZ;
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	float		viewZSub;
#endif
};

///PrimitiveDepthTexture用のZ値フェッチ
void ReconstructViewZFromPrimitiveDepthTexture(Texture2D inDepth, float2 inTexCoord, float4 projectionParameter, out PrimitiveDepthFactor depth)
{
#ifdef F_TARGET_PS3
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	float4 tmp = TFetch2D(inDepth, SamplerPointClamp, inTexCoord);
	float2 zOverW = unpack_2half( pack_4ubyte( tmp ) );
#else
	float2 zOverW = pack_4ubyte(TFetch2D(inDepth, SamplerPointClamp, inTexCoord).bgra);
#endif
	depth.viewZ = zOverW.x;
#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	depth.viewZSub = zOverW.y;
#endif
#else
    float4 fetchDepth = TFetch2D(inDepth, SamplerPointClamp, inTexCoord);
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	fetchDepth.x = fetchDepth.x * 2 - 1;
#endif
    depth.viewZ = ReconstructViewZ(fetchDepth.x, projectionParameter);

#ifdef PRIMIRIVE_OUTPUT_MULTI_TARGET
	{
#ifdef DEPTH_RANGE_MINUSONETOONE
	//Ps4は範囲が-1~1になるため加工が必要
	fetchDepth.y = fetchDepth.y * 2 - 1;
#endif
	depth.viewZSub = ReconstructViewZ( fetchDepth.y,  projectionParameter );
	}
#endif
#endif
}
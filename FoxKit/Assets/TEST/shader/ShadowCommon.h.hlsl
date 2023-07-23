/**
	@file 		ShadowCommon.h
	@brief	 	シャドウマップ関連の関数
	
	・シャドウマップのUV値計算
	・シャドウマップのフェッチと評価
*/

#ifndef SHADOWCOMMON_H_
#define SHADOWCOMMON_H_

Texture2D g_RandomTexture : TEXUNIT12;


float4 CalcCascadeShadowUVArea(float4x4 shadowParams, float4 view_pos, float4 projection_pos, float4 CascadePlanes[9])
{
    half shadowDepth = (half) GetElement(shadowParams, 3, 0); // shadowParams[3].x;
    float4 shadow_uv;
	
    half3 j1 = half3((half) (dot(view_pos, CascadePlanes[0])), (half) (dot(view_pos, CascadePlanes[1])), (half) (dot(view_pos, CascadePlanes[2])));
    half3 j2 = half3((half) (dot(view_pos, CascadePlanes[3])), (half) (dot(view_pos, CascadePlanes[4])), (half) (dot(view_pos, CascadePlanes[5])));
    half3 j3 = half3((half) (dot(view_pos, CascadePlanes[6])), (half) (dot(view_pos, CascadePlanes[7])), (half) (dot(view_pos, CascadePlanes[8])));
    j1 = 1.0h - (half3) (step(0.99h, abs(j1))); /// Ps3用に 1.0 - (1 / 1024 * 2 * 3)  以上にならないように (3はジッタ用確保)
    j2 = 1.0h - (half3) (step(0.99h, abs(j2)));
    j3 = 1.0h - (half3) (step(0.99h, abs(j3)));
    half3 mask = half3(j1.x * j1.y * j1.z, j2.x * j2.y * j2.z, j3.x * j3.y * j3.z);
	//より上位のHitを優先させる為
    half4 final_mask = half4(mask.x, mask.y * (1 - mask.x), mask.z * (1 - mask.y), 1 - step(1, mask.x + mask.y + mask.z));
    float4 scale_vec;
    scale_vec = ApplyMatrixT(shadowParams, float4((float3) final_mask.yzw, 0));
    scale_vec.w += (float) (1.0h * final_mask.x);
    shadow_uv.xyz = (projection_pos.xyz * scale_vec.w) + scale_vec.xyz;
    shadow_uv.z = (shadow_uv.z + 1.0) * shadowDepth;
	//UV空間に変換
    shadow_uv.xy = shadow_uv.xy * 0.5f + 0.5f;
    shadow_uv.y = 1.0f - shadow_uv.y;
	//カスケードオフセット考慮
    shadow_uv.xy *= 0.5f;
    const half4x4 cascadeOffset =
    {
        0, 0.5h, 0, 0.5h,
		0, 0, 0.5h, 0.5h,
		0, 0, 0, 0,
		0, 0, 0, 0,
    };
    half2 selectedOffset = (half2) ApplyMatrixT(cascadeOffset, final_mask.xyzw);
    shadow_uv.xy += (half2) selectedOffset;
    shadow_uv.w = 1; ///< あとでテクスチャフェッチに利用されているのでつぶしておく
    return shadow_uv;
}

// ----------------------------------------------------------------
/**
	@brief		カスケードシャドウマップ用のUV値計算
	@param[in] shadowParams The shadow parameters
	@param[in] projection_pos The point projected using the shadow projection matrix
	@param[in] invRangeIntervalLog To compute the intervals of each cascade
	@return the UV coordinates (xyz), and the cascade level (w)
*/
float4 CalcCascadeShadowUV(float4x4 shadowParams, float4 projection_pos, float invRangeIntervalLog)
{
    float shadowDepth = GetElement(shadowParams, 3, 0); // shadowParams[3].x;
#if 0
	float4	shadow_uv ;    
	int		level = 0 ;

	// 投影エリアのレベルを求める
	level = floor( log2( projection_pos.w ) * invRangeIntervalLog );	//事前加工で1以上が保障されているのでmaxをはずす
	level = min( level, MAX_CASCADE_BLOCKS - 1.0 );
	float4 final_mask = saturate(abs(float4(0,1,2,3)-level.xxxx));
	final_mask = 1 - final_mask;

	///@todo LIGHT_TUNE 2010.11.05	// なるべくベクトル演算にしたいけど逆に遅くなるシェーダーもちらほら
	float4	scale_vec ;
	scale_vec = ApplyMatrixT( shadowParams, float4( final_mask.yzw, 0 ) );
	scale_vec.w += 1.0f * final_mask.x ;
	shadow_uv.xyz = projection_pos.xyz * scale_vec.w + scale_vec.xyz ;

	//頂点シェーダに移しました（根本対応には相当な変更が必要)
	//	float bias = depth_bias ;
	//    shadow_uv.z += bias;  

	// 事前に 1.0f/(2.0f+shadowProjectionRange) を計算済み
	float depth_scale = shadowDepth ;

	shadow_uv.z = (shadow_uv.z + 1.0) * depth_scale ;

	// wにはレベルの値を入れておく(テクスチャの参照時に利用)
	shadow_uv.w = level;

	return shadow_uv ;

#else
	//Level範囲比較用の数値これでとなりのカスケードを見に行かないようにする
    const float SHADOW_TEXTURE_UV_AREA = pow(1.0f - ((1.0 / SHADOW_SUN_SIZE) * 4), 2);

	//各レベルのUV値を算出する

	//レベルのパラメータを抽出
    float4 selected_uv[4];

    selected_uv[0] = float4(projection_pos.xyz, 0);

    const float4 lv1Param = GetRowT(shadowParams, 0);
    const float4 lv2Param = GetRowT(shadowParams, 1);
    const float4 lv3Param = GetRowT(shadowParams, 2);

	//UV計算を再現する
    selected_uv[1] = float4(((projection_pos.xyz * lv1Param.w) + lv1Param.xyz), 1);
    selected_uv[2] = float4(((projection_pos.xyz * lv2Param.w) + lv2Param.xyz), 2);
    selected_uv[3] = float4(((projection_pos.xyz * lv3Param.w) + lv3Param.xyz), 3);

	//Z値を加工する
    selected_uv[0].z = (selected_uv[0].z + 1.0f) * shadowDepth;
    selected_uv[1].z = (selected_uv[1].z + 1.0f) * shadowDepth;
    selected_uv[2].z = (selected_uv[2].z + 1.0f) * shadowDepth;
    selected_uv[3].z = (selected_uv[3].z + 1.0f) * shadowDepth;

	//XY判定
    half3 areaJudg1 = half3(step(selected_uv[0].xy * selected_uv[0].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[0].z));
    half3 areaJudg2 = half3(step(selected_uv[1].xy * selected_uv[1].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[1].z));
    half3 areaJudg3 = half3(step(selected_uv[2].xy * selected_uv[2].xy, SHADOW_TEXTURE_UV_AREA), step(0, selected_uv[2].z));
	//half3 areaJudg4 = half3( step( selected_uv[3].xy * selected_uv[3].xy,SHADOW_TEXTURE_UV_AREA) , step( 0,selected_uv[3].z ) );

	//マスク生成
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

    half4 result = (half4) (
		(selected_uv[0] * mask.x) +
		(selected_uv[1] * mask.y) +
		(selected_uv[2] * mask.z) +
		(selected_uv[3] * mask.w));

	//補正
    result.z = max(0.000001, result.z);
    return result;
#endif
}

// ----------------------------------------------------------------
/**
	@brief		カスケードシャドウマップ用のUV値計算(カスケードブレンド付き)
*/
float4 CalcCascadeShadowUVWithCascadeBlend(float4x4 shadowParams, float4 projection_pos, float invRangeIntervalLog, float2 screenTexCoord)
{

	//Level範囲比較用の数値これでとなりのカスケードを見に行かないようにする
    const float SHADOW_TEXTURE_UV_AREA = 1.0f - ((1.0 / SHADOW_SUN_SIZE) * 8);
    const half SHADOW_TEXTURE_UV_AREA_RANDOM_LV0 = (half) (SHADOW_TEXTURE_UV_AREA * SHADOW_TEXTURE_UV_AREA);

#ifdef F_TARGET_WINDOWS

	float  useCascadeBlend = GetElement( shadowParams, 3, 3); // shadowParams[3].w;

	//二乗比較を行うので
	half SHADOW_TEXTURE_UV_AREA_RANDOM_OTH = SHADOW_TEXTURE_UV_AREA_RANDOM_LV0;
	float randomValue = 0;

	if( useCascadeBlend ){
		//シャドウマップサイズでの１ピクセルのランダムUV位置ずらしを取得
		const half2	texCoordCenterOffset = ( (half2)( TFetch2D( g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE ).xy ) );
		//Level範囲比較用のランダムずらし数値生成
		const float2 INV_SHADOW_SUN_SIZE = (1.0 / SHADOW_SUN_SIZE);
		randomValue = max(texCoordCenterOffset.x,texCoordCenterOffset.y) * 0.0025f;
		SHADOW_TEXTURE_UV_AREA_RANDOM_OTH = 	(half)pow( (SHADOW_TEXTURE_UV_AREA - ((max(texCoordCenterOffset.x,texCoordCenterOffset.y) * SHADOW_SUN_SIZE/4.0h  ) * INV_SHADOW_SUN_SIZE) ) , 2 );
	}

#else

	//二乗比較を行うので
    const half SHADOW_TEXTURE_UV_AREA_RANDOM_OTH = SHADOW_TEXTURE_UV_AREA_RANDOM_LV0;
    const float randomValue = 0;

#endif


    float shadowDepth = GetElement(shadowParams, 3, 0); // shadowParams[3].x;

	//レベルのパラメータを抽出
    float4 selected_uv[4];

    selected_uv[0] = float4(projection_pos.xyz, 0);


    const float4 lv1Param = GetRowT(shadowParams, 0);
    const float4 lv2Param = GetRowT(shadowParams, 1);
    const float4 lv3Param = GetRowT(shadowParams, 2);

	//UV計算を再現する
    selected_uv[1] = float4(((projection_pos.xyz * lv1Param.w) + lv1Param.xyz), 1);
    selected_uv[2] = float4(((projection_pos.xyz * lv2Param.w) + lv2Param.xyz), 2);
    selected_uv[3] = float4(((projection_pos.xyz * lv3Param.w) + lv3Param.xyz), 3);

	//Z値を加工する
    selected_uv[0].z = (selected_uv[0].z + 1.0f) * shadowDepth;
    selected_uv[1].z = (selected_uv[1].z + 1.0f) * shadowDepth;
    selected_uv[2].z = (selected_uv[2].z + 1.0f) * shadowDepth;
    selected_uv[3].z = (selected_uv[3].z + 1.0f) * shadowDepth;
	
	//判定用UV生成
    half2 calcAreaUV[4];
	//calcAreaUV[0] = ((selected_uv[0] * 2) - 1) * ((selected_uv[0] * 2) - 1);
	//calcAreaUV[1] = ((selected_uv[1] * 2) - 1) * ((selected_uv[1] * 2) - 1);
	//calcAreaUV[2] = ((selected_uv[2] * 2) - 1) * ((selected_uv[2] * 2) - 1);
    calcAreaUV[0] = (half2) selected_uv[0] * (half2) selected_uv[0];
    calcAreaUV[1] = (half2) selected_uv[1] * (half2) selected_uv[1];
    calcAreaUV[2] = (half2) selected_uv[2] * (half2) selected_uv[2];
#ifdef OUTOFAREA
	calcAreaUV[3] = (half2)selected_uv[3] * (half2)selected_uv[3];
#endif

	//XY判定
    half3 areaJudg1 = half3(step(calcAreaUV[0], SHADOW_TEXTURE_UV_AREA_RANDOM_LV0), step(randomValue, selected_uv[0].z));
    half3 areaJudg2 = half3(step(calcAreaUV[1], SHADOW_TEXTURE_UV_AREA_RANDOM_OTH), step(randomValue, selected_uv[1].z));
    half3 areaJudg3 = half3(step(calcAreaUV[2], SHADOW_TEXTURE_UV_AREA_RANDOM_OTH), step(randomValue, selected_uv[2].z));
#ifdef OUTOFAREA
	half3 areaJudg4 = half3( step( calcAreaUV[3] ,SHADOW_TEXTURE_UV_AREA_RANDOM_OTH) , step( randomValue,selected_uv[3].z ) );
#endif

	//マスク生成
    half4 mask = half4(areaJudg1.x * areaJudg1.y * areaJudg1.z,
					  areaJudg2.x * areaJudg2.y * areaJudg2.z,
					  areaJudg3.x * areaJudg3.y * areaJudg3.z,
#ifdef OUTOFAREA
					  areaJudg4.x*areaJudg4.y*areaJudg4.z );
#else
					  1);
#endif					  
    half hit = 1.0h - mask.x;
    mask.y = mask.y * hit;
    hit = hit * (1.0h - mask.y);
    mask.z = mask.z * hit;
    hit = hit * (1.0h - mask.z);
    mask.w = mask.w * hit;

    half4 result = (half4) (
		(selected_uv[0] * mask.x) +
		(selected_uv[1] * mask.y) +
		(selected_uv[2] * mask.z) +
		(selected_uv[3] * mask.w));

#ifdef OUTOFAREA
	if( dot(mask,mask) == 0 )
		result.w = 4.0h;
#endif

	//補正
    result.z = max(0.000001, result.z);
    return result;
}

// ----------------------------------------------------------------
/**
	@brief		カスケードシャドウマップ用のUV値計算
	@param[in] shadowParams The shadow parameters
	@param[in] projection_pos The point projected using the shadow projection matrix
	@param[in] projectionParameter xyz : offset parameter, w : scaling parameter
	@return the UV coordinates (xyz), and the cascade level (w)
*/
float4 CalcCascadeShadowUV2(float4x4 shadowParams, float4 projection_pos, float4 projectionParameter)
{
    float4 shadow_uv = projection_pos;

	// 事前に 1.0f/(2.0f+shadowProjectionRange) を計算済み
    float depth_scale = GetElement(shadowParams, 3, 0); // shadowParams[3].x;

    shadow_uv.z = (shadow_uv.z + 1.0) * depth_scale;
    
    return shadow_uv;
}

// ----------------------------------------------------------------
/** 
	@brief	Computes the UV texture coordinates in the Paraboloid Shadow Map
	@param[in] lightParams the light parameters
	@param[in] view_pos the point in the view space of the light
	@return the UV coordinates (xyz), and a culling value (w)
*/
float4 CalcParaboloidShadowUV(float4 lightParams, float4 view_pos)
{
    //float near = lightParams.x;
    //float far_inv = lightParams.y;
    float range_inv = lightParams.z;
    
    float4 position = view_pos;
    // homogeneous position in camera space
    position = position / position.w;
    // x,y coords of the map, being P(0,0,0)
    float isBack = (position.z <= 0.0) ? -1.0 : 1.0;
    position.z *= isBack;
    float len = length(position.xyz);
    position.xyz = position.xyz / len;
    // halfway vector
    position.z = position.z + 1;
    position.xy = position.xy / position.z;
    // shrink 1 pixel in every dimension
    float w = SHADOW_CAST2_WIDTH / 2.0;
    float h = SHADOW_CAST2_HEIGHT;
    position.xy *= float2((w - 2.0) / w, (h - 2.0) / h);
    
    //To have proper depth testing, I have set the z coordinate back to the distance
    //from P to the vertex in world space scaled by the viewing distance.
    position.z = len * range_inv;
    position.z = 1 - position.z;

#ifdef DEPTH_RANGE_MINUSONETOONE
    position.z 	= (position.z + 1.0) * 0.5;
#endif

    position.w = isBack;
    
    return position;
}


// -----------------------------------------------------
/**
	PCF版 最軽量
	GR_SHADOW_PCFX4 を定義すると更に周囲３点をフェッチするちょっとリッチなものになる
*/
//#define GR_SHADOW_PCFX4
float ShadowComparisonFiltered(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float attenuation = 1.0)
{
	
#ifdef GR_SHADOW_PCFX4
#define SAMPLING_RADIUS (0.7)
#define N_SAMPLES (3)
	// フィルタリング用
	const float2 circle[N_SAMPLES] = { // sample every 120 degrees
		SAMPLING_RADIUS * float2(0,1) / shadowMapSize,
		SAMPLING_RADIUS * float2(sqrt(3)*0.5, -0.5) / shadowMapSize,
		SAMPLING_RADIUS * float2(-sqrt(3)*0.5, -0.5) / shadowMapSize
	};
#endif	// ifdef GR_SHADOW_PCFX4
	
    float shadow;

#ifdef F_TARGET_XBOX360
	// PCFなし
	// -------------------------------------------------------------------------
	//shadow = (tex2Dproj(shadowMap, texCoord.xyzw).x < texCoord.z)? 0.0 : 1.0;

	// PCF（1サンプルのみ）- NVIDIAの1回目のtex2Dprojに相当します
	// -------------------------------------------------------------------------
	// Fetch the four samples
	texCoord.xyzw = texCoord.xyzw / texCoord.w ;

	float4 weights = 0;
	float4 depthValues = 0;
	float texLOD = 0;

	asm {
		setTexLOD texLOD;
		getWeights2D weights, texCoord.xy, shadowMap, MinFilter=linear, MagFilter=linear, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.x___, texCoord.xy, shadowMap, OffsetX=-0.5, OffsetY=-0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues._x__, texCoord.xy, shadowMap, OffsetX= 0.5, OffsetY=-0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.__x_, texCoord.xy, shadowMap, OffsetX=-0.5, OffsetY= 0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.___x, texCoord.xy, shadowMap, OffsetX= 0.5, OffsetY= 0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
	};

	weights.zw = float2(1, 1) - weights.xy;
	weights = weights.zxzx * weights.wwyy;

	//float4 comparison = texCoord.zzzz < depthValues;
	float4 comparison = step(texCoord.zzzz, depthValues);

	shadow = (1.0 - dot(comparison, weights) * attenuation);

#else	// ifdef F_TARGET_XBOX360
	
    shadow = TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, texCoord.xyzw).x;
#ifdef GR_SHADOW_PCFX4
	// フィルタリング → 平均をとる
	for (int i = 0; i<N_SAMPLES; i++)
	{
		float4 neighbour = texCoord;
		neighbour.xy += circle[i] * texCoord.w ;
		shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour).x;
	}
	shadow /= (N_SAMPLES + 1.0);	
#endif	// ifdef GR_SHADOW_PCFX4
    shadow *= attenuation;
	
    shadow = 1.0 - shadow;

#endif
	// フィルタリングの結果はリニア空間でやると、影が薄くて綺麗にブレンドできない。
	// なので、sRGBのデータとして扱って、リニアに直して、ライトにたす。
	// 最後のシェーディングが終わったところsRGBに戻される
	// （ようするに、ここで計算した結果に戻す）
		// pow は遅いので 2 乗で.
    shadow = shadow * shadow;

    return shadow;
}

// -----------------------------------------------------
/**
	近傍4点合成フィルタ(ガウスフィルタ)
	サンプル中心位置に対して距離シャドウマップの対角方向に(±0.5,±0.5)オフセットした4点の
	PCFの結果を合成した結果を返します。
	PCFで行なわれるウェイト計算により結果的にサンプル位置を中心とした3x3がガウスフィルタを得ることが出来ます。
	また±0.125の範囲で2x2のマイクロディサのよるサンプル位置の補正も行ないます。
 */
half ShadowComparisonFourSampleGaussianFilterWithMicroDither(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
    float shadow = 0;
    float4 neighbour;
    float4 offset = float4(0.5, 0.5, -0.5, -0.5);
    float2 ditherOffset2x2 = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
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

    return (half) shadow;
}
// -----------------------------------------------------
/**
	近傍4点合成フィルタ(ガウスフィルタ)
	サンプル中心位置に対して距離シャドウマップの対角方向に(±0.5,±0.5)オフセットした2点の
	PCFの結果を合成した結果を返します。
	完全なフィルタ結果を返すのではなく、2x2のディザパターンにより隣接する2点の合計が
	ガウスフィルタの結果となるように交互にサンプリングを行ないます。
 */
half ShadowComparisonTwoSampleWithDitherGaussianFilter(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
	// 対角2タップ2x2ディザサンプルフィルタ
    float2 ditherOffset2x2 = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
    float2 offset = float2(0.5, 0.5) * ditherOffset2x2.xy / shadowMapSize;
    float shadow = 0;
    float4 neighbour;

    neighbour = texCoord;
    neighbour.xy += offset.xy * texCoord.w;
    shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

    neighbour = texCoord;
    neighbour.xy -= offset.xy * texCoord.w;
    shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;

    shadow *= 1.0 / (float) 2;

    shadow = 1.0 - shadow * attenuation;
    shadow = shadow * shadow;

    return (half) shadow;
}

// -----------------------------------------------------
/**
	ディザ付き PCF
*/
half ShadowComparisonFilteredDither(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
#if 0
	half2 texCoordCenterOffset = ( (half2)( TFetch2D( g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE ).xy ) - 0.5h ) / (half2)shadowMapSize;
	float4 texCoord = baseTexCoord + float4( texCoordCenterOffset, 0.0, 0.0 ) * 0.25;	// ディザの散らし幅はちょっと抑制する
#else
    const half2 ditherOffsetScale = half2(0.25 / shadowMapSize.xy);
    const half2 ditherOffsetOffset = half2(-0.5 * 0.25 / shadowMapSize.xy);
    half2 texCoordCenterOffset = TFetch2DH(g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE).xy * ditherOffsetScale + ditherOffsetOffset;
    float4 texCoord = baseTexCoord + float4(texCoordCenterOffset, 0, 0) * baseTexCoord.w;
#endif
    half shadow = (half) ShadowComparisonFiltered(shadowMap, texCoord, shadowMapSize, attenuation);
    return shadow;
}

// -----------------------------------------------------
/**
	ディザ付き、周囲ランダムな1点フェッチ版
*/

half GetShadowComparison(Texture2D shadowMap, float4 texCoord)
{
#ifndef F_TARGET_XBOX360
    return (half) TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, texCoord.xyzw).x;
#else

	texCoord.xyzw = texCoord.xyzw / texCoord.w;

	float4 weights = 0;
	float4 depthValues = 0;
	float texLOD = 0;
	asm {
		setTexLOD texLOD;
		getWeights2D weights, texCoord.xy, shadowMap, MinFilter=linear, MagFilter=linear, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.x___, texCoord.xy, shadowMap, OffsetX=-0.5, OffsetY=-0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues._x__, texCoord.xy, shadowMap, OffsetX= 0.5, OffsetY=-0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.__x_, texCoord.xy, shadowMap, OffsetX=-0.5, OffsetY= 0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
		tfetch2D depthValues.___x, texCoord.xy, shadowMap, OffsetX= 0.5, OffsetY= 0.5, MinFilter=point, MagFilter=point, MipFilter=point, UseComputedLOD=false, UseRegisterLOD=true
	};
	weights.zw = float2(1, 1) - weights.xy;
	weights = weights.zxzx * weights.wwyy;
	float4 comparison = step(texCoord.zzzz, depthValues);
	return (half)( dot(comparison, weights) );
#endif
}

float ShadowComparisonFilteredRandomFetchFast(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
    half4 rand = TFetch2DH(g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE);
    half2 texCoordCenterOffset = ((half2) (rand.xy) - 0.5h) * 0.35h / (half2) shadowMapSize; // ディザの散らし幅はちょっと抑制する
    texCoord += float4(texCoordCenterOffset, 0.0, 0.0) * texCoord.w;

    half rotOffset = 3.1415926 * rand.z; // フェッチする点の基準位置を乱数で散らす
	
    float2 uv;
    float shadow = GetShadowComparison(shadowMap, texCoord.xyzw).x;

	// 半径1pixelので周囲の1点をフェッチする
    for (int j = 0; j < 1; j++)
    {
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
#if 1
	// ガウシアンフィルタ版に置き換える
    return ShadowComparisonFourSampleGaussianFilterWithMicroDither(shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation);
#else
	half4 rand 	= TFetch2DH( g_RandomTexture, SamplerLinear, screenTexCoord * INV_RANDOM_TEXTURE_SIZE );
	half2 texCoordCenterOffset = ( (half2)( rand.xy ) - 0.5h ) * 0.25h / (half2)shadowMapSize ;// ディザの散らし幅はちょっと抑制する
	texCoord += float4( texCoordCenterOffset, 0.0, 0.0 ) * texCoord.w;	
	
	half rotOffset = 3.1415926 * rand.z;	// フェッチする2点の基準位置を乱数で散らす
	
	float2 uv;
	float shadow = TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, texCoord.xyzw).x;
	
	// 半径1pixelので周囲の2点をフェッチする
	for ( int j = 0 ; j < 2 ; j++ ) {
		float4 neighbour = texCoord;
		sincos( 3.1415926/1*j+rotOffset, uv.x, uv.y );
		neighbour.xy += uv.xy / shadowMapSize * texCoord.w ;
		shadow += TFetch2DProjCmp(shadowMap, SamplerComparisonLessLinear, neighbour.xyzw).x;
	}
	shadow *= ( 1.0/3.0 );
	
	shadow = 1.0 - shadow * attenuation;
	shadow = shadow*shadow;

	return shadow;
#endif
}


// -----------------------------------------------------
/**
	Gaussian フィルタ版
*/
half ShadowComparisonFilteredGaussian(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float attenuation = 1.0)
{
#ifdef F_TARGET_XBOX360
	// -------------------------------------
	// 周囲9ピクセルをフェッチして平滑化する
	// -------------------------------------
	
	float  depthSamples ;
	float4 depthSamples1 ;
	float4 depthSamples2 ;
	float4 Weights;
	

	//asmコードは、実際にコンパイルされたあとも最適化による並べ替え等は発生していない様子、並列化の邪魔になるかもしれないので注意
	asm {
		tfetch2D depthSamples1.x___, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX = -1.0, OffsetY = -1.0
		tfetch2D depthSamples1._x__, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  0.0, OffsetY = -1.0
		tfetch2D depthSamples1.__x_, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  1.0, OffsetY = -1.0
		tfetch2D depthSamples1.___x, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX = -1.0, OffsetY =  0.0
		tfetch2D depthSamples.x___,  texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  0.0, OffsetY =  0.0
		tfetch2D depthSamples2.x___, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  1.0, OffsetY =  0.0
		tfetch2D depthSamples2._x__, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX = -1.0, OffsetY =  1.0
		tfetch2D depthSamples2.__x_, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  0.0, OffsetY =  1.0
		tfetch2D depthSamples2.___x, texCoord.xy, shadowMap, MagFilter=point, MinFilter=point, OffsetX =  1.0, OffsetY =  1.0
		
		getWeights2D Weights, texCoord.xy, shadowMap, MagFilter=linear, MinFilter=linear, UseComputedLOD=false, UseRegisterLOD=false, OffsetX=0.5, OffsetY=0.5
	};

	//float4 weight = float4( Weights.x * Weights.y, (1-Weights.x) * Weights.y, Weights.x * (1-Weights.y), (1-Weights.x) * (1-Weights.y) );
	float4	weight = float4( Weights.xy, (1.0).xx - Weights.xy );
	weight = weight.zxzx * weight.wwyy ;

	float4 compare1 = step( texCoord.zzzz, float4( depthSamples1.x, depthSamples1.y, depthSamples1.w, depthSamples ) );
	float4 compare2 = step( texCoord.zzzz, float4( depthSamples1.y, depthSamples1.z, depthSamples, depthSamples2.x ) );
	float4 compare3 = step( texCoord.zzzz, float4( depthSamples1.w, depthSamples, depthSamples2.y, depthSamples2.z ) );
	float4 compare4 = step( texCoord.zzzz, float4( depthSamples, depthSamples2.x, depthSamples2.z, depthSamples2.w ) );

	float shadow;
	//const float4 quater = float4( 0.25, 0.25, 0.25, 0.25 );
	//float4 compare = float4( dot( compare1, quater), dot( compare2, quater), dot( compare3, quater), dot( compare4, quater) );
	//shadow  = dot( compare, weight.wzyx );
	shadow = dot( compare1 + compare2 + compare3 + compare4 , weight ) / 4 ;
	
	shadow = 1.0 - shadow * attenuation;
	shadow = shadow * shadow ;
	
#else
	
#define NUM_SAMPLES (4)
    float2 invShadowMapSize = (1.0 / shadowMapSize);
    float4 offsetPixelSize = float4((invShadowMapSize * 0.3).xx, 0, 0);

    half shadow;
    shadow = TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(-1, -1, 0, 0))).x;
    shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(1, -1, 0, 0))).x;
    shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(-1, 1, 0, 0))).x;
    shadow += TFetch2DProjCmpH(shadowMap, SamplerComparisonLessLinear, texCoord + (offsetPixelSize * float4(1, 1, 0, 0))).x;

    shadow *= (half) attenuation;
	
	// ここで正の値になること保証しないと後のpowでwarninng出される
    shadow = (1.0h - (shadow * (half) (1.0 / NUM_SAMPLES)));

	// フィルタリングの結果はリニア空間でやると、影が薄くて綺麗にブレンドできない。
	// なので、sRGBのデータとして扱って、リニアに直して、ライトにたす。
	// 最後のシェーディングが終わったところsRGBに戻される
	// （ようするに、ここで計算した結果に戻す）
	//shadow = pow(shadow, DECODING_GAMMA);
	// pow は遅いので 2 乗で.
    shadow = shadow * shadow;
#endif

    return shadow;
}

// -----------------------------------------------------
/** 
	ディザ付きGaussian フィルタ版
*/
half ShadowComparisonFilteredGaussianWithDitherForSun(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
    const float2 INV_SHADOW_SUN_SIZE = (1.0 / SHADOW_SUN_SIZE);

#if 0
#ifdef F_TARGET_XBOX360
	float2 offsetCenter = (TFetch2D(g_RandomTexture, SamplerLinear, (screenTexCoord / RANDOM_TEXTURE_SIZE)).xy - 0.5) * INV_SHADOW_SUN_SIZE;
	float4 texcoord = float4( (baseTexCoord.xy + offsetCenter * 0.25), baseTexCoord.zw );
#else
	float2 offsetCenter = (TFetch2D(g_RandomTexture, SamplerLinear, (screenTexCoord / RANDOM_TEXTURE_SIZE)).xy - 0.5) * INV_SHADOW_SUN_SIZE;
	float4 texcoord = float4( (baseTexCoord.xy + offsetCenter * 0.25), baseTexCoord.zw );
#endif
#else
	// 2x2ディザによる微小なオフセット補正
    float2 ditherOffset = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
    float4 texcoord = float4((baseTexCoord.xy + ditherOffset * 0.125 * INV_SHADOW_SUN_SIZE), baseTexCoord.zw);
#endif
	
    return ShadowComparisonFilteredGaussian(shadowMap, texcoord, float2(SHADOW_SUN_SIZE, SHADOW_SUN_SIZE), attenuation);
}

half ShadowComparisonFilteredGaussianWithDitherForPointSpot(Texture2D shadowMap, float4 baseTexCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
    const float2 INV_SHADOW_SIZE = (1.0 / shadowMapSize);

#if 0	
	float2 offsetCenter = (TFetch2D(g_RandomTexture, SamplerLinear, (screenTexCoord / RANDOM_TEXTURE_SIZE)).xy - 0.5) * INV_SHADOW_SIZE;
	float4 texcoord = baseTexCoord.xyzw /= baseTexCoord.w;
	texcoord = float4( (texcoord.xy + (offsetCenter * 0.5f) ), texcoord.zw );
#else
	// 2x2ディザによる微小なオフセット補正
    float2 ditherOffset = step(float2(0.3, 0.3), frac(screenTexCoord.xy / 2.0)) * 2.0 - 1.0;
    float4 texcoord = baseTexCoord.xyzw /= baseTexCoord.w;
    texcoord = float4((texcoord.xy + ditherOffset * 0.125 * INV_SHADOW_SIZE), texcoord.zw);
#endif

    return ShadowComparisonFilteredGaussian(shadowMap, texcoord, shadowMapSize, attenuation);
}


// -----------------------------------------------------
/** 
	SunLight用 Shadowmap比較関数
	機種ごとに最適なアルゴリズムを選択
*/
half ShadowComparisonFilteredSunLight(Texture2D shadowMap, float4 baseTexCoord, float2 screenTexCoord, float attenuation = 1.0)
{
#ifdef F_TARGET_WIN32
	// ローカルライトと同様に基点＋周囲のランダムなピクセルフェッチでぼかす
	return (half)ShadowComparisonFilteredRandomFetch( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );
#endif	// ifdef F_TARGET_WIN32
	
#ifdef F_TARGET_XBOX360
	// 中心をずらしてガウシアンフィルタ
	return ShadowComparisonFilteredGaussianWithDitherForSun( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );	
	//return ShadowComparisonFilteredGaussian( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), attenuation );	
#endif	// ifdef F_TARGET_XBOX360
	
#ifdef F_TARGET_XBOXONE
	// ローカルライトと同様に基点＋周囲のランダムなピクセルフェッチでぼかす
	return (half)ShadowComparisonFilteredRandomFetch( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );
#endif	// ifdef F_TARGET_XBOXONE

#ifdef F_TARGET_PS3
	// 中心をずらしてガウシアンフィルタ
	//return ShadowComparisonFilteredGaussianWithDitherForSun( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );	
	//PS3はGPU力不足の為Qualityを落とす
	return ShadowComparisonTwoSampleWithDitherGaussianFilter( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );	
#endif	// ifdef F_TARGET_PS3
	
#ifdef F_TARGET_PS4
	// ローカルライトと同様に基点＋周囲のランダムなピクセルフェッチでぼかす
	return (half)ShadowComparisonFilteredRandomFetch( shadowMap, baseTexCoord, float2( SHADOW_SUN_SIZE, SHADOW_SUN_SIZE ), screenTexCoord, attenuation );
#endif	// ifdef F_TARGET_PS4
	
	
}

// -----------------------------------------------------
/** 
	PointLight用 Shadowmap比較関数
*/
float ShadowComparisonFilteredPointLight(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
#ifdef F_TARGET_WIN32
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif
#ifdef F_TARGET_XBOXONE
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif
#ifdef F_TARGET_PS4
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif

#ifdef F_TARGET_XBOX360
	return ShadowComparisonFilteredGaussianWithDitherForPointSpot( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif

#ifdef F_TARGET_PS3
	//return ShadowComparisonFilteredDither( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
	return ShadowComparisonTwoSampleWithDitherGaussianFilter( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif
}

// -----------------------------------------------------
/** 
	SpotLight用 Shadowmap比較関数
*/
float ShadowComparisonFilteredSpotLight(Texture2D shadowMap, float4 texCoord, const float2 shadowMapSize, float2 screenTexCoord, float attenuation = 1.0)
{
#ifdef F_TARGET_WIN32
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif
	
#ifdef F_TARGET_XBOXONE
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif

#ifdef F_TARGET_PS4
	return ShadowComparisonFilteredRandomFetch( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif


#ifdef F_TARGET_XBOX360
	return ShadowComparisonFilteredGaussianWithDitherForPointSpot( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif

#ifdef F_TARGET_PS3
	//return ShadowComparisonFilteredDither( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
	return ShadowComparisonTwoSampleWithDitherGaussianFilter( shadowMap, texCoord, shadowMapSize, screenTexCoord, attenuation );
#endif
}

#endif	// SHADOWCOMMON_H_
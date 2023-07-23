/**
	@file	VertexOperation.h
	@brief	頂点操作関連の関数定義
*/

// ----------------------------------------------------------------
/** @brief Skinning calculation
	@param[in]		bones			bone uniform struct
	@param[inout]	position		vertex position
	@param[in]		blendWeights	vertex bone weights
	@param[in]		blendIndices	vertex matrix indices
	@param[inout]	normal			vertex normal
	@param[inout]	tangent			vertex tangent

	calculate skinning in object local coordinate.
 */
inline void CalculateSkinning(VSBone bones,
							   inout float4 position, float4 blendWeights, uint4 blendIndices,
							   inout float3 normal, inout float3 tangent)
{
    TMatrix4x3 blendMatrix;
	/* ブレンドマトリクスを合成 */
    blendMatrix = bones.m_boneMatrices[blendIndices.x] * blendWeights.x;
    blendMatrix += bones.m_boneMatrices[blendIndices.y] * blendWeights.y;
    blendMatrix += bones.m_boneMatrices[blendIndices.z] * blendWeights.z;
    blendMatrix += bones.m_boneMatrices[blendIndices.w] * blendWeights.w;
	/* スキニング処理 */
    position.xyz = ApplyMatrixT(blendMatrix, position.xyzw);
    normal.xyz = ApplyMatrixT(blendMatrix, normal.xyz);
    tangent.xyz = ApplyMatrixT(blendMatrix, tangent.xyz);
	/* 法線の正規化 */
    normal.xyz = normal.xyz; // ワールドマトリクスを乗算後に正規化をすることを前提とする
    tangent.xyz = tangent.xyz; // ワールドマトリクスを乗算後に正規化をすることを前提とする
}
// ----------------------------------------------------------------
/** @brief Skinning calculation without tangent
	@param[in]		bones			bone uniform struct
	@param[inout]	position		vertex position
	@param[in]		blendWeights	vertex bone weights
	@param[in]		blendIndices	vertex matrix indices
	@param[inout]	normal			vertex normal

	calculate skinning in object local coordinate.
*/
inline void CalculateSkinning(VSBone bones,
							   inout float4 position, float4 blendWeights, uint4 blendIndices,
							   inout float3 normal)
{
    TMatrix4x3 blendMatrix;
	/* ブレンドマトリクスを合成 */
    blendMatrix = bones.m_boneMatrices[blendIndices.x] * blendWeights.x;
    blendMatrix += bones.m_boneMatrices[blendIndices.y] * blendWeights.y;
    blendMatrix += bones.m_boneMatrices[blendIndices.z] * blendWeights.z;
    blendMatrix += bones.m_boneMatrices[blendIndices.w] * blendWeights.w;
	/* スキニング処理 */
    position.xyz = ApplyMatrixT(blendMatrix, position.xyzw);
    normal.xyz = ApplyMatrixT(blendMatrix, normal.xyz);
	/* 法線の正規化 */
    normal.xyz = normal.xyz; // ワールドマトリクスを乗算後に正規化をすることを前提とする
}

// ----------------------------------------------------------------
/** @brief Skinning calculation (position only)
	@param[in]		bones			bone uniform struct
	@param[inout]	position		vertex position
	@param[in]		blendWeights	vertex bone weights
	@param[in]		blendIndices	vertex matrix indices
	
	calculate skinning in object local coordinate.
*/
inline void CalculateSkinningPos(VSBone bones,
							   inout float4 position, float4 blendWeights, uint4 blendIndices)
{
    TMatrix4x3 blendMatrix;
	/* ブレンドマトリクスを合成 */
    blendMatrix = bones.m_boneMatrices[blendIndices.x] * blendWeights.x;
    blendMatrix += bones.m_boneMatrices[blendIndices.y] * blendWeights.y;
    blendMatrix += bones.m_boneMatrices[blendIndices.z] * blendWeights.z;
    blendMatrix += bones.m_boneMatrices[blendIndices.w] * blendWeights.w;
	/* スキニング処理 */
    position.xyz = ApplyMatrixT(blendMatrix, position.xyzw);
}

// ----------------------------------------------------------------
/** @brief transform position
	@param[in]	Scene			scene uniform struct
	@param[in]	Object			object uniform struct
	@param[in]	position		position of local coordinate
	@param[out]	hPosition		position of homogeneous coordinate
	@return		worldPostion	position of world coordinate
 */
inline float4 TransformPosition(VSScene scene, VSObject object,
								 float4 position, out float4 hPosition)
{
#if 0
	float3	worldPosition ;
	float3	onCameraRelative ;
	float3	objectCenter ;
	
	/*
		カメラ相対で座標変換することによりfloatの精度落ちを軽減させる
		Foxではマトリクスを転置させた状態で利用しているので、もしかしたらこの処理は必要ないかも知れない
	 */

	// カメラ相対座標での座標を算出
	onCameraRelative = ApplyMatrixT( object.m_world, position.xyz );
	objectCenter.xyz = GetTranslateT( object.m_world ).xyz ;	// オブジェクトの中心座標
	onCameraRelative.xyz += objectCenter.xyz - scene.m_eyePos.xyz ;

	// そのまま透視変換
	TMatrix4x4	projectionView ;
	projectionView = scene.m_projectionView ;
	SetTranslateT( projectionView, GetTranslateT( scene.m_projection ) );
	hPosition.xyzw = ApplyMatrixT( projectionView, float4( onCameraRelative.xyz, 1.0 ) );

	// ワールド座標も求める
	worldPosition.xyz = onCameraRelative.xyz + scene.m_eyePos.xyz ;
#else
    float4 onCameraRelative;
    float3 worldPosition;
	//onCameraRelative = ApplyMatrixT( object.m_world, position );
	//hPosition.xyzw = ApplyMatrixT( scene.m_projectionView, onCameraRelative.xyzw );
	//onCameraRelative = ApplyMatrixT( object.m_projectionViewWorld, position );//object.m_projectionViewWorldの中身はview*worldなので注意
    onCameraRelative = ApplyMatrixT(object.m_viewWorld, position);
    hPosition.xyzw = ApplyMatrixT(scene.m_projection, onCameraRelative.xyzw);
    worldPosition.xyz = ApplyMatrixT(object.m_world, position).xyz;
#endif
    return float4(worldPosition, 1.0);
}

// ----------------------------------------------------------------
/** @brief transform position
	@param[in]	Scene			scene uniform struct
	@param[in]	Object			object uniform struct
	@param[in]	position		position of local coordinate
	@param[out]	hPosition		position of homogeneous coordinate
	@param[out]	viewPosition	position of view coordinate
	@return		worldPostion	position of world coordinate
 */
inline float4 TransformPosition(VSScene scene, VSObject object,
								 float4 position, out float4 hPosition, out float3 viewPosition)
{
    float4 onCameraRelative;
    float3 worldPosition;
	//onCameraRelative = ApplyMatrixT( object.m_projectionViewWorld, position );//object.m_projectionViewWorldの中身はview*worldなので注意
    onCameraRelative = ApplyMatrixT(object.m_viewWorld, position);
    hPosition.xyzw = ApplyMatrixT(scene.m_projection, onCameraRelative.xyzw);
    worldPosition.xyz = ApplyMatrixT(object.m_world, position).xyz;
    viewPosition.xyz = onCameraRelative.xyz;
    return float4(worldPosition, 1.0);
}
using System.Runtime.InteropServices;
using UnityEngine;

namespace FoxKit.TEST
{
	// --------------------------------
	// システムパラメータ
	[StructLayout(LayoutKind.Sequential)]
	public struct SSystem
	{
		Vector4 m_param;                 ///< wにアルファテストの閾値入れて使っている箇所があったので残しておきます
		Vector4 m_renderInfo;            ///< 現在のビューポートサイズが入る（VPOS/WPOS変換のため）
		Vector4 m_renderBuffer;          ///< (xy:現在レンダリング中バッファのサイズ,zw:サイズの逆数)
		Vector4 m_dominantLightDir;      ///< 支配的な光源方向（Viewspece）
	};

	// --------------------------------
	// シーン固有パラメータ定数
	[StructLayout(LayoutKind.Sequential)]
	public struct SScene
	{
		public Matrix4x4 m_projectionView;        ///< ( 投影 x ビュー )マトリクス
		public Matrix4x4 m_projection;            ///< 投影マトリクス
		public Matrix4x4 m_view;                  ///< ビューマトリクス
		public Matrix4x4 m_shadowProjection;      ///< 影投影マトリクス
		public Matrix4x4 m_shadowProjection2;     ///< 影投影マトリクス2
		public Vector4 m_eyepos;                  ///< 視点座標
		public Vector4 m_projectionParam;         ///< 投影パラメータ( Z => W 変換等用 )
		public Vector4 m_viewportSize;            ///< ビューポートサイズ
		public Vector4 m_exposure;                ///< 露出関連パラメータ
		private Vector4 _m_fogParam_0;            ///< フォグパラメータ
		private Vector4 _m_fogParam_1;
		private Vector4 _m_fogParam_2;
		public Vector4 GetFogParam(int index)
        {
            if (index < 0 || index > 2)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* fogParams = &_m_fogParam_0)
                    return fogParams[index];
            }
        }
		public void SetFogParam(int index, Vector4 value)
        {
            if (index < 0 || index > 2)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* fogParams = &_m_fogParam_0)
                    fogParams[index] = value;
            }
        }
		public Vector4 m_fogColor;                ///< フォグカラー
		public Vector4 m_cameraCenterOffset;      ///< ワールド座標上でのカメラセンター
		public Vector4 m_shadowMapResolutions;    ///< シャドウマップサイズ変更用のパラメータ対応
	};

	// --------------------------------
	// レンダーバッファ固有パラメータ定数
	[StructLayout(LayoutKind.Sequential)]
	public struct SRenderBuffer
	{
		Vector4 m_size;                      ///< xy = サイズ, zw = サイズの逆数
	};

	// --------------------------------
	// ライトパラメータ
	[StructLayout(LayoutKind.Sequential)]
	public struct SLights
	{
		private Vector4 _m_lightParams_0;
		private Vector4 _m_lightParams_1;
		private Vector4 _m_lightParams_2;
		private Vector4 _m_lightParams_3;
		private Vector4 _m_lightParams_4;
		private Vector4 _m_lightParams_5;
		private Vector4 _m_lightParams_6;
		private Vector4 _m_lightParams_7;
		private Vector4 _m_lightParams_8;
		private Vector4 _m_lightParams_9;
		private Vector4 _m_lightParams_10;
		public Vector4 GetMaterials(int index)
        {
            if (index < 0 || index > 10)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* lightParams = &_m_lightParams_0)
                    return lightParams[index];
            }
        }
		public void SetMaterials(int index, Vector4 value)
        {
            if (index < 0 || index > 10)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* lightParams = &_m_lightParams_0)
                    lightParams[index] = value;
            }
        }
	};

	// --------------------------------
	// マテリアルパラメータ
	[StructLayout(LayoutKind.Sequential)]
	public struct SMaterial
	{
		private Vector4 _m_materials_0;
		private Vector4 _m_materials_1;
		private Vector4 _m_materials_2;
		private Vector4 _m_materials_3;
		private Vector4 _m_materials_4;
		private Vector4 _m_materials_5;
		private Vector4 _m_materials_6;
		private Vector4 _m_materials_7;
		public Vector4 GetMaterials(int index)
        {
            if (index < 0 || index > 7)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* materials = &_m_materials_0)
                    return materials[index];
            }
        }
		public void SetMaterials(int index, Vector4 value)
        {
            if (index < 0 || index > 7)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* materials = &_m_materials_0)
                    materials[index] = value;
            }
        }
	};

	// --------------------------------
	// オブジェクト固有パラメータ定数
	[StructLayout(LayoutKind.Sequential)]
	public struct SObjectBase
	{
		public Matrix4x4 m_viewWorld;           ///< ( ビュー x ワールド )マトリクス
		public Matrix4x4 m_world;               ///< ワールドマトリクス
		public Vector4 m_useWeightCount;		///< スキニングの使用ウェイト数
	};
	// PSSL だと継承が通らないようなので、多重定義にする.
	// SObjectBase を編集する際には注意 !!
	//struct SObject : SObjectBase
	[StructLayout(LayoutKind.Sequential)]
	public struct SObject
	{
		public Matrix4x4 m_viewWorld;           ///< ( ビュー x ワールド )マトリクス
		public Matrix4x4 m_world;               ///< ワールドマトリクス
		public Vector4 m_useWeightCount;		///< スキニングの使用ウェイト数
		private Vector4 _m_localParam_0;        ///< ローカルパラメータ(各レンダリングフェーズのローカル処理で利用)
		private Vector4 _m_localParam_1;
		private Vector4 _m_localParam_2;
		private Vector4 _m_localParam_3;
		public Vector4 GetLocalParam(int index)
        {
            if (index < 0 || index > 3)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* localParams = &_m_localParam_0)
                    return localParams[index];
            }
		}
		public void SetLocalParam(int index, Vector4 value)
        {
            if (index < 0 || index > 3)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* localParams = &_m_localParam_0)
                    localParams[index] = value;
            }
        }
	};

	//// --------------------------------
	//// ボーンマトリクス配列
	//struct SBone
	//{
	//    TMatrix4x3 m_boneMatrices[32];      ///< ブレンドマトリクス(3x32)
	//    //TMatrix4x3		m_prevBoneMatrices[32];		///< ブレンドマトリクス(3x32)
	//};

	// --------------------------------
	// シェーディング、ポストフィルタ、2D等でもうボーンが必要ではないので、overlapできるようにする
	[StructLayout(LayoutKind.Explicit)]
	public struct SWork
	{
		[FieldOffset(0)] public Matrix4x4 m_viewInverse;		///< viewInverse (シェーディングでよく使いまわせる）
		[FieldOffset(64 * 1)] private Matrix4x4 _m_matrix_0;    ///< workMatrix[0]
		[FieldOffset(64 * 2)] private Matrix4x4 _m_matrix_1;
		[FieldOffset(64 * 3)] private Matrix4x4 _m_matrix_2;
		[FieldOffset(64 * 4)] private Matrix4x4 _m_matrix_3;
		[FieldOffset(64 * 5)] private Matrix4x4 _m_matrix_4;
		[FieldOffset(64 * 6)] private Matrix4x4 _m_matrix_5;
		[FieldOffset(64 * 7)] private Matrix4x4 _m_matrix_6;
		[FieldOffset(64 * 8)] private Matrix4x4 _m_matrix_7;
        public Matrix4x4 GetMatrix(int index)
        {
            if (index < 0 || index > 7)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed(Matrix4x4* matrices = &_m_matrix_0)
                    return matrices[index];
            }
        }

        // Make this the same size as the vertex version, but we will use it to upload a bunch of vector data
        [FieldOffset(16 *  0)] private Vector4 _m_vectors_0;
		[FieldOffset(16 *  1)] private Vector4 _m_vectors_1;
		[FieldOffset(16 *  2)] private Vector4 _m_vectors_2;
		[FieldOffset(16 *  3)] private Vector4 _m_vectors_3;
		[FieldOffset(16 *  4)] private Vector4 _m_vectors_4;
		[FieldOffset(16 *  5)] private Vector4 _m_vectors_5;
		[FieldOffset(16 *  6)] private Vector4 _m_vectors_6;
		[FieldOffset(16 *  7)] private Vector4 _m_vectors_7;
		[FieldOffset(16 *  8)] private Vector4 _m_vectors_8;
		[FieldOffset(16 *  9)] private Vector4 _m_vectors_9;
		[FieldOffset(16 * 10)] private Vector4 _m_vectors_10;
		[FieldOffset(16 * 11)] private Vector4 _m_vectors_11;
		[FieldOffset(16 * 12)] private Vector4 _m_vectors_12;
		[FieldOffset(16 * 13)] private Vector4 _m_vectors_13;
		[FieldOffset(16 * 14)] private Vector4 _m_vectors_14;
		[FieldOffset(16 * 15)] private Vector4 _m_vectors_15;
		[FieldOffset(16 * 16)] private Vector4 _m_vectors_16;
		[FieldOffset(16 * 17)] private Vector4 _m_vectors_17;
		[FieldOffset(16 * 18)] private Vector4 _m_vectors_18;
		[FieldOffset(16 * 19)] private Vector4 _m_vectors_19;
		[FieldOffset(16 * 20)] private Vector4 _m_vectors_20;
		[FieldOffset(16 * 21)] private Vector4 _m_vectors_21;
		[FieldOffset(16 * 22)] private Vector4 _m_vectors_22;
		[FieldOffset(16 * 23)] private Vector4 _m_vectors_23;
		[FieldOffset(16 * 24)] private Vector4 _m_vectors_24;
		[FieldOffset(16 * 25)] private Vector4 _m_vectors_25;
		[FieldOffset(16 * 26)] private Vector4 _m_vectors_26;
		[FieldOffset(16 * 27)] private Vector4 _m_vectors_27;
		[FieldOffset(16 * 28)] private Vector4 _m_vectors_28;
		[FieldOffset(16 * 29)] private Vector4 _m_vectors_29;
		[FieldOffset(16 * 30)] private Vector4 _m_vectors_30;
		[FieldOffset(16 * 31)] private Vector4 _m_vectors_31;
		[FieldOffset(16 * 32)] private Vector4 _m_vectors_32;
		[FieldOffset(16 * 33)] private Vector4 _m_vectors_33;
		[FieldOffset(16 * 34)] private Vector4 _m_vectors_34;
		[FieldOffset(16 * 35)] private Vector4 _m_vectors_35;
        public Vector4 GetVectors(int index)
        {
            if (index < 0 || index > 35)
                throw new System.IndexOutOfRangeException();

            unsafe
            {
                fixed (Vector4* vectors = &_m_vectors_0)
                    return vectors[index];
            }
        }
	}
}

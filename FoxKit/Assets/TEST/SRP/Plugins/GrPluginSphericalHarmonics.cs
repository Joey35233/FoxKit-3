using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public class GrPluginSphericalHarmonics : GrRenderPlugin
    {
        public override string Name => "SphericalHarmonics";

        CommandBuffer Buffer;

        private static class TextureIds
        {
            public static int g_sphericalMaps = Shader.PropertyToID("g_sphericalMaps");
            public static int g_NormalTexture = Shader.PropertyToID("g_NormalTexture");

            // CopyRenderBuffer
            public static int inImage = Shader.PropertyToID("inImage");

            // SSLighting2_SH_SkyLight_Encode
            public static int inDiffuseAccBuf = Shader.PropertyToID("inDiffuseAccBuf");
            public static int g_shMaskTex = Shader.PropertyToID("g_shMaskTex");
        }

        private static class RtIds
        {
            public static int SHAtlas = Shader.PropertyToID("SHAtlas");

            public static int SHMask = Shader.PropertyToID("SHMask");

            public static int TempHalfResDiffAccBuffer = Shader.PropertyToID("TempHalfResDiffAccBuffer");
            public static int FinalHalfResDiffAccBuffer = Shader.PropertyToID("FinalHalfResDiffAccBuffer");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier SHAtlas;

        public RenderTargetIdentifier SHMask;

        public RenderTargetIdentifier TempHalfResDiffAccBuffer;
        public RenderTargetIdentifier FinalHalfResDiffAccBuffer;

        private Material SphereMapMaterial;
        private Material CopyHalfResBufferMaterial;
        private Material SkyEncodeMaterial;

        SkyCoefficientsSet kSkyCoefficients10am;
        Matrix4x4 SkyCoefficientsMatrixR;
        Matrix4x4 SkyCoefficientsMatrixG;
        Matrix4x4 SkyCoefficientsMatrixB;

        public GrPluginSphericalHarmonics()
        {
            Buffer = new CommandBuffer { name = Name };

            SphereMapMaterial = CoreUtils.CreateEngineMaterial("Fox/SH_SphereMap");
            CopyHalfResBufferMaterial = CoreUtils.CreateEngineMaterial("Fox/CopyRenderBuffer");
            SkyEncodeMaterial = CoreUtils.CreateEngineMaterial("Fox/SSLighting2_SH_SkyLight_Encode");

            kSkyCoefficients10am = new SkyCoefficientsSet
            {
                Coefficients = new CoefficientsSet
                {
                    c00 = new Vector3(16560.000000f, 18240.000000f, 23888.000000f),

                    c10 = new Vector3(-213.250000f, -245.750000f, -334.750000f),
                    c11 = new Vector3(-2360.000000f, 1256.000000f, 6948.000000f),
                    c12 = new Vector3(-1228.000000f, -1605.000000f, -2130.000000f),

                    c20 = new Vector3(116.812500f, 138.250000f, 162.875000f),
                    c21 = new Vector3(-102.562500f, -129.375000f, -149.250000f),
                    c22 = new Vector3(-415.250000f, -414.500000f, -387.750000f),
                    c23 = new Vector3(-662.500000f, -812.500000f, -1015.500000f),
                    c24 = new Vector3(275.000000f, 319.000000f, 366.750000f),
                },

                SunColor = new Vector3(79104.000000f, 70784.000000f, 55584.000000f),
            };
            kSkyCoefficients10am.Coefficients = FlipCoefficientsHandedness(kSkyCoefficients10am.Coefficients);
            SkyCoefficientsMatrixR = GetCoeffcientsMatrix(kSkyCoefficients10am.Coefficients, 0);
            SkyCoefficientsMatrixG = GetCoeffcientsMatrix(kSkyCoefficients10am.Coefficients, 1);
            SkyCoefficientsMatrixB = GetCoeffcientsMatrix(kSkyCoefficients10am.Coefficients, 2);
        }

        const int SpheremapSize = 16;

        const int SpheresPerAtlasX = 8;
        const int SpheresPerAtlasY = 32;

        const int SHAtlasWidth = SpheremapSize * SpheresPerAtlasX;
        const int SHAtlasHeight = SpheremapSize * SpheresPerAtlasY;

        public override void Render(ScriptableRenderContext context, Camera camera)
        {
            // Atlas
            {
                var atlasDesc = new RenderTextureDescriptor(SHAtlasWidth, SHAtlasHeight, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm, 0, 1);

                Buffer.GetTemporaryRT(RtIds.SHAtlas, atlasDesc, FilterMode.Point);
                SHAtlas = new RenderTargetIdentifier(RtIds.SHAtlas);
            }

            // Half-res buffers
            // For now, embrace implicit int floor()
            var halfResBufferSize = new Vector2(Math.Max(camera.pixelWidth / 2, 1), Math.Max(camera.pixelHeight / 2, 1));
            {
                var halfResBufferDesc = new RenderTextureDescriptor((int)halfResBufferSize.x, (int)halfResBufferSize.y, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm, 0, 1);

                // For all local probes
                Buffer.GetTemporaryRT(RtIds.TempHalfResDiffAccBuffer, halfResBufferDesc, FilterMode.Point);
                TempHalfResDiffAccBuffer = new RenderTargetIdentifier(RtIds.TempHalfResDiffAccBuffer);

                // Encode sky as final pass
                Buffer.GetTemporaryRT(RtIds.FinalHalfResDiffAccBuffer, halfResBufferDesc, FilterMode.Point);
                FinalHalfResDiffAccBuffer = new RenderTargetIdentifier(RtIds.FinalHalfResDiffAccBuffer);

                // Unknown purpose
                halfResBufferDesc.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm;
                Buffer.GetTemporaryRT(RtIds.SHMask, halfResBufferDesc, FilterMode.Point);
                SHMask = new RenderTargetIdentifier(RtIds.SHMask);
            }

            // Draw SH atlas
            Buffer.SetRenderTarget(SHAtlas);
            // FLIP VIEWPORT
            Buffer.SetViewport(new Rect(0, SHAtlasHeight - SpheremapSize, SpheremapSize, SpheremapSize));
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSH_m_matrix_0", SkyCoefficientsMatrixR);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSH_m_matrix_1", SkyCoefficientsMatrixG);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSH_m_matrix_2", SkyCoefficientsMatrixB);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSH_m_matrix_3", Matrix4x4.zero);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSHSky_m_matrix_0", Matrix4x4.zero);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSHSky_m_matrix_1", Matrix4x4.zero);
            SphereMapMaterial.SetMatrix("UnityPatch_g_psParamSHSky_m_matrix_2", Matrix4x4.zero);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, SphereMapMaterial);

            // Local SH map pass (just do a dummy fill for now). Make sure to set W (weight) to 1 to only draw sky.
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERINFO, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 0, 0));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERBUFFER_SIZE, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 1f / halfResBufferSize.x, 1f / halfResBufferSize.y));
            Buffer.SetRenderTarget(TempHalfResDiffAccBuffer);
            Buffer.ClearRenderTarget(false, true, Color.black);

            // Mask texture
            Buffer.SetRenderTarget(SHMask);
            Buffer.ClearRenderTarget(false, true, Color.black);

            // Copy to final
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(0, 0, 1f / SpheresPerAtlasX, 1f / SpheresPerAtlasY));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_LOCALPARAM1, new Vector4(-0.5f / camera.pixelWidth, -0.5f / camera.pixelHeight, 0, 0));
            Buffer.SetGlobalTexture(TextureIds.inImage, TempHalfResDiffAccBuffer);
            Buffer.SetRenderTarget(FinalHalfResDiffAccBuffer);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, CopyHalfResBufferMaterial);

            // Sky encoding
            Buffer.SetGlobalTexture(TextureIds.g_shMaskTex, TempHalfResDiffAccBuffer);
            Buffer.SetGlobalTexture(TextureIds.inDiffuseAccBuf, TempHalfResDiffAccBuffer);
            Buffer.SetGlobalTexture(TextureIds.g_NormalTexture, ((from plugin in FoxRenderer.Plugins where plugin.Name == "DeferredGeometry" select plugin).First() as GrPluginDeferredGeometry).NormalBuffer);
            Buffer.SetGlobalTexture(TextureIds.g_sphericalMaps, SHAtlas);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, SkyEncodeMaterial);

            // Reset for full-res pass
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERINFO, new Vector4(camera.pixelWidth, camera.pixelHeight, 0, 0));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERBUFFER_SIZE, new Vector4(camera.pixelWidth, camera.pixelHeight, 1f / camera.pixelWidth, 1f / camera.pixelHeight));

            context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            context.Submit();
        }

        private struct CoefficientsSet
        {
                                // Band   Basis
            public Vector3 c00; //  0       0

            public Vector3 c10; //  1      -1
            public Vector3 c11; //  1       0 
            public Vector3 c12; //  1       1

            public Vector3 c20; //  2      -2
            public Vector3 c21; //  2      -1
            public Vector3 c22; //  2       0
            public Vector3 c23; //  2       1
            public Vector3 c24; //  2       2
        }
        private static CoefficientsSet FlipCoefficientsHandedness(CoefficientsSet coefficients)
        {
            CoefficientsSet copy = coefficients;
            copy.c12 *= -1;
            copy.c21 *= -1;
            copy.c20 *= -1;

            return copy;
        }

        private static float a0 = Mathf.Sqrt(1f / (4f * Mathf.PI));
        private static float a1 = Mathf.Sqrt(3f / (4f * Mathf.PI));
        private static float a2 = Mathf.Sqrt(15f / (4f * Mathf.PI));
        private static float a3 = Mathf.Sqrt(5f / (16f * Mathf.PI));
        private static float a4 = Mathf.Sqrt(15f / (16f * Mathf.PI));
        private static Matrix4x4 GetCoeffcientsMatrix(CoefficientsSet s, int c)
        {
            // [ +a4*c24  , a2*c20/2 , a2*c23/2 , a1*c12/2      ]
            // [ a2*c20/2 , -a4*c24  , a2*c21/2 , a1*c10/2      ]
            // [ a2*c23/2 , a2*c21/2 , 3*a3*c22 , a1*c11/2      ]
            // [ a1*c12/2 , a1*c10/2 , a1*c11/2 , a0*c00-a3*c22 ]
            var result = new Matrix4x4
            {
                m00 = a4*s.c24[c],   m10 = a2*s.c20[c]/2, m20 = a2*s.c23[c]/2, m30 = a1*s.c12[c]/2,
                m01 = a2*s.c20[c]/2, m11 = -a4*s.c24[c],  m21 = a2*s.c21[c]/2, m31 = a1*s.c10[c]/2,
                m02 = a2*s.c23[c]/2, m12 = a2*s.c21[c]/2, m22 = 3*a3*s.c22[c], m32 = a1*s.c11[c]/2,
                m03 = a1*s.c12[c]/2, m13 = a1*s.c10[c]/2, m23 = a1*s.c11[c]/2, m33 = a0*s.c00[c] - a3*s.c22[c]
            };

            return result;
        }

        private struct SkyCoefficientsSet
        {
            public CoefficientsSet Coefficients;

            public Vector3 SunColor;
        }
    }
}
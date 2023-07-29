using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using System;

namespace FoxKit.TEST
{
    public class GrPluginLineIntegralSSAO : GrRenderPlugin
    {
        public override string Name => "LineIntegralSSAO";

        CommandBuffer Buffer;

        private static class TextureIds
        {
            // DownSampleDepth
            public static int inTexture = Shader.PropertyToID("inTexture");

            // SSAOLineIntegrals
            public static int inLinearDepth = Shader.PropertyToID("inLinearDepth");
            public static int inRotations = Shader.PropertyToID("inRotations");

            // blur_Gaussian1D_Bilateral_X/Y
            public static int inImage = Shader.PropertyToID("inImage");
        }

        private static class RtIds
        {
            public static int TempDepthBuffer = Shader.PropertyToID("HalfResDepthBuffer");
            public static int TempBlurTextureA = Shader.PropertyToID("TempBlurTextureA");
            public static int TempBlurTextureB = Shader.PropertyToID("TempBlurTextureB");

            public static int LISSAOTexture = Shader.PropertyToID("LISSAOTexture");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier LinearDepthTextureId;
        public RenderTargetIdentifier RotationsId;

        public RenderTargetIdentifier TempDepthBuffer;
        public RenderTargetIdentifier TempBlurTextureA;
        public RenderTargetIdentifier TempBlurTextureB;

        public RenderTargetIdentifier LISSAOTexture;

        private Material DownSampleDepthMaterial;
        private Material MainMaterial;
        private Material BlurXMaterial;
        private Material BlurYMaterial;
        private Material ResultAlphaToRGBMaterial;

        private Texture2D RotationsTexture;

        public GrPluginLineIntegralSSAO()
        {
            Buffer = new CommandBuffer { name = Name };

            DownSampleDepthMaterial = new Material(Shader.Find("Fox/DownSampleDepth"));
            MainMaterial = new Material(Shader.Find("Fox/SSAOLineIntegrals"));
            BlurXMaterial = new Material(Shader.Find("Fox/blur_Gaussian1D_Bilateral_X"));
            BlurYMaterial = new Material(Shader.Find("Fox/blur_Gaussian1D_Bilateral_Y"));
            //ResultAlphaToRGBMaterial = new Material(Shader.Find("Fox/SSAOAlphaToRGB"));

            RotationsTexture = new Texture2D(4, 4, TextureFormat.RGHalf, false);
            RotationsTexture.SetPixels
            (
                new Color[]
                {
                    new Color(- 0.21704f, 0.97607f, 0, 0),  new Color(0.81494f, 0.5791f, 0, 0),  new Color(0.36792f, 0.92969f, 0, 0),  new Color(0.9043f, 0.42676f, 0, 0),
                    new Color(0.98877f, 0.14832f, 0, 0), new Color(- 0.93359f, 0.35693f, 0, 0),  new Color(0.7168f, 0.69678f, 0, 0), new Color(- 0.38281f, 0.92334f, 0, 0),
                    new Color(- 0.70166f, 0.71191f, 0, 0),  new Color(0.16284f, 0.98633f, 0, 0), new Color(- 0.02782f, 0.99951f, 0, 0),  new Color(0.53467f, 0.84473f, 0, 0),
                    new Color(- 0.83203f, 0.55371f, 0, 0), new Color(- 0.98193f, 0.1875f, 0, 0), new Color(- 0.55615f, 0.83057f, 0, 0),  new Color(0.99854f, -0.04904f, 0, 0),
                }
            );
            RotationsTexture.Apply();
        }

        protected override void Render()
        {
            // For now, embrace implicit int floor()
            var halfResBufferSize = new Vector2(Math.Max(Camera.pixelWidth / 2, 1), Math.Max(Camera.pixelHeight / 2, 1));

            var descriptor = new RenderTextureDescriptor((int)halfResBufferSize.x, (int)halfResBufferSize.y);
            descriptor.depthBufferBits = 0;
            descriptor.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.B8G8R8A8_UNorm;
            descriptor.msaaSamples = 1;
            descriptor.dimension = TextureDimension.Tex2D;

            Buffer.GetTemporaryRT(RtIds.TempBlurTextureA, descriptor, FilterMode.Point);
            TempBlurTextureA = new RenderTargetIdentifier(RtIds.TempBlurTextureA);
            Buffer.GetTemporaryRT(RtIds.TempBlurTextureB, descriptor, FilterMode.Point);
            TempBlurTextureB = new RenderTargetIdentifier(RtIds.TempBlurTextureB);

            descriptor.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.None;
            descriptor.colorFormat = RenderTextureFormat.Depth;
            descriptor.depthBufferBits = 32;
            Buffer.GetTemporaryRT(RtIds.TempDepthBuffer, descriptor, FilterMode.Point);
            TempDepthBuffer = new RenderTargetIdentifier(RtIds.TempDepthBuffer);

            // Set globals
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERINFO, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 0, 0));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERBUFFER_SIZE, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 1f / halfResBufferSize.x, 1f / halfResBufferSize.y));

            // Downsample depth buffer
            Buffer.SetRenderTarget(TempDepthBuffer);
            DgShaderDefine.SetVector(DownSampleDepthMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(0.5f / Camera.pixelWidth, 0.5f / Camera.pixelHeight, 0, 0));
            Buffer.SetGlobalTexture(TextureIds.inTexture, ((from plugin in FoxRenderer.Plugins where plugin.Name == "DeferredGeometry" select plugin).First() as GrPluginDeferredGeometry).DepthBufferId);
            Buffer.DrawMesh(DgUtils.FullscreenMeshWithUVs, Matrix4x4.identity, DownSampleDepthMaterial);

            // Draw initial pass (skip depth downsampling for now)
            // ----------------------------------------
            Buffer.SetRenderTarget(TempBlurTextureA);

            float innerRadius = 0.2f;
            float outerRadius = 2f;
            float maxDistanceInner = 1.5f;
            float maxDistanceOuter = 5f;
            float invMaxDistanceInner = 2f / 3f;
            float invMaxDistanceOuter = 1f / 3f;
            float falloffDistanceBias = -(400 + 100);
            float falloffDistanceScale = -1 / 100f;
            float fallonDistanceBias = 0.069f;
            float fallonDistanceScale = 1 / 10f;

            DgShaderDefine.SetVector(MainMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(innerRadius, outerRadius, fallonDistanceBias, fallonDistanceScale));
            DgShaderDefine.SetVector(MainMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM1, new Vector4(maxDistanceInner, maxDistanceOuter, 0, 0));
            DgShaderDefine.SetVector(MainMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM2, new Vector4(invMaxDistanceInner, invMaxDistanceOuter, 0, 0));
            DgShaderDefine.SetVector(MainMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM3, new Vector4(falloffDistanceBias, falloffDistanceScale, 0, 0));

            MainMaterial.SetTexture(TextureIds.inRotations, RotationsTexture);
            Buffer.SetGlobalTexture(TextureIds.inLinearDepth, TempDepthBuffer);

            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, MainMaterial);

            // Blurs
            DgShaderDefine.SetVector(BlurXMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(0, 0, 1f - 0.5f / halfResBufferSize.x, 1f - 0.5f / halfResBufferSize.y));
            DgShaderDefine.SetVector(BlurXMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM1, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 1f / halfResBufferSize.x, 1f / halfResBufferSize.y));
            Buffer.SetRenderTarget(TempBlurTextureB);
            Buffer.SetGlobalTexture(TextureIds.inImage, TempBlurTextureA);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, BlurXMaterial);

            DgShaderDefine.SetVector(BlurYMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(0, 0, 1f - 0.5f / halfResBufferSize.x, 1f - 0.5f / halfResBufferSize.y));
            DgShaderDefine.SetVector(BlurYMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM1, new Vector4(halfResBufferSize.x, halfResBufferSize.y, 1f / halfResBufferSize.x, 1f / halfResBufferSize.y));
            Buffer.SetRenderTarget(TempBlurTextureA);
            Buffer.SetGlobalTexture(TextureIds.inImage, TempBlurTextureB);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, BlurYMaterial);

            // Copy alpha to full-res output buffer


            // Reset and submit
            // ----------------------------------------
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERINFO, new Vector4(Camera.pixelWidth, Camera.pixelHeight, 0, 0));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERBUFFER_SIZE, new Vector4(Camera.pixelWidth, Camera.pixelHeight, 1f / Camera.pixelWidth, 1f / Camera.pixelHeight));

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            Context.Submit();
        }
    }
}
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace FoxKit.TEST
{
    public class GrPluginDeferredGeometry : GrRenderPlugin
    {
        public override string Name => "DeferredGeometry";

        CommandBuffer Buffer;

        CullingResults CullingResults;

        private static class TextureIds
        {
            public static int g_tex_mesh = Shader.PropertyToID("g_tex_mesh");
            public static int g_MaterialTexture = Shader.PropertyToID("g_MaterialTexture");

            public static int g_tex_diffuse = Shader.PropertyToID("g_tex_diffuse");
            public static int g_tex_normal = Shader.PropertyToID("g_tex_normal");
            public static int g_tex_srm = Shader.PropertyToID("g_tex_srm");
            public static int g_tex_materialmap = Shader.PropertyToID("g_tex_materialmap");
            public static int g_tex_layer = Shader.PropertyToID("g_tex_layer");
            public static int g_tex_layerMask = Shader.PropertyToID("g_tex_layerMask");
            public static int g_tex_Dirty = Shader.PropertyToID("g_tex_Dirty");
        }

        private static class RtIds
        {
            public static int AlbedoBuffer = Shader.PropertyToID("AlbedoBuffer");
            public static int NormalBuffer = Shader.PropertyToID("NormalBuffer");
            public static int SpecularBuffer = Shader.PropertyToID("SpecularBuffer");

            public static int DepthBuffer = Shader.PropertyToID("DepthBuffer");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier AlbedoBuffer;
        public RenderTargetIdentifier NormalBuffer;
        public RenderTargetIdentifier SpecularBuffer;
        private RenderTargetIdentifier[] GBuffers = new RenderTargetIdentifier[3];
        public RenderTargetIdentifier DepthBuffer;

        public GrPluginDeferredGeometry()
        {
            Buffer = new CommandBuffer { name = Name };
            
            Shader.SetGlobalTexture(TextureIds.g_tex_mesh, AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TEST/ASSETS/gr_dither_nrt_32b.dds"));
            Shader.SetGlobalTexture(TextureIds.g_MaterialTexture, AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TEST/ASSETS/materials_alp_rgba32_nomip_nrt.exr"));
        }

        public override void Render(ScriptableRenderContext context, Camera camera)
        {
            var gbufferDesc = new RenderTextureDescriptor(camera.pixelWidth, camera.pixelHeight, UnityEngine.Experimental.Rendering.GraphicsFormat.B8G8R8A8_UNorm, 0, 1);

            Buffer.GetTemporaryRT(RtIds.AlbedoBuffer, gbufferDesc, FilterMode.Point);
            AlbedoBuffer = new RenderTargetIdentifier(RtIds.AlbedoBuffer);
            GBuffers[0] = AlbedoBuffer;

            Buffer.GetTemporaryRT(RtIds.NormalBuffer, gbufferDesc, FilterMode.Point);
            NormalBuffer = new RenderTargetIdentifier(RtIds.NormalBuffer);
            GBuffers[1] = NormalBuffer;

            Buffer.GetTemporaryRT(RtIds.SpecularBuffer, gbufferDesc, FilterMode.Point);
            SpecularBuffer = new RenderTargetIdentifier(RtIds.SpecularBuffer);
            GBuffers[2] = SpecularBuffer;

            gbufferDesc.colorFormat = RenderTextureFormat.Depth;
            gbufferDesc.depthBufferBits = 32;
            Buffer.GetTemporaryRT(RtIds.DepthBuffer, gbufferDesc, FilterMode.Point);
            DepthBuffer = new RenderTargetIdentifier(RtIds.DepthBuffer);

            Buffer.SetRenderTarget(GBuffers, DepthBuffer);
            Buffer.ClearRenderTarget(true, true, Color.clear);

            context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            var sortingSettings = new SortingSettings(camera);
            var drawingSettings = new DrawingSettings(ShaderIds.MAIN, sortingSettings);
            var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);

            ScriptableCullingParameters param;
            if (camera.TryGetCullingParameters(out param))
            {
                CullingResults = context.Cull(ref param);

                RendererListParams rendererListParam = new RendererListParams(CullingResults, drawingSettings, filteringSettings);
                RendererList rendererList = context.CreateRendererList(ref rendererListParam);
                Buffer.DrawRendererList(rendererList);
            }

            //Buffer.SetInvertCulling(false);
            context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();
            context.Submit();
        }
    }
}
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

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
            public static int inAlbedoTexture = Shader.PropertyToID("inAlbedoTexture");
            public static int g_NormalTexture = Shader.PropertyToID("g_NormalTexture");
            public static int g_SpecularTexture = Shader.PropertyToID("g_SpecularTexture");

            public static int g_DepthTexture = Shader.PropertyToID("g_DepthTexture");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier[] RenderTargetIds = new RenderTargetIdentifier[3];
        public RenderTargetIdentifier DepthBufferId;

        public GrPluginDeferredGeometry()
        {
            Buffer = new CommandBuffer { name = Name };
            
            Shader.SetGlobalTexture(TextureIds.g_tex_mesh, AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TEST/ASSETS/gr_dither_nrt_32b.dds"));
            Shader.SetGlobalTexture(TextureIds.g_MaterialTexture, AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TEST/ASSETS/materials_alp_rgba32_nomip_nrt.exr"));
        }

        protected override void Render()
        {
            var descriptor = new RenderTextureDescriptor(Camera.pixelWidth, Camera.pixelHeight);
            descriptor.width = Camera.pixelWidth;
            descriptor.height = Camera.pixelHeight;
            descriptor.depthBufferBits = 0;
            descriptor.colorFormat = RenderTextureFormat.BGRA32;
            descriptor.msaaSamples = 1;
            descriptor.dimension = TextureDimension.Tex2D;

            Buffer.GetTemporaryRT(RtIds.inAlbedoTexture, descriptor, FilterMode.Point);
            RenderTargetIds[0] = new RenderTargetIdentifier(RtIds.inAlbedoTexture);

            Buffer.GetTemporaryRT(RtIds.g_NormalTexture, descriptor, FilterMode.Point);
            RenderTargetIds[1] = new RenderTargetIdentifier(RtIds.g_NormalTexture);

            Buffer.GetTemporaryRT(RtIds.g_SpecularTexture, descriptor, FilterMode.Point);
            RenderTargetIds[2] = new RenderTargetIdentifier(RtIds.g_SpecularTexture);

            descriptor.colorFormat = RenderTextureFormat.Depth;
            descriptor.depthBufferBits = 32;
            Buffer.GetTemporaryRT(RtIds.g_DepthTexture, descriptor, FilterMode.Point);
            DepthBufferId = new RenderTargetIdentifier(RtIds.g_DepthTexture);

            Buffer.SetRenderTarget(RenderTargetIds, DepthBufferId);
            Buffer.ClearRenderTarget(true, true, Color.clear);

            {
                float near = Camera.nearClipPlane;
                float far = Camera.farClipPlane;

                Matrix4x4 matrix = Matrix4x4.zero;
                matrix[1, 1] = 1 / Mathf.Tan(Camera.fieldOfView / 2 * Mathf.Deg2Rad);
                matrix[0, 0] = matrix[1, 1] / Camera.aspect;
                matrix[2, 2] = near / (near - far);
                matrix[2, 3] = (near * far) / (far - near);
                matrix[3, 2] = -1; // Right handedness
                Buffer.SetGlobalMatrix("UnityPatch_SScene_m_projection", matrix);
            }

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            var sortingSettings = new SortingSettings(Camera);
            var drawingSettings = new DrawingSettings(ShaderIds.MAIN, sortingSettings);
            var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);

            if (!Cull())
                goto cleanup;

            Context.DrawRenderers(CullingResults, ref drawingSettings, ref filteringSettings);

        cleanup:

            Context.Submit();
        }

        bool Cull()
        {
            ScriptableCullingParameters param;

            if (Camera.TryGetCullingParameters(out param))
            {
                CullingResults = Context.Cull(ref param);
                return true;
            }

            return false;
        }
    }
}
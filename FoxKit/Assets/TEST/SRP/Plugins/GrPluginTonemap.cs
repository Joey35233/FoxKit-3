using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public class GrPluginTonemap : GrRenderPlugin
    {
        public override string Name => "Tonemap";

        CommandBuffer Buffer;

        private static class TextureIds
        {
            public static int g_tex_fog = Shader.PropertyToID("g_tex_fog");
            public static int inAlbedo = Shader.PropertyToID("inAlbedo");
            public static int inLightDiffuse = Shader.PropertyToID("inLightDiffuse");
            public static int inLightSpecular = Shader.PropertyToID("inLightSpecular");
            public static int inDepth = Shader.PropertyToID("inDepth");
            public static int inOcclusion = Shader.PropertyToID("inOcclusion");
            //public static int inMesh = Shader.PropertyToID("inMesh");
        }

        private static class RtIds
        {
            public static int Output = Shader.PropertyToID("Output");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier Output;

        private Material Material_VolFog_TppTonemap;

        public GrPluginTonemap()
        {
            Buffer = new CommandBuffer { name = Name };

            Material_VolFog_TppTonemap = new Material(Shader.Find("Fox/DR_VolFog_TppTonemap"));
        }

        public override void Render(ScriptableRenderContext context, Camera camera)
        {
            // Output buffer
            var outputBufferDesc = new RenderTextureDescriptor(camera.pixelWidth, camera.pixelHeight, UnityEngine.Experimental.Rendering.GraphicsFormat.B8G8R8A8_UNorm, 0, 1);
            Buffer.GetTemporaryRT(RtIds.Output, outputBufferDesc, FilterMode.Point);
            Output = new RenderTargetIdentifier(RtIds.Output);

            Buffer.SetRenderTarget(Output);

            // Get vol fog plugin
            var volFogPlugin = ((from plugin in FoxRenderer.Plugins where plugin.Name == "GlobalVolumetricFog" select plugin).First() as GrPluginGlobalVolumetricFog);
            // Get gbuffer plugin
            var deferredGeometryPlugin = ((from plugin in FoxRenderer.Plugins where plugin.Name == "DeferredGeometry" select plugin).First() as GrPluginDeferredGeometry);
            // Get SH plugin
            var shPlugin = ((from plugin in FoxRenderer.Plugins where plugin.Name == "SphericalHarmonics" select plugin).First() as GrPluginSphericalHarmonics);
            // Get SH plugin
            var ssaoPlugin = ((from plugin in FoxRenderer.Plugins where plugin.Name == "LineIntegralSSAO" select plugin).First() as GrPluginLineIntegralSSAO);

            Buffer.SetGlobalTexture(TextureIds.g_tex_fog, volFogPlugin.FogTexture);
            Buffer.SetGlobalTexture(TextureIds.inAlbedo, deferredGeometryPlugin.AlbedoBuffer);
            Buffer.SetGlobalTexture(TextureIds.inLightDiffuse, shPlugin.FinalHalfResDiffAccBuffer);
            //Buffer.SetGlobalTexture(TextureIds.inLightSpecular, deferredGeometryPlugin.AlbedoBuffer);
            Buffer.SetGlobalTexture(TextureIds.inDepth, deferredGeometryPlugin.DepthBuffer);
            Buffer.SetGlobalTexture(TextureIds.inOcclusion, ssaoPlugin.LISSAOTexture);

            DgShaderDefine.SetVector(Material_VolFog_TppTonemap, DgShaderDefine.ConstantId.V_MATERIAL0, new Vector4(4.86592f, 0.60f, 0.45333f, 0));
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, Material_VolFog_TppTonemap);

            context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            context.Submit();
        }
    }
}
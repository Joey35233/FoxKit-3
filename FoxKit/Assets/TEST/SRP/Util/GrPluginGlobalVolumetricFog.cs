using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public class GrPluginGlobalVolumetricFog : GrRenderPlugin
    {
        public override string Name => "GlobalVolumetricFog";

        CommandBuffer Buffer;

        private static class TextureIds
        {
        }

        private static class RtIds
        {
            public static int inInterruptTexture = Shader.PropertyToID("inInterruptTexture");

            public static int g_tex_fog = Shader.PropertyToID("g_tex_fog");
        }

        private static class ShaderIds
        {
            public static ShaderTagId MAIN = new ShaderTagId("MAIN");
        }

        public RenderTargetIdentifier InterruptTextureId;
        public RenderTargetIdentifier FogTextureId;

        private Mesh FogMesh;
        private Material FogMaterial;

        public GrPluginGlobalVolumetricFog()
        {
            Buffer = new CommandBuffer { name = Name };

            FogMesh = AssetDatabase.LoadAssetAtPath<Mesh>("Assets/TEST/ASSETS/VolFogMesh.obj");
            FogMaterial = new Material(Shader.Find("Fox/VolFog_TppVolFog"));
        }

        protected override void Render()
        {
            Buffer.GetTemporaryRT(RtIds.g_tex_fog, 512, 256, 0, FilterMode.Point, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm);
            FogTextureId = new RenderTargetIdentifier(RtIds.g_tex_fog);

            Buffer.GetTemporaryRT(RtIds.inInterruptTexture, 512, 512, 0, FilterMode.Point, UnityEngine.Experimental.Rendering.GraphicsFormat.B8G8R8A8_UNorm);
            InterruptTextureId = new RenderTargetIdentifier(RtIds.inInterruptTexture);

            Buffer.Blit(Texture2D.whiteTexture, InterruptTextureId);

            Buffer.SetRenderTarget(FogTextureId);

            Buffer.SetGlobalTexture(RtIds.inInterruptTexture, InterruptTextureId);
            Buffer.DrawMesh(FogMesh, Matrix4x4.identity, FogMaterial);

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            Context.Submit();
        }
    }
}
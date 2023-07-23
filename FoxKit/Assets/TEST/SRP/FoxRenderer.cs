using UnityEngine.Rendering;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace FoxKit.TEST
{
    public class FoxRenderer
    {
        ScriptableRenderContext Context;
        Camera Camera;

        CommandBuffer Buffer = new CommandBuffer { name = typeof(FoxRenderer).Name };

        List<GrRenderPlugin> Plugins = new List<GrRenderPlugin>();

        private Mesh FullscreenMesh = new Mesh
        {
            vertices = new Vector3[]
            {
                new Vector3(0, 0, 0),
                new Vector3(2, 0, 0),
                new Vector3(0, 2, 0),
            },
            triangles = new int[] { 0, 1, 2 },
        };

        private int DgShader_VSObject = Shader.PropertyToID("g_vsObject");
        private int DgShader_PSObject = Shader.PropertyToID("g_psObject");

        private Material CopyDepthBuffer_Material;
        private int CopyDepthBuffer_inTexture = Shader.PropertyToID("inTexture");

        private Material CopyRenderBuffer_Material;
        private int CopyRenderBuffer_inImage = Shader.PropertyToID("inImage");

        public FoxRenderer()
        {
            Plugins.Add(new GrPluginGlobalVolumetricFog());
            Plugins.Add(new GrPluginDeferredGeometry());
            //Plugins.Add(new GrPluginDeferredShading());

            CopyDepthBuffer_Material = new Material(Shader.Find("Fox/CopyDepthBuffer"));

            CopyRenderBuffer_Material = new Material(Shader.Find("Fox/CopyRenderBuffer"));
    }

        public void Render(ScriptableRenderContext context, Camera camera)
        {
            Context = context;
            Camera = camera;

            Context.SetupCameraProperties(camera);

            foreach (GrRenderPlugin plugin in Plugins)
                plugin.Render(Context, Camera);

            Buffer.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);

            Buffer.SetGlobalTexture(CopyDepthBuffer_inTexture, (Plugins[1] as GrPluginDeferredGeometry).DepthBufferId);
            Buffer.DrawMesh(FullscreenMesh, Matrix4x4.identity, CopyDepthBuffer_Material);

            Buffer.SetGlobalTexture(CopyRenderBuffer_inImage, (Plugins[1] as GrPluginDeferredGeometry).RenderTargetIds[0]);
            Buffer.DrawMesh(FullscreenMesh, Matrix4x4.identity, CopyRenderBuffer_Material);

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            Context.DrawSkybox(camera);

            Context.Submit();
        }
    }
}
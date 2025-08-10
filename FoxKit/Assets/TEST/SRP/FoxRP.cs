using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public class FoxRP : RenderPipeline
    {
        FoxRenderer Renderer;

        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            foreach (Camera camera in cameras)
            {
                Renderer.Render(context, camera);
            }
        }

        public FoxRP()
        {
            DgUtils.Init();

            Renderer = new FoxRenderer();
        }
    }
}
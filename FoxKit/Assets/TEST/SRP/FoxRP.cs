using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public class FoxRP : RenderPipeline
    {
        FoxRenderer renderer;

        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            foreach (Camera camera in cameras)
            {
                renderer.Render(context, camera);
            }
        }

        public FoxRP()
        {
            renderer = new FoxRenderer();
        }
    }
}
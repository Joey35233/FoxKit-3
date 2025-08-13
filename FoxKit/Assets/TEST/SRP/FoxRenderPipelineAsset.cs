using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    [CreateAssetMenu(menuName = "FoxKit/FoxRenderPipelineAsset")]
    public class FoxRenderPipelineAsset : RenderPipelineAsset<FoxRenderPipeline>
    {
        protected override RenderPipeline CreatePipeline()
        {
            return new FoxRenderPipeline();
        }
    }
}
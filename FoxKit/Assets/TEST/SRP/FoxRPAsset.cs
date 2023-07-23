using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    [CreateAssetMenu(menuName = "FoxKit/FoxRPAsset")]
    public class FoxRPAsset : RenderPipelineAsset
    {
        protected override RenderPipeline CreatePipeline()
        {
            return new FoxRP();
        }
    }
}
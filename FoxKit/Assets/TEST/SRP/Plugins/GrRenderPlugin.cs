using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public abstract class GrRenderPlugin
    {
        public abstract string Name { get; }

        public abstract void Render(ScriptableRenderContext context, Camera camera);
    }
}
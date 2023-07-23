using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
    public abstract class GrRenderPlugin
    {
        public abstract string Name { get; }

        public ScriptableRenderContext Context;
        public Camera Camera;

        public void Render(ScriptableRenderContext context, Camera camera)
        {
            Context = context;
            Camera = camera;

            Render();
        }

        protected abstract void Render();
    }
}